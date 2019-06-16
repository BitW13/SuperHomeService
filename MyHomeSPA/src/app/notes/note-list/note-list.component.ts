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
  ifItemMappingIsEnabled: boolean;

  constructor(private service: NoteService) { 
    this.items = new Array<Note>();
  }

  ngOnInit() {
    this.loadItems();
  }

  loadItems(){
    this.service.getByNoteCategoryId(this.noteCategory.id).subscribe((data: Note[]) => {
      this.items = data;
    });
  }

  itemMappingIsEnabled(){
    this.ifItemMappingIsEnabled = !this.ifItemMappingIsEnabled;
  }
}
