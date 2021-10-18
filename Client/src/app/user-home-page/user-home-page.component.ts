import { Component, OnInit } from '@angular/core';
import { CommunityService } from '../services/community/CommunityService';
import {Community} from '../models/community/Community';
import {AuthService} from '../services/auth/AuthService';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-user-home-page',
  templateUrl: './user-home-page.component.html',
  styleUrls: ['./user-home-page.component.scss']
})
export class UserHomePageComponent implements OnInit {
  searchForm: FormGroup;
  exploreCommunities: Community[];
  searchedCommunities: Community[];

  constructor(private communityService: CommunityService, private authService: AuthService, private formBuilder: FormBuilder) {
    this.searchForm = this.formBuilder.group({
      search: [''],
    });
  }

  get userId() {
    return this.authService.getUserId();
  }

  ngOnInit(): void {
    this.communityService.getAllCommunitiesNotJoinedOrCreatedByUser()
      .subscribe(communities => this.exploreCommunities = communities);
  }

  search(): void {
    if (this.searchForm.value.search === '') {
      this.searchedCommunities = [];
      return;
    }

    this.communityService.search(this.searchForm.value.search)
      .subscribe(communities => this.searchedCommunities = communities);
  }
}
