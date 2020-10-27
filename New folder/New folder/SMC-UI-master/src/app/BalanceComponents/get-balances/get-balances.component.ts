import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { Balance } from 'src/app/Models/balance.model';
import { BalanceService } from 'src/app/Services/balance.service';
import { StoreService } from 'src/app/Services/store.service';
import { Store } from 'src/app/Models/store.model';
import { AuthenticationService } from 'src/app/Services/authentication.service';

@Component({
  selector: 'app-get-balances',
  templateUrl: './get-balances.component.html',
  styleUrls: ['./get-balances.component.css']
})
export class GetBalancesComponent implements OnInit {

  @ViewChild('dt') table: Table;
  loading: boolean = true;
  balances : Balance[]=[];
  stores : Store[]=[];
  currentUserStore:any;
  AuthorizedToAdd: boolean;
  AuthorizedToEdit: boolean;
  AuthorizedToRemove: boolean;
  constructor(private balanceService : BalanceService , private storeService : StoreService
    ,private authService : AuthenticationService) { }

  ngOnInit() {
    this.AuthorizedToAdd = this.authService.isAuthorized(['Add','Admin','SuperAdmin'])
    this.AuthorizedToEdit = this.authService.isAuthorized(['Update','Admin','SuperAdmin'])
    this.AuthorizedToRemove = this.authService.isAuthorized(['Delete','Admin','SuperAdmin'])
    this.currentUserStore=localStorage.getItem('StoreId');
this.RequiredList();
  }

RequiredList()
{
  if(this.currentUserStore == 0)
  {
    this.balanceService.GetAll().subscribe(
      data => {
  this.balances = data;
  this.loading=false;
      });
  }
  else{
    this.balanceService.GetStoreBalances(this.currentUserStore).subscribe(
      data => {
  this.balances = data;
  this.loading=false;
      });  
  }
 
  this.storeService.GetAll().subscribe(
      data => {
  this.stores = data;
      });

}

onStoreChange(event:any)
{
  const t = event;
  this.table.filter(t, 'StoreId', 'startsWith')

}


}
