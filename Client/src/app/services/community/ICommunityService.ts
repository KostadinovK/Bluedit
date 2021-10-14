import { Observable } from 'rxjs';

export interface ICommunityService {
  createCommunity(data): Observable<any>;
}
