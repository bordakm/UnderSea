import { Injectable } from '@angular/core';

import { BehaviorSubject, Observable } from 'rxjs';
import { IUserModel } from '../models/user.model';

interface User {
    username: string;
    password: string;
}
const USERS_KEY = 'users';
const CURRENT_USER_KEY = 'currentUser';

@Injectable()
export class AuthService {
    private isAuthenticated: BehaviorSubject<boolean>;
    private currentUser: BehaviorSubject<IUserModel>;

    constructor() {
        const currentUsername = localStorage.getItem(CURRENT_USER_KEY);
        const isAuthenticated = !!currentUsername;
        this.isAuthenticated = new BehaviorSubject<boolean>(isAuthenticated);
        this.currentUser = new BehaviorSubject<IUserModel>(isAuthenticated ? {username: currentUsername} : null);
    }

    get IsAuthenticated$(): Observable<boolean> {
        return this.isAuthenticated.asObservable();
    }

    get CurrentUser$(): Observable<IUserModel> {
        return this.currentUser.asObservable();
    }

    login(username: string, password: string): boolean {
        const users = this.getUsers();
        const curr = users.find(u => u.username === username);
        if (curr && curr.password === password) {
            this.loginUser(username);
            return true;
        } else if (curr && curr.password !== password) {
            return false;
        } else {
            this.addUser({ username: username, password: password });
            this.loginUser(username);
            return true;
        }
    }

    logout() {
        this.isAuthenticated.next(false);
        this.currentUser.next(null);
        localStorage.removeItem(CURRENT_USER_KEY);
    }

    private loginUser(username: string) {
        this.isAuthenticated.next(true);
        this.currentUser.next({ username: username});
        localStorage.setItem(CURRENT_USER_KEY, username);
    }

    private getUsers(): User[] {
        return JSON.parse(localStorage.getItem(USERS_KEY)) || [];
    }
    
    private addUser(user: User) {
        const users = this.getUsers();
        users.push(user);
        localStorage.setItem(USERS_KEY, JSON.stringify(users));
    }
}