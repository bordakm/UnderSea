import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { AuthService } from '../../services/auth.service';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(public auth: AuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${this.auth.getToken()}`
      }
    });
    return next.handle(request).pipe(
        catchError(error => console.error),
    );

    // .do((event: HttpEvent<any>) => {
    //     if (event instanceof HttpResponse) {
    //       // do stuff with response if you want
    //     }
    //   }, (err: any) => {
    //     if (err instanceof HttpErrorResponse) {
    //       if (err.status === 401) {
    //         // redirect to the login route or
    //         this.auth.collectFailedRequest(request);
    //       }
    //     }
    //   });
  }
}
