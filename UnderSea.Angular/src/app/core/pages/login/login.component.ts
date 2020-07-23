import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';

import { Router } from '@angular/router';

import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../services/auth.service';
import { tap } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  username: string;
  password: string;

  regUsername: string;
  regPassword: string;
  confirmPassword: string;
  countryName: string;

  reg: boolean;

  loginForm: FormGroup;

  formBuilder: FormBuilder = new FormBuilder();

  matcher = new MyErrorStateMatcher();

  constructor(private router: Router, public http: HttpClient, private authService: AuthService, private snackbar: MatSnackBar) { }

  ngOnInit(): void {

    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.reg = false;
  }

  login(): void {
    this.authService.login(this.username, this.password).pipe(
      tap(tokens => {
        if (tokens.accessToken != null) {
          this.router.navigate(['/main']);
        }
      })
    ).subscribe();
  }

  signup(): void {
    this.authService.signup(this.regUsername, this.regPassword, this.countryName).pipe(
      tap(res => {
        if (res.accessToken != null) {
          this.reg = false;
          this.router.navigate(['/main']);
        }
        this.snackbar.open('Sikeres regisztráció', 'Bezár', {
          duration: 3000,
          panelClass: ['my-snackbar'],
        });
      })
    ).subscribe();
  }

  _true(): void {
    this.reg = true;
    this.username = null;
    this.password = null;
  }

  _false(): void {
    this.reg = false;
    this.regUsername = null;
    this.regPassword = null;
    this.confirmPassword = null;
    this.countryName = null;
  }
}
