import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-expireditems-report',
  templateUrl: './expireditems-report.component.html',
  styleUrls: ['./expireditems-report.component.css']
})
export class ExpireditemsReportComponent implements OnInit {

  NumberOfDays : number;
  constructor() { }

  ngOnInit() {
  }

}
