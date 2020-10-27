import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../Services/dashboard.service';
import { MonthBalance } from '../Models/MonthBalance.model';
import { BalanceService } from '../Services/balance.service';
import { Balance } from '../Models/balance.model';
import { Order } from '../Models/order.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  //For Quarter Balances 
  QuartersBalances : MonthBalance[] =[];

  //For Display Quarter Details
  DisplayQuarterDetails =false;
  QuarterDetails : MonthBalance[] = [];

  //Last Balance , InOrder , OutOrder
  lastBalance:Balance=new Balance();
  lastInOrder:Order=new Order();
  lastOutOrder: Order = new Order();

  doughnutdata:any;
  piedata:any;
  polardata:any;
  Linedata:any;
  Bardata:any;
  constructor(private dashboardService : DashboardService , private balanceService : BalanceService) {
    this.loaddoughnutData();
    this.loadPieData();
    this.loadPolarData();
   }

  ngOnInit() {
      this.RequiredData();
  }

  RequiredData(){
      this.GetYearBalancePerQuarter();
      this.GetLastBalance();
      this.GetLastInOrder();
      this.GetLastOutOrder();
  }

  GetYearBalancePerQuarter()
  {
    this.dashboardService.GetYearBalancePerQuarter().subscribe(
        data => {this.QuartersBalances=data;
        console.log(this.QuartersBalances)}
    )
  }


  GetQuarterDetails(QuarterNum)
  {
    this.dashboardService.GetQuarterBalancePerMonth(QuarterNum).subscribe(
    data =>{ this.QuarterDetails=data;
   var quarterMonthes = this.GetQuarterMonthes(QuarterNum);
    this.LoadLineData(this.QuarterDetails,quarterMonthes);
    this.LoadBarData(this.QuarterDetails,quarterMonthes);
})
  }

  loaddoughnutData()
  {
    this.doughnutdata = {
      labels: ['A','B','C'],
      datasets: [
          { data: [300, 50, 100],
              backgroundColor: [
                  "#FF6384",
                  "#36A2EB",
                  "#FFCE56"
              ],
              hoverBackgroundColor: [
                  "#FF6384",
                  "#36A2EB",
                  "#FFCE56"
              ]
          }]    
      };
  }
  loadPieData()
  {
    this.piedata = {
      labels: ['A','B','C'],
      datasets: [
          {
              data: [300, 50, 100],
              backgroundColor: [
                  "#FF6384",
                  "#36A2EB",
                  "#FFCE56"
              ],
              hoverBackgroundColor: [
                  "#FF6384",
                  "#36A2EB",
                  "#FFCE56"
              ]
          }]    
      };
  }
  loadPolarData()
  {
    this.polardata = {
      datasets: [{
          data: [11,16,7,3,14],
          backgroundColor: [
              "#FF6384","#4BC0C0","#FFCE56","#E7E9ED","#36A2EB"],
          label: 'My dataset'
      }],
      labels: [
          "Red",
          "Green",
          "Yellow",
          "Grey",
          "Blue"
      ]
  }
  }
  LoadLineData(details,monthes)
  {
      console.log(details); 
    this.Linedata = {
        labels: monthes,
        datasets: [
            {
                label: 'Income Dataset',
                data: details.map(ele => ele.Income),
                fill: false,
                borderColor: '#4bc0c0'
            },
            {
                label: 'Outcome Dataset',
                data: details.map(ele => ele.Outcome),
                fill: false,
                borderColor: '#565656'
            }
        ]
    }
    this.DisplayQuarterDetails=true;
  }
  LoadBarData(details,monthes)
  {
    this.Bardata = {
        labels:monthes,
        datasets: [
            {
                label: 'Income dataset',
                backgroundColor: '#42A5F5',
                borderColor: '#1E88E5',
                data: details.map(ele => ele.Income)
            },
            {
                label: 'Outcome dataset',
                backgroundColor: '#9CCC65',
                borderColor: '#7CB342',
                data: details.map(ele => ele.Outcome)
            }
        ]
    }
  }

  GetQuarterMonthes(QuarterNum)
  {
      switch (QuarterNum)
        {
            case 1:
                return ["January ","February ","March "]
            case 2:
                return ["April","May","June"]
            case 3:
                return ["July","August","September"]
            case 4:
                return ["October","November","December"]
        }
  }

  GetLastBalance()
  {
      this.balanceService.GetGenericLastBalance().subscribe(
          data => {this.lastBalance = data;})
  }
  GetLastInOrder()
  {
      this.dashboardService.GetLastInOrder().subscribe(
          data => {this.lastInOrder = data;})
  }
  GetLastOutOrder()
  {
      this.dashboardService.GetLastOutOrder().subscribe(
          data => {this.lastOutOrder = data;})
  }
}
