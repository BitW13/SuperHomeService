import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Note } from '../models/note';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  private url = "https://noteservicewebapi20190616040752.azurewebsites.net/api/note/";
  
  constructor(private http: HttpClient) { }

  getByNoteCategoryId(noteCategoryId: number): Note[] {
    let  items;
    this.http.get(this.url + 'getbynotecategoryid/' + noteCategoryId).subscribe((data: Note[]) =>{
      items = data;
    });
    return items;
  }

  createItem(item: Note): Note {
    this.http.post(this.url, item).subscribe((data: Note) =>{
      item = data;
    });
    return item
  }

  updateItem(item: Note): Note {
    this.http.put(this.url + item.id, item).subscribe((data: Note) =>{
      item = data;
    });
    return item;
  }
  
  deleteItem(id: number): Note {
    let item;
    this.http.delete(this.url + id).subscribe((data: Note) =>{
      item = data;
    });
    return item;
  }
}
