import { Component, OnInit } from '@angular/core';
import { NoteCategoryService } from '../services/note-category.service';
import { NoteCategory } from '../models/noteCategory';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  items: Array<NoteCategory>;
  isNewRecord: boolean = false;

  constructor(private service: NoteCategoryService) { 
    this.items = new Array<NoteCategory>();
  }

  ngOnInit() {
    this.loadItems();
  }

  loadItems(){
    this.service.getItems().subscribe((data: NoteCategory[]) => {
      this.items = data;
    });
  }

  onButton(){
    this.isNewRecord = !this.isNewRecord;
  }

}
