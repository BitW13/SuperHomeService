export class TaskCategory {

    public id: number;

    public name: string;

    public color: string;

    public imagePath: string;

    public isOn: boolean;
    
    constructor() {
        
        this.id = 0;

        this.name = "Category";

        this.color = '000';

        this.imagePath = 'https://st3.depositphotos.com/13821126/18366/v/1600/depositphotos_183663702-stock-illustration-sale-bags-packages-in-the.jpg';

        this.isOn = true;
    }
}