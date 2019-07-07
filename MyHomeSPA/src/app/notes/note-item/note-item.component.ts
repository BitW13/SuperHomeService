import { Component, OnInit, Input } from '@angular/core';
import { Note } from 'src/app/notes/models/note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-note-item',
  templateUrl: './note-item.component.html',
  styleUrls: ['./note-item.component.scss']
})
export class NoteItemComponent implements OnInit {

  @Input() model;

  @Input() categories;

  isEditNote: boolean;

  saveForNote: Note;

  constructor(private noteService: NoteService) { }

  ngOnInit() {
  }

  editNote() {
    this.saveForNote = this.model.note.getCopy();
    this.isEditNote = !this.isEditNote;
  }

  saveNote() {
    this.saveForNote = null;
    this.isEditNote = !this.isEditNote;
    this.noteService.put(this.model.note).subscribe((data) => {
      this.model.note = data;
    });
  }

  cansel(){
    this.model.note = this.saveForNote.getCopy();
    this.isEditNote = !this.isEditNote;
  }

  deleteNote() {
    this.noteService.delete(this.model.note.id).subscribe((data) => {
      this.model.note = data;
    });
  }

}
