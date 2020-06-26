import { Injectable, Injector } from '@angular/core';
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { ToastrService } from 'ngx-toastr';


@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private toastr: ToastrService) { }

  private handleError(err: HttpErrorResponse): Observable<any> {

    // not error but redirect
    if (err.status === 302) {
      window.location.href = err.error;
      return;
    }

    let errorMsg;
    if (err.error instanceof Error) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMsg = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMsg = `Backend returned code ${err.status}, body was: ${err.error}`;
    }
    var errMs = err.error.Message === "" ? "Oops. something went wrong, please try again." : err.error.Message;
    
    if (errMs !== null) {
      this.toastr.error(errMs);
    }
   
    return Observable.throw(errorMsg);
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Clone the request to add the new header.
    const authReq = req.clone();

    // Pass on the cloned request instead of the original request.
    return next.handle(authReq).catch(err => this.handleError(err));
  }
}
