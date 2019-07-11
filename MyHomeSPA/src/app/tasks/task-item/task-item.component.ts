import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TaskCard } from '../models/taskCard';
import { TaskService } from '../services/task.service';

@Component({
  selector: 'tr[app-task-item]',
  templateUrl: './task-item.component.html',
  styleUrls: ['./task-item.component.scss']
})
export class TaskItemComponent implements OnInit {

  @Input() taskCard;

  @Input() categories;

  @Output() loadItems = new EventEmitter();

  constructor(private taskService: TaskService) { }

  ngOnInit() {
  }

  editNote() {
  }

  saveNote() {    
    this.taskService.put(this.taskCard.task).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  cancel() {
  }

  deleteNote() {
    this.taskService.delete(this.taskCard.task).subscribe((data) => {
      this.loadItems.emit();
    });
  }

}
