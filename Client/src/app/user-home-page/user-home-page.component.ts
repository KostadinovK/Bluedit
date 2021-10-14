import { Component, OnInit } from '@angular/core';
import { CommunityService } from '../services/community/CommunityService';
import {Community} from '../models/community/Community';
import {AuthService} from '../services/auth/AuthService';

@Component({
  selector: 'app-user-home-page',
  templateUrl: './user-home-page.component.html',
  styleUrls: ['./user-home-page.component.scss']
})
export class UserHomePageComponent implements OnInit {
  communities: Community[];

  constructor(private communityService: CommunityService, private authService: AuthService) { }

  get userId() {
    return this.authService.getUserId();
  }

  ngOnInit(): void {
    this.communityService.getAllCommunitiesNotJoinedOrCreatedByUser()
      .subscribe(communities => this.communities = communities);
  }
}
