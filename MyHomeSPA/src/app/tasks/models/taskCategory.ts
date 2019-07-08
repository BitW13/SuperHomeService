export class TaskCategory {

    public id: number;

    public name: string;

    public color: any;

    public isOn: boolean;
    
    constructor() {
        
        this.id = 0;

        this.name = "Category";

        this.color = '000';

        this.isOn = true;
    }
}