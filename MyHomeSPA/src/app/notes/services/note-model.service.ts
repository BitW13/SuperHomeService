import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NoteModelService {

  private url = "https://noteservicewebapi20190616040752.azurewebsites.net/api/notemodel/";
  
  constructor(private http: HttpClient) { }

  getItems(){
    return this.http.get(this.url);
  }

  getItem(id: number){
    return this.http.get(this.url + id);
  }
}
