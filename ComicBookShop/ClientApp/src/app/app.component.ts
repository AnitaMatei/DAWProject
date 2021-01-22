import { Component } from '@angular/core';
import { Router } from '@angular/router';
import {AuthenticationService} from './service/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  jwtToken: String;

  constructor(
      private router: Router,
      private authenticationService: AuthenticationService
  ) {
      this.authenticationService.jwtToken.subscribe(x => this.jwtToken = x);
  }

}
