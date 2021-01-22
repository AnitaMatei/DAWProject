import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { JwtInterceptor } from './guard/jwt.interceptor';
import { ErrorInterceptor } from './guard/error.interceptor';
import { AppRoutingModule } from './app-routing.module';
import { ProductsComponent } from './component/products/products.component';
import { NavComponent } from './component/nav/nav.component';
import { ComponentsModule } from './component/components.module';
import { DirectivesModule } from './directive/directives.module';
import { PipesModule } from './pipe/pipes.module';

@NgModule({
  declarations: [
    NavComponent,
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    AppRoutingModule,
    ComponentsModule,
    DirectivesModule,
    PipesModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
