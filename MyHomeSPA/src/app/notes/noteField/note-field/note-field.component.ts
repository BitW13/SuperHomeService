import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Note } from '../../models/note';
import { NoteService } from '../../services/note.service';

@Component({
  selector: 'app-note-field',
  templateUrl: './note-field.component.html',
  styleUrls: ['./note-field.component.scss']
})
export class NoteFieldComponent implements OnInit {

  isNewNote: boolean = true;

  note: Note = new Note();

  @Input() noteCategories;

  @Input() noteModels;

  @Output() loadItems = new EventEmitter<any>();

  constructor(private service: NoteService) { }

  ngOnInit() {
  }

  addNote(item: Note){
    this.service.post(item).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  editNote(item: Note){
    this.service.put(item).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  deleteNote(id: number){
    this.service.delete(id).subscribe((data) => {
      this.loadItems.emit();
    });
  }
}
