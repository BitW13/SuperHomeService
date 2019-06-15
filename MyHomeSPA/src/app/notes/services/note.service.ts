import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NoteModel } from '../models/noteModel';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  private url = "https://superhomeservicenoteservice.azurewebsites.net/api/note/";
  
  constructor(private http: HttpClient) { }

  getItems(){
    return this.http.get(this.url);
  }

  getItem(id: number){
    return this.http.get(this.url + id);
  }

  createItem(item: NoteModel){
      return this.http.post(this.url, item); 
  }

  updateItem(item: NoteModel) {
    return this.http.put(this.url + item.note.id, item);
  }
  
  deleteItem(id: number){
    return this.http.delete(this.url + id);
  }
}
