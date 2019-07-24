import { Component, OnInit } from '@angular/core';
import { Note } from 'src/app/notes/models/note';
import { NoteCategory } from 'src/app/notes/models/noteCategory';
import { NoteService } from '../services/note.service';
import { NoteCategoryService } from '../services/note-category.service';
import { NoteCard } from '../models/noteCard';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss'],
  providers: [NoteService, NoteCategoryService]
})
export class NoteComponent implements OnInit {

  cards: NoteCard[];

  categories: NoteCategory[];

  constructor(private noteService: NoteService, private categoryService: NoteCategoryService) { }

  ngOnInit() {
    this.loadItems();
  }
  
  loadItems() {
    this.getCards();
    this.getCategories();
  }

  getCategories() {    
    this.categoryService.getItems().subscribe(data => this.categories = data);
  }

  getCards() {    
    this.noteService.getCards().subscribe(data => this.cards = data);
  }

  addNote() {
    this.noteService.post(new Note()).subscribe(data => this.cards.unshift(data));
  }

  addCategory() {
    this.categoryService.post(new NoteCategory()).subscribe((data) => this.categories.push(data));
  }

  deleteNote(item: NoteCard) {
    this.noteService.delete(item.note).subscribe(data => {
      this.getCards();
    });
  }

  deleteCategory(item: NoteCategory) {
    this.categoryService.delete(item).subscribe(data => {
      this.loadItems();
    });
  }
}
