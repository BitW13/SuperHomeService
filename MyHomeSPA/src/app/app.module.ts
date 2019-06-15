import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule }   from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { NoteComponent } from './notes/note/note.component';
import { NoteFilterComponent } from './notes/note-filter/note-filter.component';
import { NoteService } from './notes/services/note.service';
import { NoteCategoryService } from './notes/services/note-category.service';
import { NoteModelService } from './notes/services/note-model.service';
import { NoteListComponent } from './notes/note-list/note-list.component';
import { NoteAddComponent } from './notes/note-add/note-add.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    NoteComponent,
    NoteFilterComponent,
    NoteListComponent,
    NoteAddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    NoteService, 
    NoteCategoryService, 
    NoteModelService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
