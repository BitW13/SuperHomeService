import { Note } from './note';
import { NoteCategory } from './noteCategory';

export class NoteCard {

    public note: Note;

    public category: NoteCategory;

    getCopy(): NoteCard {
        let copyNote = new Note();

        copyNote.id = this.note.id;
        copyNote.name = this.note.name;
        copyNote.text = this.note.text;
        copyNote.lastChange = this.note.lastChange;
        copyNote.noteCategoryId = this.note.noteCategoryId;

        let copyNoteCard = new NoteCard();

        if (this.category) {
            let copyCategory = new NoteCategory();

            copyCategory.id = this.category.id;
            copyCategory.name = this.category.name;
            copyCategory.color = this.category.color;
            copyCategory.isOn = this.category.isOn;

            copyNoteCard.category = copyCategory;
        }

        copyNoteCard.note = copyNote;

        return copyNoteCard;
    }
}
