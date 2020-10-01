import { Component, OnInit, ViewChild } from '@angular/core';
import { Customer } from 'src/app/Models/customer.model';
import { Table } from 'primeng/table';
import { CustomerService } from 'src/app/Services/customer.service';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ExcelService } from 'src/app/Services/excel.service';
import { PDFService } from 'src/app/Services/pdf.service';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-get-customers',
  templateUrl: './get-customers.component.html',
  styleUrls: ['./get-customers.component.css']
})
export class GetCustomersComponent implements OnInit {

  @ViewChild('dt') table: Table;
  loading: boolean = true;
  customers : Customer[]=[];


  currentUserStore:any;
  IsSuperAdmin = false;

  
  constructor(private customerService : CustomerService,private authService : AuthenticationService
    ,private excelService:ExcelService, private pdfService : PDFService,
    private toastr : ToastrService , private confirmationService : ConfirmationService) { }

  ngOnInit() {
    this.currentUserStore  = localStorage.getItem('StoreId');
    if(this.currentUserStore == "0")
    {this.IsSuperAdmin = true;}
    this.RequiredList();
  }

RequiredList()
{
   this.customerService.GetAll().subscribe(
      data => {this.customers = data;
              console.log(data)
              this.loading=false;});
}

exportPdf()
{
this.pdfService.generatePdf('download','Transactions',this.customers,'transaction');
}

DeleteCustomer(id)
  {
    
    this.confirmationService.confirm({
      message: 'Are you sure that you want to proceed?',
      header: 'Confirmation',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.customerService.DeleteCustomer(id).subscribe(
          data => {this.RequiredList();
          this.toastr.success("Customer Deleted Successfully","Remove");});
      },
      reject: () => {
        
      }
  });
    
  }

}
