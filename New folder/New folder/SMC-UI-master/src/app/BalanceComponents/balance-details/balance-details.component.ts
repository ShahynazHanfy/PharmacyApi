import { Component, OnInit, ViewChild } from '@angular/core';
import { Balance } from 'src/app/Models/balance.model';
import { ActivatedRoute } from '@angular/router';
import { BalanceService } from 'src/app/Services/balance.service';
import { TranslateService } from '@ngx-translate/core';
import { Store } from 'src/app/Models/store.model';
import { StoreService } from 'src/app/Services/store.service';
import { GroupService } from 'src/app/Services/group.service';
import { SubgroupService } from 'src/app/Services/subgroup.service';
import { Group } from 'src/app/Models/group.model';
import { Subgroup } from 'src/app/Models/subgroup.model';
import { Table } from 'primeng/table';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-balance-details',
  templateUrl: './balance-details.component.html',
  styleUrls: ['./balance-details.component.css']
})
export class BalanceDetailsComponent implements OnInit {

  
  @ViewChild('dt') table: Table;
  BalanceId : number;
  balance : Balance; 
  
  currentLang : any;
  cols : any;
  stores : Store[];
  groups : Group[];
  subgroups : Subgroup[];
  LastBalanceDate;

  CurrentUserstore;

  constructor(private route : ActivatedRoute , private balanceService : BalanceService,
    private translate : TranslateService , private storeService : StoreService,
    private groupService : GroupService , private subgroupService : SubgroupService,
    private toastr : ToastrService) { }

  ngOnInit() {
    this.balance=new Balance();
    this.CurrentUserstore = localStorage.getItem('StoreId');
    this.route.paramMap.subscribe(
      params => { this.BalanceId = +params.get('BalanceId');
      console.log(this.BalanceId)
      if(this.BalanceId !== 0)
      {
        this.balanceService.getBalance(this.BalanceId).subscribe(
          (data => {console.log(data);
            this.balance = data; }),
          (error => console.log(error))
        );        
      }
      });
    this.RequiredList();
    this.translate.onLangChange.subscribe(() => {
      this.currentLang = this.translate.currentLang;
      this.onLangChange();
    });
    this.onLangChange();
  }

  RequiredList(){
 this.storeService.GetAll().subscribe(data => {this.stores = data});
 this.groupService.GetAll().subscribe(data => {this.groups = data});
 this.subgroupService.GetAll().subscribe(data => {this.subgroups = data});
}


onLangChange(){
  if (this.currentLang === 'en') {
    this.cols = [
      {  header: 'Name'},
      {  header: 'Quantity' },
      {  header: 'Group' },
      {  header: 'Sub Group' }];
   }
  else {
    this.cols = [
      {  header: 'الاسم'},
      {  header: 'الكمية'},
      {  header: 'المجموعة' },
      {  header: 'المجموعة الفرعية' }];
    
  }
}

CalculateBalance()
{
  this.balanceService.GetLastBalance(this.balance.StoreId).subscribe(
    data => {this.LastBalanceDate = data.BalanceDate;
      if(this.balance.BalanceDate > this.LastBalanceDate)
      {
        this.balanceService.insertBalance(this.balance).subscribe(
          (data => {
            this.toastr.success("Balance Calculated Successfully","Success")
            this.balance = data;
            this.balanceService.getBalance(this.balance.ID).subscribe(
            (data => {
              this.balance = data;
              console.log(data);}),
            (error => {console.log(error);
            this.toastr.error("Can't Load Items Balance","Error")}
            )
          ) }),
          (error => console.log(error))
        );
      }
      else{
        console.log("Balance date is not valid")
      }
    });
   
}


onSelectGroup(event:any)
{
  const t = event;
  // if(t == 0)
  // this.table.filter(t , 'Item.Subgroup.GroupId','Contains')
  // if(t !== "0")
  this.table.filter(t, 'Item.Subgroup.GroupId', 'equals')

}


onSelectSubgroup(event:any)
{
  const t = event;
  // if(t == 0)
  // this.table.reset()
  // if(t !== "0")
  this.table.filter(t, 'Item.SubgroupId', 'equals')

}

}
