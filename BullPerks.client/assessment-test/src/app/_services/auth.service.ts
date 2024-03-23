import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import {environment} from '../../assets/environment/environment'
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  tokenSubject = new BehaviorSubject<boolean>(false)
  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) {
    this.tokenSubject.next(this.isLoggedIn() ? true : false)
  }


  login(credentials: { username: string; password: string }): Observable<any> {
    return this.http.post(`${this.baseUrl}/api/Account/login`, credentials);
  }


  storeToken(token: string) {
    localStorage.setItem('token', token);
    localStorage.setItem('isLoggedIn', 'true');
    this.tokenSubject.next(true)
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('isLoggedIn') === 'true';
  }

  getToken() {
    return localStorage.getItem('token')
  }

  clearlocalStorage() {
    localStorage.clear();
    this.tokenSubject.next(false)
  }

}
