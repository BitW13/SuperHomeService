import { Component, OnInit, Input } from '@angular/core';
import { NoteCategory } from 'src/app/models/noteCategory';

@Component({
  selector: 'app-note-category-item',
  templateUrl: './note-category-item.component.html',
  styleUrls: ['./note-category-item.component.scss']
})
export class NoteCategoryItemComponent implements OnInit {

  @Input() category: NoteCategory;

  isEditNoteCategory: boolean;

  saveForNoteCategory: NoteCategory;

  constructor() { }

  ngOnInit() {
  }

  editNoteCategory() {
    this.saveForNoteCategory = this.category.getCopy();
    this.isEditNoteCategory = !this.isEditNoteCategory;
  }

  saveNoteCategory() {
    this.saveForNoteCategory = null;
    this.isEditNoteCategory = !this.isEditNoteCategory;
  }

  cansel(){
    this.category = this.saveForNoteCategory.getCopy();
    this.isEditNoteCategory = !this.isEditNoteCategory;
  }

  deleteNoteCategory() {
    
  }

}
