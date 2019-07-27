import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TaskCard } from '../models/taskCard';
import { TaskService } from '../services/task.service';
import { TaskCategory } from '../models/taskCategory';
import { Task } from '../models/task';

@Component({
  selector: 'app-task-item',
  templateUrl: './task-item.component.html',
  styleUrls: ['./task-item.component.scss']
})
export class TaskItemComponent implements OnInit {
  
  panelOpenState: boolean = false;

  @Input() card: TaskCard;

  @Input() categories: TaskCategory[];

  @Output() getModels = new EventEmitter();  

  saveItemValue: Task;

  constructor(private taskService: TaskService) { }

  ngOnInit() {
    this.saveItemValue = this.getCopy(this.card.task);
  }

  edit() {
    this.saveItemValue = this.getCopy(this.card.task);
  }

  save() {    
    this.saveItemValue = null;
    this.taskService.put(this.card.task).subscribe((data) => { });
  }

  cancel() {
    this.card.task = this.getCopy(this.saveItemValue);
    
    this.saveItemValue = null;
  }

  delete() {
    this.taskService.delete(this.card.task).subscribe((data) => {
      this.getModels.emit();
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
