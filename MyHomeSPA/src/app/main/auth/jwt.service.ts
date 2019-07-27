import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class JwtService {

  private url = "https://localhost:44350/api/auth/";

  private loginUrl = this.url + 'login';

  private registerUrl = this.url + 'register';

  constructor(private httpClient: HttpClient) { }

  login(user: User) {
    return this.httpClient.put<{access_token: string}>(this.loginUrl, user)
      .pipe(tap(res => {
        localStorage.setItem('access_token', res.access_token);
    }));
  }

  register(user: User) {
    return this.httpClient.post<{access_token: string}>(this.registerUrl, user)
      .pipe(tap(res => { this.login(user) }));
  }

  logOut() {
    localStorage.removeItem('access_token');
  }

  //Вошел ли пользователь в систему?
  public get logIn(): boolean{
    return localStorage.getItem('access_token') !==  null;
  }
}
