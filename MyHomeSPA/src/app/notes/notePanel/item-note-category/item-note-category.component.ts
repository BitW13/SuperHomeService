import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NoteCategory } from '../../models/noteCategory';

@Component({
  selector: 'app-item-note-category',
  templateUrl: './item-note-category.component.html',
  styleUrls: ['./item-note-category.component.scss']
})
export class ItemNoteCategoryComponent implements OnInit {

  @Input() noteCategory: NoteCategory;

  @Output() deleteNoteCategory = new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }

  delete(id: number){
    this.deleteNoteCategory.emit(id);
  }
}
