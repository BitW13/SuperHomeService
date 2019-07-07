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

    getCopy(): Note {

        let copy: Note = new Note();

        copy.id = this.id;

        copy.name = this.name;

        copy.text = this.text;

        copy.lastChange = this.lastChange;

        copy.noteCategoryId = this.noteCategoryId;

        return copy;
    }
}