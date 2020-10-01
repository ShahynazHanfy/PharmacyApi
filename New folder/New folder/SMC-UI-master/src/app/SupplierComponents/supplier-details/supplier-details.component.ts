import { Component, OnInit } from '@angular/core';
import { Supplier } from 'src/app/Models/supplier.model';
import { StoreService } from 'src/app/Services/store.service';
import { ActivatedRoute, Router } from '@angular/router';
import { SupplierService } from 'src/app/Services/supplier.service';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-supplier-details',
  templateUrl: './supplier-details.component.html',
  styleUrls: ['./supplier-details.component.css']
})
export class SupplierDetailsComponent implements OnInit {

 
  SupplierId : number;
  supplier : Supplier = new Supplier();
  IsSuperAdmin = false;
  currentUserStore;
  constructor(private route : ActivatedRoute , private supplierService : SupplierService , 
    private toastr : ToastrService ,private router : Router , private auth : AuthenticationService ) { }

  ngOnInit() {
    this.currentUserStore  = localStorage.getItem('StoreId');
    if(this.currentUserStore == "0")
    {this.IsSuperAdmin = true;}
    this.route.paramMap.subscribe(params => {
      this.SupplierId = +params.get('SupplierId');
      if(this.SupplierId !== 0)
      {
        this.supplierService.getSupplier(this.SupplierId).subscribe(
          (data => {
            this.supplier = data;
            console.log(this.supplier);
          }),
          (error => console.log(error))
        );        
      }
    });
  }

   
SubmitData(){
  if(this.SupplierId == 0)
  {
    this.supplierService.insertSupplier(this.supplier).subscribe(
      (data => {
        this.router.navigate(['/Suppliers']);
        this.toastr.success("Supplier Added Successfully","Create"); }),
      (err => { console.log(err);
        this.toastr.error("An Error Occured","Error"); }))
    
  }   
  else{
    this.supplierService.updateSupplier(this.SupplierId , this.supplier).subscribe(
      (data => {
        this.router.navigate(['/Suppliers']);
        this.toastr.warning("Supplier Updated Successfully","Edit");}),
      (err => { console.log(err);
        this.toastr.error("An Error Occured","Error"); }))
  }
  }


}
