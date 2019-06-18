import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NoteModel } from '../models/noteModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NoteModelService {

  private url = "https://noteservicewebapi20190616040752.azurewebsites.net/api/notemodel/";
  
  constructor(private http: HttpClient) { }

  getItems(): Observable<NoteModel[]> {
    return this.http.get<NoteModel[]>(this.url);
  }

  getItem(id: number): Observable<NoteModel> {
    return this.http.get<NoteModel>(this.url + id);
  }
}