import { Component, OnInit, Input } from '@angular/core';
import { NoteCategory } from 'src/app/notes/models/noteCategory';
import { NoteCategoryService } from '../services/note-category.service';

@Component({
  selector: 'app-note-category-item',
  templateUrl: './note-category-item.component.html',
  styleUrls: ['./note-category-item.component.scss']
})
export class NoteCategoryItemComponent implements OnInit {

  @Input() category;

  isEditNoteCategory: boolean;

  saveForNoteCategory: NoteCategory;

  constructor(private categoryService: NoteCategoryService) { }

  ngOnInit() {
    console.log(this.category)
  }

  editNoteCategory() {

    this.saveForNoteCategory = this.category.getCopy();

    this.isEditNoteCategory = !this.isEditNoteCategory;
  }

  saveNoteCategory() {

    this.saveForNoteCategory = null;

    this.isEditNoteCategory = !this.isEditNoteCategory;

    this.categoryService.put(this.category).subscribe((data) => {
      this.category = data;
    });
  }

  cancel(){

    this.category = this.saveForNoteCategory.getCopy();

    this.isEditNoteCategory = !this.isEditNoteCategory;
  }

  deleteNoteCategory() {
    
    this.categoryService.delete(this.category).subscribe((data) => {
      this.category = data;
    });
  }

}
