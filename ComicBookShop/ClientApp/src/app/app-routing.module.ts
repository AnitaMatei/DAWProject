import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './component/login/login.component';
import { ProductsComponent } from './component/products/products.component';
import { AuthGuard } from './guard/auth.guard';
import { CheckoutComponent } from './component/checkout/checkout.component';
import { HomeComponent } from './component/home/home.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent},
  {path: 'checkout', component: CheckoutComponent, canActivate: [AuthGuard]},
  {path: '',component:HomeComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
