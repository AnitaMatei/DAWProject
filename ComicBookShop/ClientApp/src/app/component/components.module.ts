import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { NavComponent } from './nav/nav.component';
import { ProductsComponent } from './products/products.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DirectivesModule } from '../directive/directives.module';
import { CheckoutComponent } from './checkout/checkout.component';
import { PipesModule } from '../pipe/pipes.module';
import { HomeComponent } from './home/home.component';



@NgModule({
  declarations: [
      LoginComponent,
      ProductsComponent,
      HomeComponent,
      CheckoutComponent
  ],
  imports: [
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    PipesModule
  ]
})
export class ComponentsModule { }