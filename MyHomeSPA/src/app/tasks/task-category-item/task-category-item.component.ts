import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TaskCategory } from '../models/taskCategory';
import { TaskCategoryService } from '../services/task-category.service';

@Component({
  selector: 'app-task-category-item',
  templateUrl: './task-category-item.component.html',
  styleUrls: ['./task-category-item.component.scss']
})
export class TaskCategoryItemComponent implements OnInit {

  panelOpenState = false;

  @Input() category: TaskCategory;

  @Output() getCategories = new EventEmitter();

  saveItemValue: TaskCategory;

  constructor(private categoryService: TaskCategoryService) { }

  ngOnInit() {
    this.saveItemValue = this.getCopy(this.category)
  }

  edit() {
    this.saveItemValue = this.getCopy(this.category)
  }

  save() {
    this.saveItemValue = this.getCopy(this.category)

    this.categoryService.put(this.category).subscribe((data) => {
      this.getCategories.emit();
    });
  }

  cancel() {
    this.category = this.getCopy(this.saveItemValue);

    this.saveItemValue = null;
  }

  delete() {
    this.categoryService.delete(this.category).subscribe((data) => {
      this.getCategories.emit();
    });
  }

  getCopy(item: TaskCategory) : TaskCategory {
    
    let copy = new TaskCategory();

    copy.id = item.id;
    copy.name = item.name;
    copy.color =item.color;
    copy.isOn = copy.isOn;

    return copy;
  }

}
