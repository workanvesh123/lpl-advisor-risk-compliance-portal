import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { ComplianceService } from '../../services/compliance';

@Component({
  selector: 'app-cases',
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './cases.html',
  styleUrl: './cases.scss'
})
export class Cases implements OnInit {

  cases: any[] = [];

  search = '';

  pageNumber = 1;
  pageSize = 10;

  constructor(private complianceService: ComplianceService){}

  ngOnInit(): void {
    this.loadCases();
  }

  loadCases(){
    this.complianceService
      .getCases(this.search, '', this.pageNumber, this.pageSize)
      .subscribe((result:any)=>{
          this.cases = result.data;
      });
  }
}