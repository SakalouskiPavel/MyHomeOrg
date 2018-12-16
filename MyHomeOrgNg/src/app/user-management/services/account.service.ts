import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { TokenResponse } from '../models/token-response';
import { Subject } from 'rxjs';

@Injectable()
export class AccountService {

  private ErrMsg = new Subject<string>();

  userLoggedIn = new Subject<boolean>();

  constructor(
    private http: HttpClient,
    private router: Router

  ) { }

  login(login: string, password: string) {
    const body =
      'grant_type=password&username=' + login + '&password=' + password;

    const headers = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded',
      'Access-Control-Allow-Origin': '*'
    });

    const options = {
      headers,
      withCredentials: true
    };

    this.http
      .post<TokenResponse>(environment.API_ENDPOINT + 'token', body, options)
      .subscribe(
        resp => {
          localStorage.setItem("tokenKey", resp.access_token);
          localStorage.setItem("userID", resp.userId);
          this.userLoggedIn.next(true);
          this.router.navigate(['login']);
        },
        (err: HttpErrorResponse) => {
          this.ErrMsg.next(err.error.error_description);
        }
      );
  }

  isAuthorized(): boolean {
    return localStorage.getItem("tokenKey") != null;

  }

  getError() {
    return this.ErrMsg.asObservable();
  }
}
