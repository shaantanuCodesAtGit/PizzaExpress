import { Injectable, Inject } from "@angular/core";

import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs/Observable";

import { ICheese, ISauce, ITopping, IIngredient } from "../model/ingredient";

@Injectable()
export class IngredientService {

  constructor(private readonly http: HttpClient, @Inject("BASE_URL") private baseUrl: string) {

  }

  getIngredient(): Observable<IIngredient> {
    return this.http.get<IIngredient>(this.baseUrl + '/api/ingredient');
  }

  //getCheeses(): Observable<ICheese[]> {
  //  return this.http.get<ICheese[]>(this.baseUrl + '/api/ingredient/cheese');
  //}

  //getTopping(): Observable<ITopping[]> {
  //  return this.http.get<ITopping[]>(this.baseUrl + '/api/ingredient/topping');
  //}

  //getSauce(): Observable<ISauce[]> {
  //  return this.http.get<ISauce[]>(this.baseUrl + '/api/ingredient/sauce');
}
