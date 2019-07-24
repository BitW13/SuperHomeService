import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NoteCategory } from 'src/app/notes/models/noteCategory';
import { NoteCategoryService } from '../services/note-category.service';

@Component({
  selector: 'app-note-category-item',
  templateUrl: './note-category-item.component.html',
  styleUrls: ['./note-category-item.component.scss'],
  providers: [NoteCategoryService]
})
export class NoteCategoryItemComponent implements OnInit {

  @Input() category :NoteCategory;

  @Output() deleteCategory = new EventEmitter<NoteCategory>();

  @Output() loadItems = new EventEmitter();

  saveItemValue: NoteCategory;

  constructor(private categoryService: NoteCategoryService) { }

  ngOnInit() {
    this.saveItemValue = this.getCopy(this.category)
  }

  edit() {    
    this.saveItemValue = this.getCopy(this.category);
  }

  save() {

    this.saveItemValue = null;
    
    this.categoryService.put(this.category).subscribe(data =>{
      this.category = data;
      this.loadItems.emit();
    });
  }

  cancel() {

    this.category = this.getCopy(this.saveItemValue);
    
    this.saveItemValue = null;
  }

  delete() {
    this.deleteCategory.emit(this.category);
  }

  getCopy(item: NoteCategory) : NoteCategory {
    
    let copy = new NoteCategory();

    copy.id = item.id;
    copy.name = item.name;
    copy.color = item.color;
    copy.isOn = item.isOn;

    return copy;
  }
}
