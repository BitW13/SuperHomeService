import { Note } from './note';
import { NoteCard } from './noteCard';
import { NoteCategory } from './noteCategory';

export class SaveData {

    constructor(){}

    getCardCopy(noteCard: NoteCard): NoteCard {

        let copy: NoteCard;

        copy.note = this.getNoteCopy(noteCard.note);

        copy.category = this.getCategoryCopy(noteCard.category);

        return copy;
    }

    getNoteCopy(note: Note): Note {

        console.log(note)

        let copy: Note = new Note();
    
        copy.id = note.id;
    
        copy.name = note.name;
    
        copy.text = note.text;
    
        copy.lastChange = note.lastChange;
    
        copy.noteCategoryId = note.noteCategoryId;
    
        return copy;
    }
    
    getCategoryCopy(category: NoteCategory): NoteCategory {
    
        let copy: NoteCategory = new NoteCategory();
    
        if(category.id != 0) {
            
            copy.id = category.id;

            copy.name = category.name;

            copy.color = category.color;

            copy.isOn = category.isOn;
        }
    
        return copy;
    }
}