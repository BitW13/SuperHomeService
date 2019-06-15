import { Note } from './note';
import { NoteCategory } from './noteCategory';

export class NoteModel {
    
    constructor(
        
        public note?: Note,

        public noteCategory?: NoteCategory
    ) { }
}