import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Note } from '../models/note';
import { NoteCard } from '../models/noteCard';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  private url = "https://noteservicewebapp.azurewebsites.net/api/note/";
  
  constructor(private http: HttpClient) { }

  getCards(): Observable<NoteCard[]> {
    return this.http.get<NoteCard[]>(this.url);
  }

  getCard(item: NoteCard): Observable<NoteCard>  {
    return this.http.get<NoteCard>(this.url + item.note.id);
  }

  post(item: Note): Observable<NoteCard> {
    return this.http.post<NoteCard>(this.url, item);
  }

  put(item: Note): Observable<NoteCard> {
    return this.http.put<NoteCard>(this.url + item.id, item);
  }

  delete(item: Note): Observable<NoteCard> {
    return this.http.delete<NoteCard>(this.url + item.id);
  }
}
