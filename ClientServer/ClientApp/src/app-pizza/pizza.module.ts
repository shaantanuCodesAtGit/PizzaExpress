import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';

import { MatButtonModule } from "@angular/material/button";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { MatCardModule } from "@angular/material/card";
import { MatExpansionModule } from "@angular/material/expansion";
import { MatButtonToggleModule } from "@angular/material/button-toggle";
import { MatGridListModule } from "@angular/material/grid-list";
import { MatListModule } from "@angular/material/list";

import { ToastrModule, ToastContainerModule, ToastrService } from 'ngx-toastr';

import { PizzaService } from '../app/service/pizza.service';
import { IngredientService } from '../app/service/ingredient.service';
import { SelectedPizzaComponent } from "../app/pizza/placeOrder/selectedPizza.component"
import { AuthInterceptor } from "../app/http/auth-interceptor";


@NgModule({
  declarations: [
    SelectedPizzaComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forChild([
      { path: '', component: SelectedPizzaComponent }
    ]),

    MatButtonModule,
    MatCheckboxModule,
    MatCardModule,
    MatExpansionModule,
    MatButtonToggleModule,
    MatGridListModule,
    MatListModule,

  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true,
    deps: [ToastrService]
  },PizzaService, IngredientService]
})
export class PizzaModule { }
