import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';

import { MessageComponent } from './components/message/message.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { MaterialModule } from './material.module';
import { ToolbarComponent } from './toolbar/toolbar.component';

@NgModule({
  imports: [CommonModule, MaterialModule, FlexLayoutModule],
  exports: [ToolbarComponent, MaterialModule],
  declarations: [PageNotFoundComponent, ToolbarComponent, MessageComponent],
})
export class GenericModule {}
