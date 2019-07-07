import { Component, OnInit, Input } from '@angular/core';
import { Note } from 'src/app/notes/models/note';
import { NoteService } from '../services/note.service';
import { NoteCard } from '../models/noteCard';

@Component({
  selector: 'app-note-item',
  templateUrl: './note-item.component.html',
  styleUrls: ['./note-item.component.scss']
})
export class NoteItemComponent implements OnInit {

  @Input() noteCard;

  @Input() categories;

  isEditNote: boolean = false;

  saveForCard: NoteCard;

  constructor(private noteService: NoteService) { }

  ngOnInit() {
    console.log(this.noteCard)
  }

  editNote() {

    this.saveForCard = this.noteCard.note.getCopy();

    this.isEditNote = !this.isEditNote;
  }

  saveNote() {

    this.saveForCard = null;

    this.isEditNote = !this.isEditNote;

    this.noteService.put(this.noteCard.note).subscribe((data) => {
      this.noteCard.note = data;
    });
  }

  cancel() {

    this.noteCard.note = this.saveForCard.getCopy();

    this.isEditNote = !this.isEditNote;
  }

  deleteNote() {
    
    this.noteService.delete(this.noteCard.note.id).subscribe((data) => {
      this.noteCard.note = data;
    });
  }

}
