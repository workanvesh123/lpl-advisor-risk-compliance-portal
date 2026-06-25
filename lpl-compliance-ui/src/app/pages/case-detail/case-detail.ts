import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ComplianceService } from '../../services/compliance';

@Component({
  selector: 'app-case-detail',
  imports: [CommonModule, RouterLink],
  templateUrl: './case-detail.html',
  styleUrl: './case-detail.scss'
})
export class CaseDetail implements OnInit {

  caseItem: any;

  statuses = [
    'New',
    'In Review',
    'Pending Documents',
    'Approved',
    'Rejected'
  ];

  constructor(
    private route: ActivatedRoute,
    private complianceService: ComplianceService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.loadCase(id);
  }

  loadCase(id: number) {
    this.complianceService.getCaseById(id).subscribe(data => {
      this.caseItem = data;
    });
  }

  updateStatus(status: string) {
    this.complianceService.updateStatus(this.caseItem.id, status)
      .subscribe(data => {
        this.caseItem = data;
      });
  }
}