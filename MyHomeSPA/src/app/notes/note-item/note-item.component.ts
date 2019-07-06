import { Component, OnInit, Input } from '@angular/core';
import { Note } from 'src/app/models/note';
import { NoteCategory } from 'src/app/models/noteCategory';

@Component({
  selector: 'app-note-item',
  templateUrl: './note-item.component.html',
  styleUrls: ['./note-item.component.scss']
})
export class NoteItemComponent implements OnInit {

  @Input() note: Note;

  @Input() categories: Array<NoteCategory>;

  isEditNote: boolean;

  saveForNote: Note;

  constructor() { }

  ngOnInit() {
  }

  editNote() {
    this.saveForNote = this.note.getCopy();
    this.isEditNote = !this.isEditNote;
  }

  saveNote() {
    this.saveForNote = null;
    this.isEditNote = !this.isEditNote;
  }

  cansel(){
    this.note = this.saveForNote.getCopy();
    this.isEditNote = !this.isEditNote;
  }

  deleteNote() {
    
  }

  changeNoteCategory(){
    
  }

}
