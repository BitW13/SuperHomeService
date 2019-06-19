import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { NoteCategory } from '../../models/noteCategory';
import { NoteService } from '../../services/note.service';
import { NoteCategoryService } from '../../services/note-category.service';

@Component({
  selector: 'app-add-note-category',
  templateUrl: './add-note-category.component.html',
  styleUrls: ['./add-note-category.component.scss']
})
export class AddNoteCategoryComponent implements OnInit {

  noteCategory;

  @Output() addNewNoteCategory = new EventEmitter<any>();

  constructor(private service: NoteCategoryService) { }

  ngOnInit() {
    this.clear();
  }

  save(){
    this.service.createItem(this.noteCategory);
    this.addNewNoteCategory.emit();
  }

  clear(){
    this.noteCategory = new NoteCategory();
  }
}
