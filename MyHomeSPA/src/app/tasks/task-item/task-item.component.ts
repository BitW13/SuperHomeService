import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TaskCard } from '../models/taskCard';
import { TaskService } from '../services/task.service';
import { TaskCategory } from '../models/taskCategory';
import { Task } from '../models/task';

@Component({
  selector: 'tr[app-task-item]',
  templateUrl: './task-item.component.html',
  styleUrls: ['./task-item.component.scss']
})
export class TaskItemComponent implements OnInit {

  @Input() taskCard: TaskCard;

  @Input() categories: TaskCategory[];

  @Output() loadItems = new EventEmitter();

  saveItemValue: Task;

  isEditItem: boolean = false;

  constructor(private taskService: TaskService) { }

  switchingIsEditItem() {
    this.isEditItem = !this.isEditItem;
  }

  ngOnInit() {
  }

  edit() {
    this.switchingIsEditItem();
    this.saveItemValue = this.getCopy(this.taskCard.task);
  }

  save() {    
    this.saveItemValue = null;
    this.switchingIsEditItem();
    this.taskService.put(this.taskCard.task).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  cancel() {
    this.taskCard.task = this.getCopy(this.saveItemValue);
    this.saveItemValue = null;
    this.switchingIsEditItem();
  }

  delete() {
    this.taskService.delete(this.taskCard.task).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  getCopy(item: Task): Task {
    
    let copy = new Task();

    copy.id = item.id;
    copy.name = item.name;
    copy.description = item.description;
    copy.taskCategoryId = item.taskCategoryId;
    copy.dateId = item.dateId;
    copy.isDone = item.isDone;

    return copy;
  }

}
