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

  @Input() card: NoteCard;

  @Input() categories: NoteCategory[];

  @Output() getModels = new EventEmitter();

  isEditNote: boolean = false;

  saveItemValue: Note;

  constructor(private noteService: NoteService) { }

  ngOnInit() {
  }

  switchingIsEditItem(){
    this.isEditNote = !this.isEditNote;
  }

  edit() {
    this.switchingIsEditItem();
    
    this.saveItemValue = this.getCopy(this.card.note);
  }

  save() {

    this.saveItemValue = null;

    this.switchingIsEditItem();
    
    this.noteService.put(this.card.note).subscribe((data) => {
    });
  }

  cancel() {

    this.card.note = this.getCopy(this.saveItemValue);
    
    this.saveItemValue = null;

    this.switchingIsEditItem();
  }

  delete() {
    
    this.noteService.delete(this.card.note).subscribe((data) => {
      this.getModels.emit();
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
