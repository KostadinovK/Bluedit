import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateCommunityComponent } from './create-community/create-community.component';
import {ReactiveFormsModule} from '@angular/forms';
import { ListCommunitiesComponent } from './list-communities/list-communities.component';

@NgModule({
  declarations: [
    CreateCommunityComponent,
    ListCommunitiesComponent
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
