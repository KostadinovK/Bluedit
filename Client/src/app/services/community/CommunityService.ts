/* tslint:disable:no-trailing-whitespace */
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import {Observable} from 'rxjs';
import { ICommunityService } from './ICommunityService';

@Injectable({
  providedIn: 'root'
})
export class CommunityService implements ICommunityService {

  private createCommunityUrl = `${environment.apiUrl}/Community/Create`;

  constructor(private http: HttpClient) {}

  createCommunity(data): Observable<any> {
    return this.http.post(this.createCommunityUrl, data);
  }
}
