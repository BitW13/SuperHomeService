import { Component, OnInit } from '@angular/core';
import { NoteCategory } from '../models/noteCategory';
import { NoteCategoryService } from '../services/note-category.service';

@Component({
  selector: 'app-note-filter',
  templateUrl: './note-filter.component.html',
  styleUrls: ['./note-filter.component.scss']
})
export class NoteFilterComponent implements OnInit {

  items: Array<NoteCategory>;

  constructor(private service: NoteCategoryService) { }

  ngOnInit() {
    this.loadItems();
  }

  loadItems(){
    this.service.getItems().subscribe((data: NoteCategory[]) => {
      this.items = data;
    });
  }

}
