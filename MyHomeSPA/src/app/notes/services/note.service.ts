import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Note } from '../models/note';
import { map } from 'rxjs/operators';
import { NoteCard } from '../models/noteCard';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  private url = "https://localhost:44369/api/note";
  
  constructor(private http: HttpClient) { }

  getCards() : Observable<NoteCard[]> {
    return this.http.get(this.url).pipe(map(data=>{
      let cards = data["cards"];
      return cards.map(function(card:NoteCard) {
        return card;
      });
    }));
  }

  getCard(item: NoteCard) {
    return this.http.get<{data: NoteCard}>(this.url + item.note.id)
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
