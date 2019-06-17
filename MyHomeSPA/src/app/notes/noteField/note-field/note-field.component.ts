import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Note } from '../../models/note';
import { NoteService } from '../../services/note.service';
import { NoteCategory } from '../../models/noteCategory';
import { NoteModel } from '../../models/noteModel';

@Component({
  selector: 'app-note-field',
  templateUrl: './note-field.component.html',
  styleUrls: ['./note-field.component.scss']
})
export class NoteFieldComponent implements OnInit {

  @Input() notesCategories: Array<NoteCategory>;

  @Input() noteModels: Array<NoteModel>;

  @Output() onReLoadItems = new EventEmitter<any>();

  isNewNote: boolean;

  editNoteModel: NoteModel;

  constructor(private noteService: NoteService) { }

  ngOnInit() {
  }

  loadNoteModels(){
    this.onReLoadItems.emit();
  }

  switchingIsNewNote(){
    this.isNewNote = !this.isNewNote;
  }

  addNewNote(){
    this.switchingIsNewNote();
    this.loadNoteModels();
  }

  edit(noteModel: NoteModel){
    noteModel.isChange = !noteModel.isChange;
  }

  save(noteModel: NoteModel){
    noteModel.isChange = !noteModel.isChange;
    this.noteService.updateItem(noteModel.note).subscribe((data: Note) =>{
      this.loadNoteModels();
    });
  }

  delete(note: Note){
    this.noteService.deleteItem(note.id).subscribe((data: Note) =>{
      this.loadNoteModels();
    })
  }
}
