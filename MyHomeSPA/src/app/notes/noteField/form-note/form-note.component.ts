import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NoteCategory } from '../../models/noteCategory';
import { Note } from '../../models/note';

@Component({
  selector: 'app-form-note',
  templateUrl: './form-note.component.html',
  styleUrls: ['./form-note.component.scss']
})
export class FormNoteComponent implements OnInit {

  saveNote: Note;

  @Input() isNewNote: boolean;

  @Input() noteCategories: NoteCategory[];

  @Input() note: Note;

  @Output() addNote = new EventEmitter<Note>();

  @Output() editNote = new EventEmitter<Note>();

  constructor() { }

  ngOnInit() {
    this.clear();
  }

  save(){
    if(this.isNewNote){
      this.addNote.emit(this.note);
    }
    else{
      this.editNote.emit(this.note);
    }
  }

  clear(){
    
  }
}
