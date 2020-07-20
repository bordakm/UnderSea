import { Injectable } from '@angular/core';

import { BehaviorSubject, Observable } from 'rxjs';
import { IUserModel } from '../models/user.model';

import { AuthClient, TokensViewModel, LoginDTO, RegisterDTO } from 'src/app/shared/index';
import { HttpRequest } from '@angular/common/http';
import { CanActivate, Router, ActivatedRouteSnapshot } from '@angular/router';



interface User {
    username: string;
    password: string;
}
const USERS_KEY = 'users';
const CURRENT_USER_KEY = 'currentUser';

@Injectable()
export class AuthService{
    // private isAuthenticated: BehaviorSubject<boolean>;
    // private currentUser: BehaviorSubject<IUserModel>;

    cachedRequests: Array<HttpRequest<any>> = [];

    constructor(private client: AuthClient, public router: Router) {
    }

    // get IsAuthenticated(): Observable<boolean> {
    //     return this.isAuthenticated.asObservable();
    // }

    public getToken(): string {
        return localStorage.getItem('token');
    }

    public isAuthenticated(): boolean {
        const token = this.getToken();
        if (token != null){
            return !!token;
        }
        return false;
    }

    public collectFailedRequest(request): void {
        this.cachedRequests.push(request);
    }
    public retryFailedRequests(): void {
        // retry the requests. this method can
        // be called after the token is refreshed
    }

    login(name: string, pass: string): Observable<TokensViewModel> {
        const loginDto: LoginDTO = new LoginDTO({
            userName: name,
            password: pass
        });
        return this.client.login(loginDto);
    }

    signup(name: string, pass: string, country: string): Observable<TokensViewModel> {
        const registerDto: RegisterDTO = new RegisterDTO({
            userName: name,
            password: pass,
            countryName: country
        });
        return this.client.register(registerDto);
    }
}
