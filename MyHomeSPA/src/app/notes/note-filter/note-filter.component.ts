import { Component, OnInit, ViewChild, TemplateRef, Input } from '@angular/core';
import { NoteCategory } from '../models/noteCategory';
import { NoteCategoryService } from '../services/note-category.service';

@Component({
  selector: 'app-note-filter',
  templateUrl: './note-filter.component.html',
  styleUrls: ['./note-filter.component.scss']
})
export class NoteFilterComponent implements OnInit {

  @ViewChild('readTemplate', {static: false}) readTemplate: TemplateRef<any>;
  @ViewChild('editTemplate', {static: false}) editTemplate: TemplateRef<any>;

  items: Array<NoteCategory>;
  editItem: NoteCategory;
  isNewRecord: boolean;
  statusMessage: string;

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

  loadTemplate(item: NoteCategory) {
    if (this.editItem && this.editItem.id == item.id) {
        return this.editTemplate;
    } else {
        return this.readTemplate;
    }
  }

  add(item: NoteCategory){
    this.editItem = new NoteCategory();
    this.items.push(this.editItem);
    this.isNewRecord = true;
  }

  edit(item: NoteCategory){
    this.editItem = item;
  }

  save() {
    if (this.isNewRecord) {
      this.service.createItem(this.editItem).subscribe(data => {
        this.statusMessage = 'Категория добавлена',
        this.loadItems();
      });
      this.isNewRecord = false;
      this.editItem = null;
    } else {
      this.service.updateItem(this.editItem).subscribe(data => {
        this.statusMessage = 'Категория обновлена',
        this.loadItems();
      });
      this.editItem = null;
    }
  }

  cancel() {
    if (this.isNewRecord) {
        this.items.pop();
        this.isNewRecord = false;
    }
    this.editItem = null;
  }

  delete(item: NoteCategory) {
    this.service.deleteItem(item.id).subscribe(data => {
      this.statusMessage = 'Категория удалена',
      this.loadItems();
    });
  }

}
