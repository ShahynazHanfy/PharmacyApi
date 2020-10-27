import { Component, OnInit, ViewChild } from '@angular/core';
import { Supplier } from 'src/app/Models/supplier.model';
import { Table } from 'primeng/table';
import { SupplierService } from 'src/app/Services/supplier.service';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ExcelService } from 'src/app/Services/excel.service';
import { PDFService } from 'src/app/Services/pdf.service';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-get-suppliers',
  templateUrl: './get-suppliers.component.html',
  styleUrls: ['./get-suppliers.component.css']
})
export class GetSuppliersComponent implements OnInit {

  @ViewChild('dt') table: Table;
  loading: boolean = true;
  suppliers : Supplier[]=[];


  currentUserStore:any;
  IsSuperAdmin = false;

  //export options 
  exportColumns: any[];
  constructor(private supplierService : SupplierService,private toastr : ToastrService,
    private authService : AuthenticationService,private excelService:ExcelService,
     private pdfService : PDFService ,private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.currentUserStore  = localStorage.getItem('StoreId');
    if(this.currentUserStore == "0")
    {this.IsSuperAdmin = true;}
    this.RequiredList();
  }

RequiredList()
{
   this.supplierService.GetAll().subscribe(
      data => {this.suppliers = data;
              this.loading=false;});
}

exportPdf()
{
this.pdfService.generatePdf('download','Transactions',this.suppliers,'transaction');
}

DeleteSupplier(id)
  {
    this.confirmationService.confirm({
      message: 'Are you sure that you want to proceed?',
      header: 'Confirmation',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.supplierService.DeleteSupplier(id).subscribe(
          data => {this.RequiredList();
          this.toastr.success("Supplier Deleted Successfully","Remove");});
      },
      reject: () => {
        
      }
  });
    
  }

}
