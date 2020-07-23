import { Injectable } from '@angular/core';

import { BehaviorSubject, Observable, of } from 'rxjs';
import { IUserModel } from '../models/user.model';

import { AuthClient, TokensViewModel, LoginDTO, RegisterDTO, RefreshTokenDTO } from 'src/app/shared/index';
import { HttpRequest } from '@angular/common/http';
import { CanActivate, Router, ActivatedRouteSnapshot } from '@angular/router';
import { tap, mapTo, catchError } from 'rxjs/operators';



interface User {
    username: string;
    password: string;
}
const USERS_KEY = 'users';
const CURRENT_USER_KEY = 'currentUser';

@Injectable()
export class AuthService {
    private readonly ACCESS_TOKEN = 'ACCESS_TOKEN';
    private readonly REFRESH_TOKEN = 'REFRESH_TOKEN';

    constructor(private client: AuthClient, public router: Router) { }

    public getAccessToken(): string {
        return localStorage.getItem(this.ACCESS_TOKEN);
    }

    public isAuthenticated(): boolean {
        return !!this.getAccessToken();
    }

    login(name: string, pass: string): Observable<TokensViewModel> {
        const loginDto: LoginDTO = new LoginDTO({
            userName: name,
            password: pass
        });
        return this.client.login(loginDto)
            .pipe(
                tap((tokens: TokensViewModel) => this.storeTokens(tokens))
            );
    }

    logout() {
        return this.client.logout()
            .pipe(
                tap(_ => this.removeTokens())
            );
    }

    signup(name: string, pass: string, country: string): Observable<TokensViewModel> {
        const registerDto: RegisterDTO = new RegisterDTO({
            userName: name,
            password: pass,
            countryName: country
        });
        return this.client.register(registerDto)
            .pipe(
                tap((tokens: TokensViewModel) => this.storeTokens(tokens))
            );
    }

    renew() {
        const refreshTokenDTO: RefreshTokenDTO = new RefreshTokenDTO({
            refreshToken: this.getRefreshToken()
        });
        return this.client.renew(refreshTokenDTO)
            .pipe(
                tap((tokens: TokensViewModel) => this.storeTokens(tokens))
            );
    }

    private getRefreshToken() {
        return localStorage.getItem(this.REFRESH_TOKEN);
    }

    private storeAceessToken(accessToken: string) {
        localStorage.setItem(this.ACCESS_TOKEN, accessToken);
    }

    private storeTokens(tokens: TokensViewModel) {
        if (tokens.accessToken != null) {
            localStorage.setItem(this.ACCESS_TOKEN, tokens.accessToken);
            localStorage.setItem(this.REFRESH_TOKEN, tokens.refreshToken);
        }
    }

    private removeTokens() {
        localStorage.removeItem(this.ACCESS_TOKEN);
        localStorage.removeItem(this.REFRESH_TOKEN);
    }
}
