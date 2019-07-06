import { Component, OnInit } from '@angular/core';
import { Note } from 'src/app/models/note';
import { NoteCategory } from 'src/app/models/noteCategory';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  notes: Array<Note>;
  categories: Array<NoteCategory>;

  constructor() { }

  ngOnInit() {
    this.getNotes();
    this.getCategories();
  }

  getCategories(){
    this.categories = [
      new NoteCategory(),
      new NoteCategory(),
      new NoteCategory()
    ]
  }

  getNotes(){
    this.notes = [
      new Note(),
      new Note(),
      new Note(),
      new Note(),
      new Note(),
      new Note()
    ]
    console.log(this.notes)
  }

  addNote(){
    this.notes.unshift(new Note());
  }

}
