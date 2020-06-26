using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Data.Respository
{
    public class Respository<T> : IRepository<T> where T : class
    {
        private readonly string _connection;

        // current type which is been asked for.
        private readonly Type _type;

        private readonly string _fileDestination;

        public Respository(string connection)
        {
            _connection = connection;
            _type = typeof(T);

            _fileDestination = $"{connection}//{_type.Name}.json";
        }

        public T Create(T data)
        {
            var json = ReadJson();

            var obj = string.IsNullOrEmpty(json) ? new List<T>() : JsonConvert.DeserializeObject<List<T>>(json);

            obj.Add(data);

            WriteJson(obj);

            return data;
        }

        public T Find(Func<T, bool> predicate)
        {
            var json = ReadJson();
            var obj = JsonConvert.DeserializeObject<List<T>>(json);

            return obj.FirstOrDefault(predicate);
        }

        public List<T> GetAll()
        {
            var json = ReadJson();
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public List<T> Get(Func<T, bool> predicate)
        {
            var json = ReadJson();
            var obj = JsonConvert.DeserializeObject<List<T>>(json);
            return obj.Where(predicate).ToList();
        }

        public T Update(T data)
        {
            throw new NotImplementedException();
        }

        // read json
        private string ReadJson()
        {
            string json;
            using (var r = new StreamReader(_fileDestination))
            {
                json = r.ReadToEnd();
            }

            var tempJson = json.Trim();

            tempJson = Regex.Replace(tempJson, @"\s+", "");

            return tempJson == "{}" ? string.Empty : json;
        }

        // write back to json
        private void WriteJson<TD>(TD data)
        {
            var obj = JsonConvert.SerializeObject(data);
            using (var r = new StreamWriter(_fileDestination))
            {
                r.Write(obj);
            }
        }
    }
}
