import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NoteCategory } from '../models/noteCategory';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NoteCategoryService {

  private url = 'https://noteservicewebapp.azurewebsites.net/api/notecategory/';

  constructor(private http: HttpClient) { }

  getItems(): Observable<NoteCategory[]> {
    return this.http.get<NoteCategory[]>(this.url);
  }

  getItem(item: NoteCategory): Observable<NoteCategory>  {
    return this.http.get<NoteCategory>(this.url + item.id);
  }

  post(item: NoteCategory): Observable<NoteCategory> {
    return this.http.post<NoteCategory>(this.url, item);
  }

  put(item: NoteCategory): Observable<NoteCategory> {
    return this.http.put<NoteCategory>(this.url + item.id, item);
  }

  delete(item: NoteCategory): Observable<NoteCategory> {
    return this.http.delete<NoteCategory>(this.url + item.id);
  }
}
