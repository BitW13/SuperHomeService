import { Note } from './note';
import { NoteCategory } from './noteCategory';

export class NoteCard {

    public note: Note;

    public category: NoteCategory;

    getCopy(): NoteCard {

        let noteCard: NoteCard;

        noteCard.note = this.note.getCopy();

        noteCard.category = this.category.getCopy();

        return noteCard;
    }
}