import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-community-details',
  templateUrl: './community-details.component.html',
  styleUrls: ['./community-details.component.scss']
})
export class CommunityDetailsComponent implements OnInit {
  communityId: string;

  constructor(public route: ActivatedRoute) {
    this.communityId = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {
  }

}
