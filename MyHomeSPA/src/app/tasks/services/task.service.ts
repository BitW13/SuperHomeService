import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { TaskCard } from '../models/taskCard';
import { Task } from '../models/task';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private url ="https://localhost:44369/api/task/";

  constructor(private http:HttpClient) { }

  getCards(): Observable<TaskCard[]> {
    return this.http.get<TaskCard[]>(this.url);
  }

  getCard(item: TaskCard): Observable<TaskCard>  {
    return this.http.get<TaskCard>(this.url + item.task.id);
  }

  post(item: Task): Observable<TaskCard> {
    return this.http.post<TaskCard>(this.url, item);
  }

  put(item: Task): Observable<TaskCard> {
    return this.http.put<TaskCard>(this.url + item.id, item);
  }

  delete(item: Task): Observable<TaskCard> {
    return this.http.delete<TaskCard>(this.url + item.id);
  }
}
