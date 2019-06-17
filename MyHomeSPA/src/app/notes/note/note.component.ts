import { Component, OnInit } from '@angular/core';
import { NoteCategoryService } from '../services/note-category.service';
import { NoteCategory } from '../models/noteCategory';
import { Note } from '../models/note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  items: Array<NoteCategory>;
  ifNewNote: boolean = false;
  ifActiveFilterPanel: boolean = true;
  ifNewNoteCategory: boolean;

  constructor(private service: NoteCategoryService, private noteService: NoteService) { 
    this.items = new Array<NoteCategory>();
  }

  ngOnInit() {
    this.loadItems();
  }

  loadItems(){
    this.service.getItems().subscribe((data: NoteCategory[]) => {
      this.items = data;
    });
  }

  newNote(){
    this.ifNewNote = !this.ifNewNote;
  }

  activateFilterPanel(){
    this.ifActiveFilterPanel = !this.ifActiveFilterPanel;
  }

  addNewNote(note: Note){
    this.noteService.createItem(note).subscribe((data: Note) => {
      this.newNote();
      this.loadItems();
    });
  }

  onVisibilitySwitching(noteCategory: NoteCategory){
    this.service.updateItem(noteCategory).subscribe((data: NoteCategory) => {
      this.loadItems();
    })
  }

  onNewCategory(){
    this.ifNewNoteCategory = !this.ifNewNoteCategory;
  }

  addNewNoteCategory(noteCategory: NoteCategory){
    this.service.createItem(noteCategory).subscribe((data: NoteCategory) => {
      this.onNewCategory();
      this.loadItems();
    });
  }

  changeVisibility(noteCategory: NoteCategory){
    this.service.updateItem(noteCategory).subscribe((data: NoteCategory) => {
      this.loadItems();
    });
  }
}
