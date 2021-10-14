import { Component, OnInit, Input } from '@angular/core';
import { Community } from '../../models/community/Community';

@Component({
  selector: 'app-list-communities',
  templateUrl: './list-communities.component.html',
  styleUrls: ['./list-communities.component.scss']
})
export class ListCommunitiesComponent implements OnInit {
  @Input() communities: Community[];
  @Input() userId: string;

  constructor() { }

  ngOnInit(): void {
  }

  selectCommunity(id: string) {
    console.log(id);
  }
}
