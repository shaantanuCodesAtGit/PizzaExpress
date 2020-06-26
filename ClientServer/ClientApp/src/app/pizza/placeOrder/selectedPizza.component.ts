import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { IPizza } from "../../model/IPizza";
import { ICheese, ITopping, ISauce, IIngredient } from "../../model/ingredient";
import { IngredientService } from "../../service/ingredient.service";
import { PizzaService } from "../../service/pizza.service";


@Component({
  selector: 'selected-pizza',
  templateUrl: './selectedPizza.component.html',
  styleUrls: ['./selectedPizza.component.css']
})
export class SelectedPizzaComponent implements OnInit {

  constructor(private ingredientService: IngredientService,
    private pizzaService: PizzaService,
    private route: ActivatedRoute,
    private toasterService: ToastrService) {

    this.ingredientService.getIngredient().subscribe(i => {
      this.ingredients = i;

      this.route.paramMap.subscribe(params => {

        this.pizzaService.getHousePizza(params.get('name')).subscribe(pizzaData => {
          this.pizza = pizzaData;

          // update the ingredients if they are selected in pizza.

          this.ingredients.cheeses.map((cheese) => cheese.isSelected = pizzaData.cheeses.filter((y) => y.name === cheese.name).length > 0);

          this.ingredients.sauces.map((sauce) => sauce.isSelected = pizzaData.sauces.filter((y) => y.name === sauce.name).length > 0);

          this.ingredients.toppings.map((topping) => topping.isSelected = pizzaData.toppings.filter((y) => y.name === topping.name).length > 0);

        });
      });
    });
  }

  ngOnInit(): void {

  }

  pizza: IPizza;

  ingredients: IIngredient;

  confirm() {
    this.pizzaService.order(this.pizza).subscribe((x) => this.toasterService.success(`Successfully submitted your order with Id #${x.id}.`));
  }

  updateCheese(ev, data: ICheese) {
    if (ev.selected) {
      // Pushing the object into array
      this.pizza.cheeses.push(data);
      this.pizza.totalPrice += data.price;
    } else {

      // remove from list
      this.pizza.cheeses = this.pizza.cheeses.filter((x) => x.name !== data.name);
      this.pizza.totalPrice -= data.price;
    }
  }

  updateTopping(ev, data: ITopping) {
    if (ev.selected) {
      // Pushing the object into array
      this.pizza.toppings.push(data);
      this.pizza.totalPrice += data.price;

    } else {

      // remove from list
      this.pizza.toppings = this.pizza.toppings.filter((x) => x.name !== data.name);
      this.pizza.totalPrice -= data.price;
    }

    this.pizza.isVeg = this.isVeg();
  }

  updateSauce(ev, data: ISauce) {
    if (ev.selected) {
      // Pushing the object into array
      this.pizza.sauces.push(data);
      this.pizza.totalPrice += data.price;
    } else {

      // remove from list
      this.pizza.sauces = this.pizza.sauces.filter((x) => x.name !== data.name);
      this.pizza.totalPrice -= data.price;
    }
  }

  private isVeg(): boolean {
    return this.pizza.toppings.filter((x) => !x.isVeg).length === 0;
  }
}
