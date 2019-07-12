import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ShoppingCard } from '../models/shoppingCard';
import { Purchase } from '../models/purchase';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {

  private url = "https://shoppingplannerservicewebapi.azurewebsites.net/api/purchase/";
  
  constructor(private http: HttpClient) { }

  getCards() {
    return this.http.get<{data: ShoppingCard[]}>(this.url)
      .pipe(map(res=> res));
  }

  getCard() {
    return this.http.get<{data: ShoppingCard}>(this.url)
      .pipe(map(res=> res));
  }

  post(item: Purchase) {
    return this.http.post<{data: Purchase}>(this.url, item)
      .pipe(map(res=> res));
  }

  put(item: Purchase) {
    return this.http.put<{data: Purchase}>(this.url + item.id, item)
      .pipe(map(res=> res));
  }

  delete(item: Purchase) {
    return this.http.delete<{data: Purchase}>(this.url + item.id)
      .pipe(map(res=> res));
  }
}
