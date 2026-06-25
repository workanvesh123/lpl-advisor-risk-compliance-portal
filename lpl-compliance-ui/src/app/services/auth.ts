import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl = 'http://localhost:5141/api/auth';

  constructor(private http: HttpClient) {}

  login(userName: string, password: string) {
    return this.http.post<any>(`${this.baseUrl}/login`, {
      userName,
      password
    });
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  logout() {
    localStorage.removeItem('token');
  }
}