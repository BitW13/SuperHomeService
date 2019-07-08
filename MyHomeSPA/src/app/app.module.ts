import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavpanelComponent } from './navpanel/navpanel.component';
import { NoteComponent } from './notes/note/note.component';
import { NoteItemComponent } from './notes/note-item/note-item.component';
import { NoteCategoryItemComponent } from './notes/note-category-item/note-category-item.component';
import { NoteService } from './notes/services/note.service';
import { NoteCategoryService } from './notes/services/note-category.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavpanelComponent,
    NoteComponent,
    NoteItemComponent,
    NoteCategoryItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [NoteService, NoteCategoryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
