import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Info } from '../_models/info';
import {environment} from '../../assets/environment/environment'

@Injectable({
  providedIn: 'root'
})
export class BlpTokenService {
  baseUrl: string = environment.baseUrl;
  constructor(private http: HttpClient) {}

  getData(): Observable<Info[]> {
    return this.http.get<Info[]>(`${this.baseUrl}/api/Token/token-data`);
  }

  postUpdateData():Observable<object>{
    return this.http.post<object>(`${this.baseUrl}/api/Token/save-updated-token-supply`,{})
  }

}
