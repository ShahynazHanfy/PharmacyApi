import { Component, OnInit } from '@angular/core';
import { TransactionReport } from 'src/app/Models/transactionreport.model';
import { OrdertypeService } from 'src/app/Services/ordertype.service';
import { TranslateService } from '@ngx-translate/core';
import { OrderType } from 'src/app/Models/ordertype.model';
import { Store } from 'src/app/Models/store.model';
import { StoreService } from 'src/app/Services/store.service';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ReportService } from 'src/app/Services/report.service';
import { ItemService } from 'src/app/Services/item.service';
import { PDFService } from 'src/app/Services/pdf.service';
import { Item } from 'src/app/Models/item.model';
@Component({
  selector: 'app-transaction-report',
  templateUrl: './transaction-report.component.html',
  styleUrls: ['./transaction-report.component.css']
})
export class TransactionReportComponent implements OnInit {

  //transaction report
  report : TransactionReport = new TransactionReport();
  types : OrderType[] = [];
  stores : Store[] =[];
  
  //For Authorization Part
  CurrentUserStore;
  displayStores = false;
  IsSuperAdmin = false;

  //Rorder Level Report
  ReorderReportOption:string;
  StoreIdForReorderReport : number;

  //Top Ten Suppliers For Item Report
  items : Item[] =[];
  ItemForSupplierReport : number;

  //expired items report
  NumberOfDays : number;
  constructor(private typeService : OrdertypeService ,private storeService : StoreService,
    private auth : AuthenticationService , private reportService : ReportService ,
    private itemService : ItemService,private pdfService : PDFService,
     private translate : TranslateService) { }

  ngOnInit() {
    this.CurrentUserStore  = localStorage.getItem('StoreId');
    if(this.CurrentUserStore == "0")
    {this.IsSuperAdmin = true;}
    this.RequiredList();
  }

  RequiredList()
  {
    this.typeService.GetAll().subscribe(data => {this.types=data});
    this.storeService.GetAll().subscribe(data => {this.stores=data});
    this.itemService.GetAll().subscribe(data => {this.items=data});
  }

  DownloadTransactionsReport()
  {
    this.reportService.TransactionReport(this.report).subscribe(
      data =>{
        console.log(data);
      this.pdfService.generatePdf('download',"Transactions",data,'transaction')}
    )
  }

  DownloadExpiredItems()
  {
    console.log(this.NumberOfDays);
    const title = "Expired Items within "+ this.NumberOfDays+" Days";
    this.itemService.ExpiredItemsWithinDays(this.NumberOfDays).subscribe(
      data => {console.log(data);
        this.pdfService.generatePdf('download',title,data,'expireditems')});
        this.NumberOfDays = 0;
  }

  DownloadReorderedItems()
  {
    if(this.IsSuperAdmin)
    {
      if(this.ReorderReportOption == 'OneStore')
      {
        this.GetItemsNeedToReorderedForStore(this.StoreIdForReorderReport);
      }
      if(this.ReorderReportOption == 'AllStores')
      {
        let tables:any=[];
        this.stores.forEach(element=>
          {
            this.reportService.GetItemsReachedReorderLevelForStore(element.ID).subscribe(
              data => { 
               tables.push(this.pdfService.GenerateReorderItemsTable(data)); 
              });
          });
          
          this.pdfService.generatePdfWithMultiTables('download',"Any Title",tables,'hello');
      }
    }
    else
    {
     this.GetItemsNeedToReorderedForStore(this.CurrentUserStore);
    }
    
  }

  GetItemsNeedToReorderedForStore(storeId:number)
  {
    this.reportService.GetItemsReachedReorderLevelForStore(storeId).subscribe(
      data => {console.log(data);
      this.pdfService.generatePdf('download','Items Which Need To Reordered',data,'reorderitems')});
  }

 
  ChangeReorderReportOption(ReorderOption)
  {
    if(ReorderOption == 'OneStore')
      this.displayStores=true;
    
    if(ReorderOption == 'AllStores')
      this.displayStores=false;
  }

 
}
