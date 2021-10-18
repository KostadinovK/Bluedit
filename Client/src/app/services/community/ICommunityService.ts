import { Observable } from 'rxjs';
import { Community } from '../../models/community/Community';

export interface ICommunityService {
  createCommunity(data): Observable<any>;

  getAllCommunitiesNotJoinedOrCreatedByUser(): Observable<Community[]>;

  search(searchWord: string): Observable<Community[]>;
}
