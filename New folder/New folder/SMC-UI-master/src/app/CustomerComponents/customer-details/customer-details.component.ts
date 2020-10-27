import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/Models/customer.model';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { CustomerService } from 'src/app/Services/customer.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css']
})
export class CustomerDetailsComponent implements OnInit {

  CustomerId : number;
  customer : Customer = new Customer();
  IsSuperAdmin = false;
  currentUserStore;
  constructor(private route : ActivatedRoute , private customerService : CustomerService , 
    private router : Router , private auth : AuthenticationService ,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.currentUserStore  = localStorage.getItem('StoreId');
    if(this.currentUserStore == "0")
    {this.IsSuperAdmin = true;}
    this.route.paramMap.subscribe(params => {
      this.CustomerId = +params.get('CustomerId');
      if(this.CustomerId !== 0)
      {
        this.customerService.getCustomer(this.CustomerId).subscribe(
          (data => {
            this.customer = data;
            console.log(this.customer);
          }),
          (error => console.log(error))
        );        
      }
    });
  }

   
SubmitData(){
  
  console.log(this.customer);
  if(this.CustomerId == 0)
  {
    this.customerService.insertCustomer(this.customer).subscribe(
      (data => {
        this.router.navigate(['/Customers']);
        this.toastr.success("Customer Added Successfully","Register");}),
      (err => { 
        console.log(err);
        this.toastr.error("An Error Occured","Error"); }))
    
  }   
  else{
    this.customerService.updateCustomer(this.CustomerId , this.customer).subscribe(
      (data => {
        this.router.navigate(['/Customers'])
        this.toastr.warning("Customer Updated Successfully","Edit");}),
      (err => { 
        console.log(err); 
        this.toastr.error("An Error Occured","Error");}))
  }
  }


}
