import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';

import { MessageComponent } from './components/message/message.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { ToolbarComponent } from './components/toolbar/toolbar.component';
import { MaterialModule } from './material.module';

@NgModule({
  imports: [CommonModule, MaterialModule, FlexLayoutModule],
  exports: [ToolbarComponent, MaterialModule],
  declarations: [PageNotFoundComponent, ToolbarComponent, MessageComponent],
})
export class GenericModule {}
