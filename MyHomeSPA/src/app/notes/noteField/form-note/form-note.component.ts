import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NoteCategory } from '../../models/noteCategory';
import { Note } from '../../models/note';

@Component({
  selector: 'app-form-note',
  templateUrl: './form-note.component.html',
  styleUrls: ['./form-note.component.scss']
})
export class FormNoteComponent implements OnInit {

  saveNoteCategory: Note;

  @Input() noteCategories: NoteCategory[];

  @Input() newNote: Note;

  @Input() isNewNote: boolean;

  @Output() addNote = new EventEmitter<Note>();

  constructor() { }

  ngOnInit() {
    this.saveNoteCategory = this.newNote;
    this.clear();
  }

  save(){
    this.addNote.emit(this.newNote);
  }

  clear(){
    if(this.isNewNote){
      this.newNote = new Note();
    }else{
      this.newNote = this.saveNoteCategory;
    }
  }
}
