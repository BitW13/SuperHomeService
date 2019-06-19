import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { NoteCategory } from '../../models/noteCategory';
import { NoteCategoryService } from '../../services/note-category.service';

@Component({
  selector: 'app-note-panel',
  templateUrl: './note-panel.component.html',
  styleUrls: ['./note-panel.component.scss']
})
export class NotePanelComponent implements OnInit {

  isNewNoteCategory: boolean;

  @Input() noteCategories;

  @Output() loadItems = new EventEmitter<any>();

  constructor(private service: NoteCategoryService) { }

  ngOnInit() {
    this.isNewNoteCategory = false;
  }

  switchingIsNewNoteCategory(){
    this.isNewNoteCategory = !this.isNewNoteCategory;
  }

  addNewNoteCategory(){
    this.switchingIsNewNoteCategory();
    this.loadItems.emit();
  }

  edit(noteCategory){

  }

  changeVisibility(noteCategory: NoteCategory){
    noteCategory.isOn = !noteCategory.isOn;
    this.service.updateItem(noteCategory);
    this.loadItems.emit();
  }

  delete(noteCategory: NoteCategory){
    this.service.deleteItem(noteCategory.id);
    this.loadItems.emit();
  }
}
