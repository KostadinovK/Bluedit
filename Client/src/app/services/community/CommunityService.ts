/* tslint:disable:no-trailing-whitespace */
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import {Observable} from 'rxjs';
import { ICommunityService } from './ICommunityService';
import { Community } from '../../models/community/Community';

@Injectable({
  providedIn: 'root'
})
export class CommunityService implements ICommunityService {

  private createCommunityUrl = `${environment.apiUrl}/Community/Create`;
  private getAllCommunitiesNotJoinedOrCreatedByUserUrl = `${environment.apiUrl}/Community/GetAllCommunitiesThatAreNotJoinedOrCreatedByUser`;

  constructor(private http: HttpClient) {}

  createCommunity(data): Observable<any> {
    return this.http.post(this.createCommunityUrl, data);
  }

  getAllCommunitiesNotJoinedOrCreatedByUser(): Observable<Community[]> {
    return this.http.get<Community[]>(this.getAllCommunitiesNotJoinedOrCreatedByUserUrl);
  }
}
