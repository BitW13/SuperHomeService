import { Component, OnInit } from '@angular/core';
import { Note } from 'src/app/notes/models/note';
import { NoteCategory } from 'src/app/notes/models/noteCategory';
import { NoteService } from '../services/note.service';
import { NoteCategoryService } from '../services/note-category.service';
import { NoteModelService } from '../services/note-model.service';
import { NoteModel } from '../models/noteModel';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  models;

  categories;

  constructor(private noteService: NoteService, private categoryService: NoteCategoryService, private modelsService: NoteModelService) { }

  ngOnInit() {
    this.loadItems();
  }

  loadItems(){
    this.getModels();
    this.getCategories();
  }

  getCategories(){
    this.categoryService.getItems().subscribe((data) => {
      this.categories = data;
    });
  }

  getModels(){
    this.modelsService.getModels().subscribe((data) => {
      this.models = data;
    });
  }

  addNote(){
    this.noteService.post(new Note()).subscribe((data) => {
      this.loadItems();
    });
  }

  addCategory(){
    this.categoryService.post(new NoteCategory()).subscribe((data) => {
      this.loadItems();
    });
  }

}
