import { Component, OnInit } from '@angular/core';
import { TaskService } from '../services/task.service';
import { TaskCategoryService } from '../services/task-category.service';
import { Task } from '../models/task';
import { TaskCategory } from '../models/taskCategory';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.scss']
})
export class TaskComponent implements OnInit {

  taskCards;

  categories;

  constructor(private taskService: TaskService, private categoryService: TaskCategoryService) { }

  ngOnInit() {
    this.loadItems();
  }

  loadItems() {
    this.getModels();
    this.getCategories();
  }

  getCategories() {
    this.categoryService.getItems().subscribe((data) => {
      this.categories = data;
    })
  }

  getModels() {
    this.taskService.getCards().subscribe((data) => {
      this.taskCards = data;
    });
  }

  addTask() {
    this.taskService.post(new Task()).subscribe((data) => {
      this.loadItems();
    });
  }

  addCategory() {
    this.categoryService.post(new TaskCategory()).subscribe((data) => {
      this.loadItems();
    });
  }

}
