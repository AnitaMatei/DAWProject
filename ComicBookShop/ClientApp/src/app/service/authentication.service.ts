import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';


@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private jwtTokenSubject: BehaviorSubject<String>;
    public jwtToken: Observable<String>;

    constructor(private http: HttpClient) {
        this.jwtTokenSubject = new BehaviorSubject<String>(localStorage.getItem('jwtToken'));
        this.jwtToken = this.jwtTokenSubject.asObservable();
    }

    currentUserValue(): any {
        return this.jwtTokenSubject.value;
    }

    login(username, password) {
        return this.http.post<any>(`${environment.API_URL}auth/login`, { "Username": username, "Password": password })
            .pipe(map(jwtToken => {
                localStorage.setItem('jwtToken',jwtToken["jwtToken"]);
                this.jwtTokenSubject.next(jwtToken);
                return jwtToken;
            }));
    }

    register(username, password, email) {
        return this.http.post<any>(`${environment.API_URL}auth/register`, { username, password, email })
            .pipe(map(jwtToken => {
                localStorage.setItem('jwtToken', jwtToken["jwtToken"]);
                this.jwtTokenSubject.next(jwtToken);
                return jwtToken;
            }));
    }

    logout() {
        // remove user from local storage and set current user to null
        localStorage.removeItem('jwtToken');
        this.jwtTokenSubject.next(null);
    }
}