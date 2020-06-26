import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { IPizza } from "../../../model/IPizza";
import { ICheese, ITopping, ISauce, IIngredient } from "../../../model/ingredient";

@Component({
  selector: 'pizza-card',
  templateUrl: './pizzaCard.component.html',
  styleUrls: ['./pizzaCard.component.css']
})
export class PizzaCardComponent implements OnInit {

  ngOnInit(): void {
    this.cheeses = [...this.pizza.cheeses];

    this.sauces = [...this.pizza.sauces];

    this.toppings = [...this.pizza.toppings];

    this.ingredientList = {
      ...this.ingredients,
      cheeses: [...this.ingredients.cheeses],
      sauces: [...this.ingredients.sauces],
      toppings: [...this.ingredients.toppings]
    };

    this.ingredientList.cheeses.map((x) => x.isSelected = this.cheeses.filter((y) => y.name === x.name).length > 0);

    this.ingredientList.sauces.map((x) => x.isSelected = this.sauces.filter((y) => y.name === x.name).length > 0);

    this.ingredientList.toppings.map((x) => x.isSelected = this.toppings.filter((y) => y.name === x.name).length > 0);
  }


  @Input()
  pizza: IPizza;

  @Input()
  ingredients: IIngredient;

  @Output()
  confirmOrder = new EventEmitter();

  ingredientList: IIngredient;

  cheeses: ICheese[];

  sauces: ISauce[];

  toppings: ITopping[];

  price: number;

  confirm() {
    this.confirmOrder.emit(this.pizza);
  }

  updateCheese(ev, data: ICheese) {
    if (ev.checked) {
      // Pushing the object into array
      this.cheeses.push(data);
      this.pizza.totalPrice += data.price;
    } else {

      // remove from list
      this.cheeses = this.cheeses.filter((x) => x.name === data.name);
      this.pizza.totalPrice -= data.price;
    }
  }

  updateTopping(ev, data: ITopping) {
    if (ev.checked) {
      // Pushing the object into array
      this.toppings.push(data);
      this.pizza.totalPrice += data.price;
    } else {

      // remove from list
      this.toppings = this.toppings.filter((x) => x.name === data.name);
      this.pizza.totalPrice -= data.price;
    }
  }

  updateSauce(ev, data: ISauce) {
    if (ev.checked) {
      // Pushing the object into array
      this.sauces.push(data);
      this.pizza.totalPrice += data.price;
    } else {

      // remove from list
      this.sauces = this.sauces.filter((x) => x.name === data.name);
      this.pizza.totalPrice -= data.price;
    }
  }

  isChecked(type: string, data: string): boolean {
    if (type === "topping") {
      return this.toppings.filter((x) => x.name === data).length > 0;
    } else if (type === "sauce") {
      return this.sauces.filter((x) => x.name === data).length > 0;
    } else {
      return this.cheeses.filter((x) => x.name === data).length > 0;
    }
  }
}
