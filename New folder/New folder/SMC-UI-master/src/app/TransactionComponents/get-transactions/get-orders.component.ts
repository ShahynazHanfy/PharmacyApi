import { Component, OnInit, ViewChild } from '@angular/core';
import { OrderService } from 'src/app/Services/order.service';
import { Order } from 'src/app/Models/order.model';
import { Table } from 'primeng/table';
import { Store } from 'src/app/Models/store.model';
import { StoreService } from 'src/app/Services/store.service';
import { TranslateService } from '@ngx-translate/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ExcelService } from 'src/app/Services/excel.service';
import { PDFService } from 'src/app/Services/pdf.service';
import { OrderType } from 'src/app/Models/ordertype.model';
import { OrdertypeService } from 'src/app/Services/ordertype.service';

@Component({
  selector: 'app-get-orders',
  templateUrl: './get-orders.component.html',
  styleUrls: ['./get-orders.component.css']
})
export class GetOrdersComponent implements OnInit {

  @ViewChild('dt') table: Table;
  loading: boolean = true;
  orders : Order[]=[];
  stores : Store[]=[];
  types : OrderType[]=[];
  currentUserStore:any;
  AuthorizedToAdd: boolean;
  AuthorizedToEdit: boolean;
  AuthorizedToRemove: boolean;

  //export options 
  exportColumns: any[];
  constructor(private orderService : OrderService,private typeService : OrdertypeService,
    private authService : AuthenticationService,private excelService:ExcelService,
    private storeService : StoreService , private pdfService : PDFService) { }

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
    this.orderService.GetAll().subscribe(
      data => {this.orders = data;
              console.log(this.orders)
              this.loading=false;});
  }
  else{  
    this.orderService.GetStoreTransactions(this.currentUserStore).subscribe(data => {
    this.orders = data;
    this.loading=false;
    });
}
  this.storeService.GetAll().subscribe(data => {this.stores = data;});
  this.typeService.GetAll().subscribe(data => {this.types = data;});

}

onStoreChange(event:any)
{
  const t = event;
  this.table.filter(t, 'StoreId', 'startsWith')
}

onTypeChange(event:any)
{
  const t = event;
  this.table.filter(t, 'TypeId', 'startsWith')
}

exportPdf()
{
this.pdfService.generatePdf('download','Transactions',this.orders,'transaction');
}

// exportAsXLSX():void {
//   this.excelService.exportAsExcelFile(this.transactions, 'transactions_data');
// }

// exportAsCustomExcel():void {
//   this.excelService.exportAsCustomExcelFile(this.transactions, 'transactions_data');
// }

}
