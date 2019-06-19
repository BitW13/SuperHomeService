import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Note } from '../../models/note';
import { NoteService } from '../../services/note.service';
import { NoteCategory } from '../../models/noteCategory';
import { NoteCategoryService } from '../../services/note-category.service';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit {

  note: Note;

  @Input() noteCategories: Array<NoteCategory>;
  
  @Output() addNewNote = new EventEmitter<any>();

  constructor(private noteCategoryservice: NoteCategoryService, private noteService: NoteService) { }

  ngOnInit() {
    this.clear();
  }

  save(){
    this.noteService.createItem(this.note);
    this.addNewNote.emit();
  }

  clear(){
    this.note = new Note();
  }
}
