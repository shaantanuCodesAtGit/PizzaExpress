import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs/Observable";

import { IPizza, IOrder } from "../model/IPizza";

@Injectable()
export class PizzaService {

  constructor(private readonly http: HttpClient, @Inject("BASE_URL") private baseUrl: string) {

  }

  getHousePizzas(): Observable<IPizza[]> {
    return this.http.get<IPizza[]>(this.baseUrl + '/api/pizza');
  }

  getHousePizza(name: string): Observable<IPizza> {
    return this.http.get<IPizza>(this.baseUrl + '/api/pizza/' + name);
  }

  order(pizza: IPizza): Observable<IOrder> {
    return this.http.post<IOrder>(this.baseUrl + '/api/order', pizza);
  }
}
