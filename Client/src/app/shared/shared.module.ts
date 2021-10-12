import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedHeaderComponent } from './shared-header/shared-header.component';
import { SharedFooterComponent } from './shared-footer/shared-footer.component';
import {RouterModule} from '@angular/router';



@NgModule({
  declarations: [
    SharedHeaderComponent,
    SharedFooterComponent
  ],
  exports: [
    SharedHeaderComponent,
    SharedFooterComponent
  ],
    imports: [
        CommonModule,
        RouterModule
    ]
})
export class SharedModule { }
