using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ClientServer.Constants;
using ClientServer.Manager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ClientServer.Middleware
{
    /// <summary>
    /// Middleware which is just a reverse proxy where it sends forwards the request to api server
    /// and then responds back to ui with api response.
    /// this can be also used to trim headers and send only necessary headers
    /// append token to request etc.
    /// </summary>
    public class ReverseProxyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpClient _httpClient;
        private readonly ConfigurationManager _configurationManager;

        private static readonly string[] NotForwardedHttpHeaders = new[] { "Connection", "Host" };

        public ReverseProxyMiddleware(RequestDelegate next, IHttpClientFactory httpClientFactory, ConfigurationManager configurationManager)
        {
            _next = next;
            _httpClient = httpClientFactory.CreateClient(CommonConstant.API_CLIENT);
            _configurationManager = configurationManager;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestUrl = string.Concat(_configurationManager.API_BASE_URl,
                context.Request.Path.ToUriComponent(),
                context.Request.QueryString.ToUriComponent());

            var requestMessage = GenerateProxifiedRequest(context, new Uri(requestUrl));
            await SendAsync(context, requestMessage);
            return;
        }

        /// <summary>
        /// send request to api server and copy the response from api server and send back to client
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        private async Task SendAsync(HttpContext context, HttpRequestMessage requestMessage)
        {
            using (var responseMessage = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, context.RequestAborted))
            {
                context.Response.StatusCode = (int)responseMessage.StatusCode;

                foreach (var header in responseMessage.Headers)
                {
                    context.Response.Headers[header.Key] = header.Value.ToArray();
                }

                foreach (var header in responseMessage.Content.Headers)
                {
                    context.Response.Headers[header.Key] = header.Value.ToArray();
                }

                context.Response.Headers.Remove("transfer-encoding");

                await responseMessage.Content.CopyToAsync(context.Response.Body);
            }
        }

        private static HttpRequestMessage GenerateProxifiedRequest(HttpContext context, Uri targetUri)
        {
            var requestMessage = new HttpRequestMessage();
            CopyRequestContentAndHeaders(context, requestMessage);

            requestMessage.RequestUri = targetUri;
            requestMessage.Headers.Host = targetUri.Host;
            requestMessage.Method = GetMethod(context.Request.Method);


            return requestMessage;
        }

        private static void CopyRequestContentAndHeaders(HttpContext context, HttpRequestMessage requestMessage)
        {
            var requestMethod = context.Request.Method;
            if (!HttpMethods.IsGet(requestMethod) &&
                !HttpMethods.IsHead(requestMethod) &&
                !HttpMethods.IsDelete(requestMethod) &&
                !HttpMethods.IsTrace(requestMethod))
            {
                var streamContent = new StreamContent(context.Request.Body);
                requestMessage.Content = streamContent;
            }

            foreach (var header in context.Request.Headers)
            {
                if (!NotForwardedHttpHeaders.Contains(header.Key))
                {
                    if (header.Key != "User-Agent")
                    {
                        if (!requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray()))
                        {
                            requestMessage.Content?.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
                        }
                    }
                    else
                    {
                        var userAgent = header.Value.Count > 0 ? $"{header.Value[0]} {context.TraceIdentifier}" : string.Empty;

                        if (!requestMessage.Headers.TryAddWithoutValidation(header.Key, userAgent))
                        {
                            requestMessage.Content?.Headers.TryAddWithoutValidation(header.Key, userAgent);
                        }
                    }

                }
            }
        }

        private static HttpMethod GetMethod(string method)
        {
            if (HttpMethods.IsDelete(method)) return HttpMethod.Delete;
            if (HttpMethods.IsGet(method)) return HttpMethod.Get;
            if (HttpMethods.IsHead(method)) return HttpMethod.Head;
            if (HttpMethods.IsOptions(method)) return HttpMethod.Options;
            if (HttpMethods.IsPost(method)) return HttpMethod.Post;
            if (HttpMethods.IsPut(method)) return HttpMethod.Put;
            if (HttpMethods.IsTrace(method)) return HttpMethod.Trace;
            return new HttpMethod(method);
        }
    }

    public static class ReverseProxyMiddlewareExtentions
    {
        public static IApplicationBuilder UseReverseProxyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ReverseProxyMiddleware>();
        }
    }
}
