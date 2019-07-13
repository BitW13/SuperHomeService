import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NoteModel } from '../../models/noteModel';

@Component({
  selector: 'app-item-note',
  templateUrl: './item-note.component.html',
  styleUrls: ['./item-note.component.scss']
})
export class ItemNoteComponent implements OnInit {

  isNewNote: boolean = false;

  @Input() noteModel: NoteModel;

  @Output() deleteNote = new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }

  delete(id: number){
    this.deleteNote.emit(id);
  }
}
