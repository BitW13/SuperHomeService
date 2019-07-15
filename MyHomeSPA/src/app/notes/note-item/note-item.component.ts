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

  @Input() noteCard: NoteCard;

  @Input() categories: NoteCategory[];

  @Output() loadItems = new EventEmitter();

  isEditNote: boolean = false;

  saveItemValue: Note;

  constructor(private noteService: NoteService) { }

  ngOnInit() {
  }

  switchingIsEditItem(){
    this.isEditNote = !this.isEditNote;
  }

  editNote() {
    this.switchingIsEditItem();
    
    this.saveItemValue = this.getCopy(this.noteCard.note);
  }

  saveNote() {

    this.saveItemValue = null;

    this.switchingIsEditItem();
    
    this.noteService.put(this.noteCard.note).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  cancel() {
    this.noteCard.note = this.getCopy(this.saveItemValue);
    this.saveItemValue = null;

    this.switchingIsEditItem();
  }

  deleteNote() {
    this.noteService.delete(this.noteCard.note).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  getCopy(item: Note): Note {

    let copy = new Note();

    copy.id = item.id;
    copy.name = item.name;
    copy.text = item.text;
    copy.lastChange = item.lastChange;
    copy.noteCategoryId = item.noteCategoryId;  

    return copy;
  }
}
