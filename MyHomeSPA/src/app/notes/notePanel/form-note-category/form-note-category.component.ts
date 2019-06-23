import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { NoteCategory } from '../../models/noteCategory';

@Component({
  selector: 'app-form-note-category',
  templateUrl: './form-note-category.component.html',
  styleUrls: ['./form-note-category.component.scss']
})
export class FormNoteCategoryComponent implements OnInit {
  
  saveNoteCategory: NoteCategory;
  
  @Input() newNoteCategory: NoteCategory;

  @Input() isNewNoteCategory: boolean;

  @Output() addNoteCategory = new EventEmitter<NoteCategory>();

  constructor() { }

  ngOnInit() {
    this.saveNoteCategory = this.newNoteCategory;
    this.clear();
  }

  save(){
    this.addNoteCategory.emit(this.newNoteCategory);
  }

  clear(){
    if(this.isNewNoteCategory){
      this.newNoteCategory = new NoteCategory();
    }else{
      this.newNoteCategory = this.saveNoteCategory;
    }
  }
}
