import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Note } from '../models/note';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  private url = "https://noteservicewebapi20190616040752.azurewebsites.net/api/note/";
  
  constructor(private http: HttpClient) { }

  getByNoteCategoryId(noteCategoryId: number) {
    return this.http.get<{data: Note[]}>(this.url + 'getbynotecategoryid/' + noteCategoryId)
      .pipe(map(res=> res));
  }

  post(item: Note) {
    return this.http.post<{data: Note}>(this.url, item)
      .pipe(map(res=> res));
  }

  put(item: Note) {
    return this.http.put<{data: Note}>(this.url + item.id, item)
      .pipe(map(res=> res));
  }

  delete(id: number) {
    return this.http.delete<{data: Note}>(this.url + id)
      .pipe(map(res=> res));
  }
}
