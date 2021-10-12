import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedHeaderComponent } from './shared-header/shared-header.component';
import {RouterModule} from '@angular/router';



@NgModule({
  declarations: [
    SharedHeaderComponent,
  ],
  exports: [
    SharedHeaderComponent,
  ],
    imports: [
        CommonModule,
        RouterModule
    ]
})
export class SharedModule { }
