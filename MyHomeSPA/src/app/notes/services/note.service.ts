import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Note } from '../models/note';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  private url = "https://noteservicewebapi20190616040752.azurewebsites.net/api/note/";
  
  constructor(private http: HttpClient) { }

  getByNoteCategoryId(noteCategoryId: number){
    return this.http.get(this.url + 'getbynotecategoryid/' + noteCategoryId)
  }

  createItem(item: Note){
    return this.http.post(this.url, item); 
  }

  updateItem(item: Note) {
    return this.http.put(this.url + item.id, item);
  }
  
  deleteItem(id: number){
    return this.http.delete(this.url + id);
  }
}
