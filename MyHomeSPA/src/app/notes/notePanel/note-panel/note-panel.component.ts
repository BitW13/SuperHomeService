import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { NoteCategory } from '../../models/noteCategory';
import { NoteCategoryService } from '../../services/note-category.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-note-panel',
  templateUrl: './note-panel.component.html',
  styleUrls: ['./note-panel.component.scss']
})
export class NotePanelComponent implements OnInit {

  isNewNoteCategory: boolean = true;

  noteCategory: NoteCategory = new NoteCategory();

  @Input() noteCategories: Observable<any>;

  @Output() loadItems = new EventEmitter<any>();

  constructor(private service: NoteCategoryService) { }

  ngOnInit() {
  }

  addNoteCategory(item: NoteCategory){
    this.service.post(item).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  editNoteCategory(item: NoteCategory){
    this.service.put(item).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  deleteNoteCategory(id: number){
    this.service.delete(id).subscribe((data) => {
      this.loadItems.emit();
    });
  }
}
