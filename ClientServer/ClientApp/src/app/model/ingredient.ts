interface IBaseIngredient {
  name: string;
  description: string;
  price: number;
  isSelected: boolean;
}

export interface ICheese extends IBaseIngredient {

}

export interface ISauce extends IBaseIngredient {

}

export interface ITopping extends IBaseIngredient {
  isVeg: boolean;
}

export interface IIngredient {
  cheeses: ICheese[];
  sauces: ISauce[];
  toppings: ITopping[];
}
