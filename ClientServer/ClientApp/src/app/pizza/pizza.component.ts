import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { IPizza } from "../model/IPizza";
import { IIngredient } from "../model/ingredient";

import { IngredientService } from "../service/ingredient.service";
import { PizzaService } from "../service/pizza.service";

@Component({
  selector: 'pizza',
  templateUrl: './pizza.component.html',
})
export class PizzaComponent implements OnInit {

  constructor(private ingredientService: IngredientService, private pizzaService: PizzaService) {
   
  }

  ngOnInit() {
    this.ingredientService.getIngredient().subscribe(x => {
      this.ingredients = x;
    });

    this.pizzaService.getHousePizzas().subscribe(x => {
      this.pizzaList = x;
    });
  }

  ingredients: IIngredient;

  pizzaList: IPizza[];
}
