import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NoteService } from '../services/note.service';
import { NoteCard } from '../models/noteCard';
import { SaveData } from '../models/saveData';

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

  saveData: SaveData = new SaveData();

  saveForCard: NoteCard;

  constructor(private noteService: NoteService) { }

  ngOnInit() {
  }

  editNote() {

    this.saveForCard = this.saveData.getCardCopy(this.noteCard);

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

    this.noteCard = this.saveData.getCardCopy(this.saveForCard);

    this.isEditNote = !this.isEditNote;
  }

  deleteNote() {
    console.log(this.noteCard.note);
    this.noteService.delete(this.noteCard.note).subscribe((data) => {
      this.loadItems.emit();
    });
  }
}
