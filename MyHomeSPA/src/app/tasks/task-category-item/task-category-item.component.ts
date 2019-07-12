import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TaskCategory } from '../models/taskCategory';
import { TaskCategoryService } from '../services/task-category.service';

@Component({
  selector: 'app-task-category-item',
  templateUrl: './task-category-item.component.html',
  styleUrls: ['./task-category-item.component.scss']
})
export class TaskCategoryItemComponent implements OnInit {

  @Input() category: TaskCategory;

  @Output() loadItems = new EventEmitter();

  isEditItem: boolean = false;

  saveItemValue: TaskCategory;

  constructor(private categoryService: TaskCategoryService) { }

  ngOnInit() {
  }

  switchingIsEditItem() {
    this.isEditItem = !this.isEditItem;
  }

  edit() {
    this.switchingIsEditItem();
    this.saveItemValue = this.getCopy(this.category);
  }

  save() {
    this.saveItemValue = null;
    this.switchingIsEditItem();
    this.categoryService.put(this.category).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  cancel() {
    this.category = this.getCopy(this.saveItemValue);
    this.saveItemValue = null;
    this.switchingIsEditItem();
  }

  delete() {
    this.categoryService.delete(this.category).subscribe((data) => {
      this.loadItems.emit();
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
