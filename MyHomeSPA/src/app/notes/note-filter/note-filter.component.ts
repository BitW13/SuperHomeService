import { Component, OnInit, ViewChild, TemplateRef, Input, Output, EventEmitter } from '@angular/core';
import { NoteCategory } from '../models/noteCategory';
import { NoteCategoryService } from '../services/note-category.service';

@Component({
  selector: 'app-note-filter',
  templateUrl: './note-filter.component.html',
  styleUrls: ['./note-filter.component.scss']
})
export class NoteFilterComponent implements OnInit {

  @Input() noteCategory: NoteCategory;
  @Output() changeVisibility = new EventEmitter<NoteCategory>();

  constructor() { }

  ngOnInit() {
  }

  visibilitySwitching(){
    this.noteCategory.isOn = !this.noteCategory.isOn;
    this.changeVisibility.emit(this.noteCategory);
  }

}
