import { Component, OnInit } from '@angular/core';
import { NoteCategoryService } from '../services/note-category.service';
import { NoteModelService } from '../services/note-model.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  noteCategories;

  noteModels;

  constructor(private noteCategoriesService: NoteCategoryService, private noteModelService: NoteModelService) { }

  ngOnInit() {
    this.loadItems();
  }

  loadItems(){
    this.loadNoteCatigories();
    this.loadNoteModels();
  }

  loadNoteCatigories() {
    this.noteCategoriesService.getItems().subscribe((data) => {
      this.noteCategories = data;
    });
  }

  loadNoteModels(){
    this.noteModelService.getItems().subscribe((data) => {
      this.noteModels = data;
    });
  }
}
