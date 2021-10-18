import { Component, OnInit, Input } from '@angular/core';
import { Community } from '../../models/community/Community';
import {Router} from '@angular/router';

@Component({
  selector: 'app-list-communities',
  templateUrl: './list-communities.component.html',
  styleUrls: ['./list-communities.component.scss']
})
export class ListCommunitiesComponent implements OnInit {
  @Input() communities: Community[];
  @Input() userId: string;

  constructor(public router: Router) { }

  ngOnInit(): void {
  }

  selectCommunity(id: string) {
    this.router.navigate([`community/${id}`]);
    return;
  }
}
