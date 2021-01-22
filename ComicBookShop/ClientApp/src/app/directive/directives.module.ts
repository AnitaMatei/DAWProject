import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import { LoginDirective } from './login.directive';


@NgModule({
  declarations: [LoginDirective],
  imports: [
    CommonModule
  ],
  exports: [LoginDirective]
})
export class DirectivesModule {
}