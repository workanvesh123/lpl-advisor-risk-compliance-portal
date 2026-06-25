import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.scss'
})
export class Login {

  username = '';
  password = '';

  constructor(
    private router: Router,
    private authService: AuthService
  ) {}

  login() {
    this.authService.login(this.username, this.password).subscribe({
      next: response => {
        localStorage.setItem('token', response.token);
        localStorage.setItem('userName', response.userName);
        localStorage.setItem('role', response.role);

        this.router.navigate(['/dashboard']);
      },
      error: () => {
        alert('Invalid username or password');
      }
    });
  }
}