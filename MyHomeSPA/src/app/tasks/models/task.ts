export class Task {
    
    public id: number;

    public name: string;

    public description: string;

    public taskCategoryId: number;

    public dateId: number;

    public isDone: boolean;

    constructor() {
        
        this.id = 0;

        this.name = "Task";

        this.description = "Description";

        this.taskCategoryId = 0;

        this.dateId = 0;

        this.isDone = false;
    }
}