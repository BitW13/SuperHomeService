import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NoteCategory } from '../models/noteCategory';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NoteCategoryService {

  private url = "https://noteservicewebapi20190616040752.azurewebsites.net/api/notecategory/";
  
  constructor(private http: HttpClient) { }

  getItems(): Observable<NoteCategory[]> {
    return this.http.get<NoteCategory[]>(this.url);
  }

  createItem(item: NoteCategory): NoteCategory {
    this.http.post(this.url, item).subscribe((data: NoteCategory) =>{
      item = data;
    });
    return item
  }

  updateItem(item: NoteCategory): NoteCategory {
    this.http.put(this.url + item.id, item).subscribe((data: NoteCategory) =>{
      item = data;
    });
    return item;
  }
  
  deleteItem(id: number): NoteCategory {
    let item;
    this.http.delete(this.url + id).subscribe((data: NoteCategory) =>{
      item = data;
    });
    return item;
  }
}
