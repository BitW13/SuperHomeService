import { Component, OnInit } from '@angular/core';
import { NoteCategoryService } from '../services/note-category.service';
import { NoteModelService } from '../services/note-model.service';
import { NoteModel } from '../models/noteModel';
import { NoteCategory } from '../models/noteCategory';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  noteCategories;

  noteModels;

  constructor(private noteCategoryservice: NoteCategoryService, private noteModelService: NoteModelService) { }

  ngOnInit() {
    this.loadItems();
  }

  loadItems(){
    this.loadNoteCatigories();
    this.loadNoteModels();
  }

  loadNoteCatigories(){
    this.noteCategoryservice.getItems().subscribe((data) => {
      this.noteCategories = data as NoteCategory[]
    });
  }

  loadNoteModels(){
    this.noteModelService.getItems().subscribe((data) => {
      this.noteModels = data as NoteModel[]
    });
  }
}
