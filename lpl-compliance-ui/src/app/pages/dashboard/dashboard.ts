import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ComplianceService } from '../../services/compliance';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  imports: [RouterLink, CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss'
})
export class Dashboard implements OnInit {

  dashboard: any;

  constructor(private complianceService: ComplianceService) {}

  ngOnInit(): void {
    this.complianceService.getDashboard().subscribe({
      next: data => this.dashboard = data,
      error: err => console.error(err)
    });
  }
}