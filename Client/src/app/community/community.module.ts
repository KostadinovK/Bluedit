import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateCommunityComponent } from './create-community/create-community.component';
import {ReactiveFormsModule} from '@angular/forms';



@NgModule({
  declarations: [
    CreateCommunityComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class CommunityModule { }
