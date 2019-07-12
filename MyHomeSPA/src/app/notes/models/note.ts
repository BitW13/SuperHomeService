export class Note {

    public id: number;

    public name: string;

    public text: string;

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
        let copyNote = new Note();

        copyNote.id = this.id;
        copyNote.name = this.name;
        copyNote.text = this.text;
        copyNote.lastChange = this.lastChange;
        copyNote.noteCategoryId = this.noteCategoryId;

        return copyNote;
    }
}