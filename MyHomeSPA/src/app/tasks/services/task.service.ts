import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { TaskCard } from '../models/taskCard';
import { Task } from '../models/task';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private url ="https://localhost:44369/api/task/";

  constructor(private http:HttpClient) { }

  getCards() {
    return this.http.get<{data: TaskCard[]}>(this.url)
      .pipe(map(res=> res));
  }

  getCard() {
    return this.http.get<{data: TaskCard}>(this.url)
      .pipe(map(res=> res));
  }

  post(item: Task) {
    return this.http.post<{data: Task}>(this.url, item)
      .pipe(map(res=> res));
  }

  put(item: Task) {
    return this.http.put<{data: Task}>(this.url + item.id, item)
      .pipe(map(res=> res));
  }

  delete(item: Task) {
    return this.http.delete<{data: Task}>(this.url + item.id)
      .pipe(map(res=> res));
  }
}
