import { Note } from './note';
import { NoteCategory } from './noteCategory';

export class NoteModel {
    
    public isChange: boolean = false;

    constructor(

        public note?: Note,

        public noteCategory?: NoteCategory
    ) { }
}