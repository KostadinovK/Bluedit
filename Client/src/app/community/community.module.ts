import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateCommunityComponent } from './create-community/create-community.component';
import {ReactiveFormsModule} from '@angular/forms';
import { ListCommunitiesComponent } from './list-communities/list-communities.component';
import { CommunityDetailsComponent } from './community-details/community-details.component';

@NgModule({
  declarations: [
    CreateCommunityComponent,
    ListCommunitiesComponent,
    CommunityDetailsComponent
  ],
  exports: [
    ListCommunitiesComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class CommunityModule { }
