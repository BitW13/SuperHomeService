import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NoteCategory } from '../models/noteCategory';

@Injectable({
  providedIn: 'root'
})
export class NoteCategoryService {

  private url = "https://shsnoteservice.azurewebsites.net/api/notecategory/";
  
  constructor(private http: HttpClient) { }

  getItems(){
    return this.http.get(this.url);
  }

  createItem(item: NoteCategory){
      return this.http.post(this.url, item); 
  }

  updateItem(item: NoteCategory) {
    return this.http.put(this.url + item.id, item);
  }
  
  deleteItem(id: number){
    return this.http.delete(this.url + id);
  }
}
