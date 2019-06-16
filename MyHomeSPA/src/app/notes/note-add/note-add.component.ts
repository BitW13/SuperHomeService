import { Component, EventEmitter, Input, Output, OnInit} from '@angular/core';
import { Note } from '../models/note';
import { NoteCategory } from '../models/noteCategory';
import { NoteService } from '../services/note.service';
import { NoteCategoryService } from '../services/note-category.service';

@Component({
  selector: 'app-note-add',
  templateUrl: './note-add.component.html',
  styleUrls: ['./note-add.component.scss']
})
export class NoteAddComponent implements OnInit {

  note: Note;
  noteCategoryId: number;

  @Output() addNewNote = new EventEmitter<Note>();

  items: Array<NoteCategory>;

  constructor(private noteService: NoteService, private noteCategoryService: NoteCategoryService) { }

  ngOnInit() {
    this.loadItems();
  }

  loadItems(){
    this.note = new Note();
    this.noteCategoryService.getItems().subscribe((data: NoteCategory[]) => {
      this.items = data;
    })
  }

  save(){
    this.addNewNote.emit(this.note);
  }
}
