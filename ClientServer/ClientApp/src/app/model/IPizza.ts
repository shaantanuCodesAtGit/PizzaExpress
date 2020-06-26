import { ICheese, ISauce, ITopping } from "./ingredient";

export interface IPizza {
  name: string;
  image: string;
  description: string;
  isVeg: boolean;
  totalPrice: number;
  size: PizzaSize;
  cheeses: ICheese[];
  sauces: ISauce[];
  toppings: ITopping[];
}

export enum PizzaSize {
  Default = 0,
  Small = 1,
  Medium = 2,
  Large = 3,
}

export interface IOrder {
  id: number;
  pizza: IPizza;
}
