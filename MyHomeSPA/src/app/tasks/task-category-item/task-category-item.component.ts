import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TaskCategory } from '../models/taskCategory';
import { TaskCategoryService } from '../services/task-category.service';

@Component({
  selector: 'app-task-category-item',
  templateUrl: './task-category-item.component.html',
  styleUrls: ['./task-category-item.component.scss']
})
export class TaskCategoryItemComponent implements OnInit {

  @Input() category;

  @Output() loadItems = new EventEmitter();

  constructor(private categoryService: TaskCategoryService) { }

  ngOnInit() {
  }

  editTaskCategory() {
  }

  saveNoteCategory() {

    this.categoryService.put(this.category).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  cancel() {
  }

  deleteNoteCategory() {
    this.categoryService.delete(this.category).subscribe((data) => {
      this.loadItems.emit();
    });
  }

}
