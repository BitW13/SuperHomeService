import { Component, OnInit, Input } from '@angular/core';
import { NoteCategory } from '../models/noteCategory';
import { NoteService } from '../services/note.service';
import { Note } from '../models/note';

@Component({
  selector: 'app-note-list',
  templateUrl: './note-list.component.html',
  styleUrls: ['./note-list.component.scss']
})
export class NoteListComponent implements OnInit {

  @Input() noteCategory: NoteCategory;
  items: Array<Note>;

  constructor(private service: NoteService) { 
    this.items = new Array<Note>();
  }

  ngOnInit() {
    if(this.noteCategory != null){
      this.loadItems();
    }
  }

  loadItems(){
    this.service.getByNoteCategoryId(this.noteCategory.id).subscribe((data: Note[]) => {
      this.items = data;
    });
  }

}
