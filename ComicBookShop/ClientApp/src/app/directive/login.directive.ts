import {Directive, HostBinding, Input, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../service/authentication.service';

@Directive({
    selector: "[loginDirective]",
    host: {
        '(click)': 'goToLogin()'
    }
})

export class LoginDirective implements OnInit{

    @Input()
    loginDirective: string;

    constructor(
        private router: Router,
        private authService: AuthenticationService) {
    }

    ngOnInit(){

    }

    goToLogin() { 
        this.router.navigate(['login']);
    }
}
