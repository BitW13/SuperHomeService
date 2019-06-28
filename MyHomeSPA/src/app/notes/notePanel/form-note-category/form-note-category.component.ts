import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { NoteCategory } from '../../models/noteCategory';

@Component({
  selector: 'app-form-note-category',
  templateUrl: './form-note-category.component.html',
  styleUrls: ['./form-note-category.component.scss']
})
export class FormNoteCategoryComponent implements OnInit {
  
  @Input() noteCategory: NoteCategory;

  @Input() saveNoteCategory: NoteCategory;

  @Input() isNewNoteCategory: boolean;

  @Output() addNoteCategory = new EventEmitter<NoteCategory>();

  @Output() editNoteCategory = new EventEmitter<NoteCategory>();

  constructor() { }

  ngOnInit() {
  }

  save(){
    if(this.isNewNoteCategory){
      this.addNoteCategory.emit(this.noteCategory);
    }
    else{
      this.editNoteCategory.emit(this.noteCategory);
    }
  }

  clear(){
    this.noteCategory.imagePath = '';
    this.noteCategory.name = '';
  }
}
