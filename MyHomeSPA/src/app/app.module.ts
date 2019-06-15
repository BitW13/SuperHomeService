import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { NoteComponent } from './notes/note/note.component';
import { NoteFilterComponent } from './notes/note-filter/note-filter.component';
import { NoteService } from './notes/services/note.service';
import { NoteCategoryService } from './notes/services/note-category.service';
import { NoteModelService } from './notes/services/note-model.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    NoteComponent,
    NoteFilterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    NoteService, 
    NoteCategoryService, 
    NoteModelService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
