import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NoteCategory } from 'src/app/notes/models/noteCategory';
import { NoteCategoryService } from '../services/note-category.service';

@Component({
  selector: 'app-note-category-item',
  templateUrl: './note-category-item.component.html',
  styleUrls: ['./note-category-item.component.scss']
})
export class NoteCategoryItemComponent implements OnInit {

  @Input() category :NoteCategory;

  @Output() loadItems = new EventEmitter();

  isEditNoteCategory: boolean = false;

  saveItemValue: NoteCategory;

  constructor(private categoryService: NoteCategoryService) { }

  ngOnInit() {
    this.saveItemValue = this.getCopy(this.category)
  }

  switchingIsEditItem() {
    this.isEditNoteCategory = !this.isEditNoteCategory;
  }

  edit() {
    this.switchingIsEditItem();
    this.saveItemValue = this.getCopy(this.category);
  }

  save() {
    this.saveItemValue = this.getCopy(this.category);

    this.switchingIsEditItem();

    this.categoryService.put(this.category).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  cancel() {
    this.category = this.getCopy(this.saveItemValue);
    
    this.switchingIsEditItem();
  }

  delete() {
    this.categoryService.delete(this.category).subscribe((data) => {
      this.loadItems.emit();
    });
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
