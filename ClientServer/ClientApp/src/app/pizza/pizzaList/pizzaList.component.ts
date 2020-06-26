import { Component, OnInit, OnChanges, Input, Output, EventEmitter, SimpleChanges } from '@angular/core';

import { IPizza } from "../../model/IPizza";
import { ICheese, ITopping, ISauce, IIngredient } from "../../model/ingredient";

@Component({
  selector: 'pizza-list',
  templateUrl: './pizzaList.component.html',
  styleUrls: ['./pizzaList.component.css']
})
export class PizzaListComponent {

  @Input()
  pizzaList: IPizza[];

  @Input()
  ingredients: IIngredient;

  ingredientList: IIngredient;

}
