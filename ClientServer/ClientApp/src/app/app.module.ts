import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatButtonModule } from "@angular/material/button";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { MatCardModule } from "@angular/material/card";
import { MatExpansionModule } from "@angular/material/expansion";
import { MatButtonToggleModule } from "@angular/material/button-toggle";
import { MatGridListModule } from "@angular/material/grid-list";

import { ToastrModule, ToastContainerModule, ToastrService } from 'ngx-toastr';

import { PizzaModule } from "../app-pizza/pizza.module";

import { AppComponent } from './app.component';


import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { PizzaComponent } from './pizza/pizza.component';
import { PizzaListComponent } from './pizza/pizzaList/pizzaList.component';
import { PizzaCardComponent } from './pizza/pizzaList/pizzaCard/pizzaCard.component';

import { PizzaService } from './service/pizza.service';
import { IngredientService } from './service/ingredient.service';
import { AuthInterceptor } from "./http/auth-interceptor";


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,

    PizzaComponent,
    PizzaListComponent,
    PizzaCardComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,

    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'pizza', component: PizzaComponent },
      { path: 'pizza/select/:name', loadChildren: () => PizzaModule }
    ]),

    MatButtonModule,
    MatCheckboxModule,
    MatCardModule,
    MatExpansionModule,
    MatButtonToggleModule,
    MatGridListModule,

    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-center',
      preventDuplicates: true
    }),
    ToastContainerModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true,
    deps: [ToastrService]
  }, PizzaService, IngredientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
