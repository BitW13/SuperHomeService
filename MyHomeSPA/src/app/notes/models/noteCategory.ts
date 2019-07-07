export class NoteCategory {

    public id: number;

    public name: string;

    public color: any;

    public isOn: boolean;

    constructor() {

        this.id = 0;

        this.name = 'Категория';

        this.color = '000';

        this.isOn = true;
    }

    getCopy(): NoteCategory {
        let copyCategory = new NoteCategory();

        copyCategory.id = this.id;
        copyCategory.name = this.name;
        copyCategory.color = this.color;
        copyCategory.isOn = this.isOn;

        return copyCategory;
    }
}