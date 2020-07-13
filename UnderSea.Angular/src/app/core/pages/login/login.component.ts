import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators, FormGroup } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';

import { Router } from '@angular/router';

import { MatCardModule } from '@angular/material/card';

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

  reg: boolean;

  userFormControl = new FormControl('', [
    Validators.required,
  ]);
  passFormControl = new FormControl('');

  matcher = new MyErrorStateMatcher();


  constructor(private router: Router) { }

  ngOnInit(): void {
    this.reg = false;
  }

  login(): void {
    // todo the username and password validation and stuff
    /* if (this.reg === false) {
        this.router.navigate(['main']);
    } else {
      alert('Invalid credentials');
    } */
    this.router.navigate(['main']);
  }

  signup(): void {
  }

  _true(): void {
    this.reg = true;
  }

  _false(): void {
    this.reg = false;
  }
}



