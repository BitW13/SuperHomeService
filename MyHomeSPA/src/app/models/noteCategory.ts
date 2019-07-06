export class NoteCategory {

    public id: number;

    public name: string;

    public color: any;

    constructor() {

        this.id = 0;

        this.name = 'Категория';

        this.color = '000';
    }

    getCopy(): NoteCategory {

        let copy: NoteCategory = new NoteCategory();

        copy.id = this.id;

        copy.name = this.name;

        copy.color = this.color;

        return copy;
    }
}