import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { NoteCategory } from '../models/noteCategory';

@Injectable({
  providedIn: 'root'
})
export class NoteCategoryService {

  private url = "https://noteservicewebapi.azurewebsites.net/api/note/";
  
  constructor(private http: HttpClient) { }

  getItems() {
    return this.http.get<{data: NoteCategory[]}>(this.url)
      .pipe(map(res=> res));
  }

  getByNoteCategoryId(noteCategoryId: number) {
    return this.http.get<{data: NoteCategory[]}>(this.url + 'getbynotecategoryid/' + noteCategoryId)
      .pipe(map(res=> res));
  }

  post(item: NoteCategory) {
    return this.http.post<{data: NoteCategory}>(this.url, item)
      .pipe(map(res=> res));
  }

  put(item: NoteCategory) {
    return this.http.put<{data: NoteCategory}>(this.url + item.id, item)
      .pipe(map(res=> res));
  }

  delete(id: number) {
    return this.http.delete<{data: NoteCategory}>(this.url + id)
      .pipe(map(res=> res));
  }
}
