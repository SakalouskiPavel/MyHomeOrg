import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountService } from '../user-management/services/account.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private accountService: AccountService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      if (this.accountService.isAuthorized()) {
        req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${localStorage.getItem("tokenKey")}`
        }
      });
    }

    return next.handle(req);
  }
}