import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { TaskCategory } from '../models/taskCategory';

@Injectable({
  providedIn: 'root'
})
export class TaskCategoryService {

  private url = 'https://taskplannerservicewebapi.azurewebsites.net/api/taskcategory/';

  constructor(private http: HttpClient) { }

  getItems() {
    return this.http.get<{data: TaskCategory[]}>(this.url)
      .pipe(map(res => res));
  }

  post(item: TaskCategory) {
    return this.http.post<{data: TaskCategory}>(this.url, item)
      .pipe(map(res => res));
  }

  put(item: TaskCategory) {
    return this.http.put<{data: TaskCategory}>(this.url + item.id, item)
      .pipe(map(res => res));
  }

  delete(item: TaskCategory) {
    return this.http.delete<{data: TaskCategory}>(this.url + item.id)
      .pipe(map(res => res));
  }
}
