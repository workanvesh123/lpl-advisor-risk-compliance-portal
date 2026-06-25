import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ComplianceService {

  private baseUrl = 'http://localhost:5026/api';

  constructor(private http: HttpClient) {}

  getDashboard() {
    return this.http.get(`${this.baseUrl}/cases/dashboard`);
  }

  getCases(search = '', status = '', pageNumber = 1, pageSize = 10) {
    return this.http.get(`${this.baseUrl}/cases?search=${search}&status=${status}&pageNumber=${pageNumber}&pageSize=${pageSize}`);
  }

  getCaseById(id: number) {
    return this.http.get(`${this.baseUrl}/cases/${id}`);
  }

  updateStatus(id: number, status: string) {
    return this.http.put(`${this.baseUrl}/cases/${id}/status`, { status });
  }
}