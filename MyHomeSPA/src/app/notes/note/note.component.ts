import { Component, OnInit } from '@angular/core';
import { Note } from 'src/app/notes/models/note';
import { NoteCategory } from 'src/app/notes/models/noteCategory';
import { NoteService } from '../services/note.service';
import { NoteCategoryService } from '../services/note-category.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  noteCards;

  categories;

  constructor(private noteService: NoteService, private categoryService: NoteCategoryService) { }

  ngOnInit() {
    this.loadItems();
  }
  
  loadItems() {
    this.getModels();
    this.getCategories();
  }

  getCategories() {
    this.categoryService.getItems().subscribe((data) => {
      this.categories = data;
    });
  }

  getModels() {
    this.noteService.getCards().subscribe((data) => {
      this.noteCards = data;
    });
  }

  addNote() {
    this.noteService.post(new Note()).subscribe((data) => {
      this.loadItems();
    });
  }

  addCategory() {
    this.categoryService.post(new NoteCategory()).subscribe((data) => {
      this.loadItems();
    });
  }
}
