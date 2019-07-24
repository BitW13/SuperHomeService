export class Page {

    public id: number;

    public name: string;

    public imagePath: string;

    public isFavorite: boolean;

    constructor(){

        this.id = 0;

        this.name = 'Новая группа';

        this.imagePath = 'http://img.bibo.kz/?11974819.jpg';

        this.isFavorite = false;
    }
}