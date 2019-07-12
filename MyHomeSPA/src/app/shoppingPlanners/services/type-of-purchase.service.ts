import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { TypeOfPurchase } from '../models/typeOfPurchase';

@Injectable({
  providedIn: 'root'
})
export class TypeOfPurchaseService {

  private url = 'https://shoppingplannerservicewebapi.azurewebsites.net/api/typeOfPurchase/';

  constructor(private http: HttpClient) { }

  getItems() {
    return this.http.get<{data: TypeOfPurchase[]}>(this.url)
      .pipe(map(res => res));
  }

  post(item: TypeOfPurchase) {
    return this.http.post<{data: TypeOfPurchase}>(this.url, item)
      .pipe(map(res => res));
  }

  put(item: TypeOfPurchase) {
    return this.http.put<{data: TypeOfPurchase}>(this.url + item.id, item)
      .pipe(map(res => res));
  }

  delete(item: TypeOfPurchase) {
    return this.http.delete<{data: TypeOfPurchase}>(this.url + item.id)
      .pipe(map(res => res));
  }
}
