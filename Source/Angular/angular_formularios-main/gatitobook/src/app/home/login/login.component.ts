import { AuthService } from './../../autentication/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  usuario = '';
  senha = '';

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {}

  login() {
    this.authService.autenticate(this.usuario, this.senha).subscribe(
      () => {
        console.log('Auth Success!');
        this.router.navigate(['animais']);
      },
      (error) => {
        alert('User or password invalid!');
        console.log(error);
      }
    );
  }
}
