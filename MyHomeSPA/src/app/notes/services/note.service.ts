import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Note } from '../models/note';
import { map } from 'rxjs/operators';
import { NoteCard } from '../models/noteCard';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  private url = "https://noteservicewebapi.azurewebsites.net/api/note/";
  
  constructor(private http: HttpClient) { }

  getCards() {
    return this.http.get<{data: NoteCard[]}>(this.url)
      .pipe(map(res=> res));
  }

  getCard() {
    return this.http.get<{data: NoteCard}>(this.url)
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

  delete(item: Note) {
    return this.http.delete<{data: Note}>(this.url + item.id)
      .pipe(map(res=> res));
  }
}
