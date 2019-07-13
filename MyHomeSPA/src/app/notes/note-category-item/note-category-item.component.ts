import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NoteCategory } from 'src/app/notes/models/noteCategory';
import { NoteCategoryService } from '../services/note-category.service';

@Component({
  selector: 'app-note-category-item',
  templateUrl: './note-category-item.component.html',
  styleUrls: ['./note-category-item.component.scss']
})
export class NoteCategoryItemComponent implements OnInit {

  @Input() category;

  @Output() loadItems = new EventEmitter();

  isEditNoteCategory: boolean;

  saveForNoteCategory: NoteCategory;

  constructor(private categoryService: NoteCategoryService) { }

  ngOnInit() {
  }

  editNoteCategory() {
    const copyCategory = new NoteCategory();

    copyCategory.id = this.category.id;
    copyCategory.name = this.category.name;
    copyCategory.color = this.category.color;
    copyCategory.isOn = this.category.isOn;
    this.saveForNoteCategory = copyCategory;

    this.isEditNoteCategory = !this.isEditNoteCategory;
  }

  saveNoteCategory() {
    this.saveForNoteCategory = null;

    this.isEditNoteCategory = !this.isEditNoteCategory;

    this.categoryService.put(this.category).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  cancel() {
    this.category = this.saveForNoteCategory;

    this.isEditNoteCategory = !this.isEditNoteCategory;
  }

  deleteNoteCategory() {
    this.categoryService.delete(this.category).subscribe((data) => {
      this.loadItems.emit();
    });
  }

}
