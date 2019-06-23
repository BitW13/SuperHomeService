import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NoteCategory } from '../models/noteCategory';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NoteCategoryService {

  private url = "https://noteservicewebapi20190616040752.azurewebsites.net/api/notecategory/";

  constructor(private http: HttpClient) { }

  getItems() {
    return this.http.get<{data: NoteCategory[]}>(this.url)
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
