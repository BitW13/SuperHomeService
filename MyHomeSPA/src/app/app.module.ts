import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule }   from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { NoteComponent } from './notes/note/note.component';
import { NoteService } from './notes/services/note.service';
import { NoteCategoryService } from './notes/services/note-category.service';
import { NoteModelService } from './notes/services/note-model.service';
import { NotePanelComponent } from './notes/notePanel/note-panel/note-panel.component';
import { NoteFieldComponent } from './notes/noteField/note-field/note-field.component';
import { ItemNoteCategoryComponent } from './notes/notePanel/item-note-category/item-note-category.component';
import { FormNoteCategoryComponent } from './notes/notePanel/form-note-category/form-note-category.component';
import { ItemNoteComponent } from './notes/noteField/item-note/item-note.component';
import { FormNoteComponent } from './notes/noteField/form-note/form-note.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    NoteComponent,
    NotePanelComponent,
    NoteFieldComponent,
    ItemNoteCategoryComponent,
    FormNoteCategoryComponent,
    ItemNoteComponent,
    FormNoteComponent
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
