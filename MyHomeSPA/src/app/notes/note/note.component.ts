import { Component, OnInit } from '@angular/core';
import { NoteCategoryService } from '../services/note-category.service';
import { NoteCategory } from '../models/noteCategory';
import { NoteModel } from '../models/noteModel';
import { NoteModelService } from '../services/note-model.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  noteCategories: Array<NoteCategory>;

  noteModels: Array<NoteModel>;

  constructor(private noteCategoryservice: NoteCategoryService, private noteModelService: NoteModelService) { }

  ngOnInit() {
    this.noteCategoryservice.getItems().subscribe((data: NoteCategory[]) => {
      this.noteCategories = data;
    });
    console.log(this.noteCategories)
  }

  loadItems(){
    this.loadNoteCatigories();
    this.loadNoteModels();
  }

  loadNoteCatigories(){
    this.noteCategoryservice.getItems().subscribe((data1: NoteCategory[]) => {
      this.noteCategories = data1;
    });
  }

  loadNoteModels(){
    this.noteModelService.getItems().subscribe((data2: NoteModel[]) => {
      this.noteModels = data2;
    });
  }
}
