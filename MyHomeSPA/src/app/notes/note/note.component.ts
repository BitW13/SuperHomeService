import { Component, OnInit } from '@angular/core';
import { NoteModel } from '../models/noteModel';
import { NoteModelService } from '../services/note-model.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  items: Array<NoteModel>;

  constructor(private service: NoteModelService) { }

  ngOnInit() {
    this.loadItems();
  }

  loadItems(){
    this.service.getItems().subscribe((data: NoteModel[]) => {
      this.items = data;
    });
  }

}
