import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }   from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavpanelComponent } from './navpanel/navpanel.component';
import { NoteComponent } from './notes/note/note.component';
import { NoteItemComponent } from './notes/note-item/note-item.component';
import { NoteCategoryItemComponent } from './notes/note-category-item/note-category-item.component';

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
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
