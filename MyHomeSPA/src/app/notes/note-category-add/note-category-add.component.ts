import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { NoteCategory } from '../models/noteCategory';

@Component({
  selector: 'app-note-category-add',
  templateUrl: './note-category-add.component.html',
  styleUrls: ['./note-category-add.component.scss']
})
export class NoteCategoryAddComponent implements OnInit {

  noteCategory: NoteCategory;

  @Output() addNewNoteCategory = new EventEmitter<NoteCategory>();

  constructor() { }

  ngOnInit() {
    this.loadItems();
  }

  loadItems(){
    this.noteCategory = new NoteCategory();
  }

  save(){
    this.addNewNoteCategory.emit(this.noteCategory);
  }

}
