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

  constructor(private noteCategoryservice: NoteCategoryService, private noteModelService: NoteModelService) {
  }

  ngOnInit() {
    this.onReLoadItems();
    console.log(this.noteCategories);
    console.log(this.noteModels);
  }

  loadNoteCatigories(){
    this.noteCategoryservice.getItems().subscribe((data: NoteCategory[]) => {
      this.noteCategories = data;
    });
  }

  loadNoteModels(){
    this.noteModelService.getItems().subscribe((data: NoteModel[]) => {
      this.noteModels = data;
    });
  }

  onReLoadItems(){
    this.loadNoteCatigories();
    this.loadNoteModels();
  }
}
