import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NoteService } from '../services/note.service';
import { NoteCard } from '../models/noteCard';
import { Note } from '../models/note';
import { NoteCategory } from '../models/noteCategory';

@Component({
  selector: 'app-note-item',
  templateUrl: './note-item.component.html',
  styleUrls: ['./note-item.component.scss']
})
export class NoteItemComponent implements OnInit {

  @Input() noteCard;

  @Input() categories;

  @Output() loadItems = new EventEmitter();

  isEditNote: boolean = false;

  saveForCard: NoteCard;

  constructor(private noteService: NoteService) { }

  ngOnInit() {
  }

  editNote() {
    const copyNote = new Note();

    copyNote.id = this.noteCard.note.id;
    copyNote.name = this.noteCard.note.name;
    copyNote.text = this.noteCard.note.text;
    copyNote.lastChange = this.noteCard.note.lastChange;
    copyNote.noteCategoryId = this.noteCard.note.noteCategoryId;

    const copyCategory = new NoteCategory();
    const copyNoteCard = new NoteCard();

    if (this.noteCard.category) {
      copyCategory.id = this.noteCard.category.id;
      copyCategory.name = this.noteCard.category.name;
      copyCategory.color = this.noteCard.category.color;
      copyCategory.isOn = this.noteCard.category.isOn;
      copyNoteCard.noteCategory = copyCategory;
    }

    copyNoteCard.note = copyNote;

    this.saveForCard = copyNoteCard;

    this.isEditNote = !this.isEditNote;
  }

  saveNote() {

    this.saveForCard = null;

    this.isEditNote = !this.isEditNote;
    
    this.noteService.put(this.noteCard.note).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  cancel() {

    this.noteCard = this.saveForCard;

    this.isEditNote = !this.isEditNote;
  }

  deleteNote() {
    this.noteService.delete(this.noteCard.note).subscribe((data) => {
      this.loadItems.emit();
    });
  }
}
