import { Task } from './task';
import { TaskCategory } from './taskCategory';

export class TaskCard {
    
    public task: Task;

    public taskCategory: TaskCategory;

    constructor() {
        this.task = new Task();

        this.taskCategory = new TaskCategory();
    }
}