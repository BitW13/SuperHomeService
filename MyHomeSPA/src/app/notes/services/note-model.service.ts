import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NoteModel } from '../models/noteModel';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NoteModelService {

  private url = "https://noteservicewebapi.azurewebsites.net/api/notemodel/";
  
  constructor(private http: HttpClient) { }

  getModels() {
    return this.http.get<{data: NoteModel[]}>(this.url)
      .pipe(map(res=> res));
  }

  getItem(id: number) {
    return this.http.get<{data: NoteModel}>(this.url)
      .pipe(map(res=> res));
  }
}
