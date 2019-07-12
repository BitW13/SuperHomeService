import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { ShoppingCategory } from '../models/shoppingCategory';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCategoryService {

  private url = 'https://shoppingplannerservicewebapi.azurewebsites.net/api/shoppingCategory/';

  constructor(private http: HttpClient) { }

  getItems() {
    return this.http.get<{data: ShoppingCategory[]}>(this.url)
      .pipe(map(res => res));
  }

  post(item: ShoppingCategory) {
    return this.http.post<{data: ShoppingCategory}>(this.url, item)
      .pipe(map(res => res));
  }

  put(item: ShoppingCategory) {
    return this.http.put<{data: ShoppingCategory}>(this.url + item.id, item)
      .pipe(map(res => res));
  }

  delete(item: ShoppingCategory) {
    return this.http.delete<{data: ShoppingCategory}>(this.url + item.id)
      .pipe(map(res => res));
  }
}
