export class Note {

    public id: number;

    public name: string;

    public text: string

    public lastChange: Date;

    public noteCategoryId: number;

    constructor() {

        this.id = 0;

        this.name='Заметка';

        this.text='Описание';

        this.lastChange = new Date();

        this.noteCategoryId = 0;
    }
}