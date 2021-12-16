import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ToolbarComponent } from './toolbar/toolbar.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [ToolbarComponent],
  declarations: [PageNotFoundComponent, ToolbarComponent]
})
export class GenericModule { }
