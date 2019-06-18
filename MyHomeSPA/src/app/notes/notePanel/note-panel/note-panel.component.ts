import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { NoteCategory } from '../../models/noteCategory';
import { NoteCategoryService } from '../../services/note-category.service';

@Component({
  selector: 'app-note-panel',
  templateUrl: './note-panel.component.html',
  styleUrls: ['./note-panel.component.scss']
})
export class NotePanelComponent implements OnInit {

  isNewNoteCategory: boolean = false;

  @Input() noteCategories: Array<NoteCategory>;

  @Output() loadItems = new EventEmitter<any>();

  constructor(private service: NoteCategoryService) { }

  ngOnInit() {
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
    this.loadItems.emit();
  }

  delete(noteCategory: NoteCategory){
    this.service.deleteItem(noteCategory.id);
    this.loadItems.emit();
  }
}
