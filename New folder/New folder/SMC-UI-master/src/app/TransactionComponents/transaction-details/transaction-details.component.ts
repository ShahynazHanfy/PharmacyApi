import { Component, OnInit } from '@angular/core';
import { OrderType } from 'src/app/Models/ordertype.model';
import { OrdertypeService } from 'src/app/Services/ordertype.service';
import { Order } from 'src/app/Models/order.model';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderService } from 'src/app/Services/order.service';
import { Item } from 'src/app/Models/item.model';
import { ItemService } from 'src/app/Services/item.service';
import { OrderDetails } from 'src/app/Models/orderdetails.model';
import { TranslateService } from '@ngx-translate/core';
import { StoreService } from 'src/app/Services/store.service';
import { Store } from 'src/app/Models/store.model';
import { BalanceService } from 'src/app/Services/balance.service';
import { Supplier } from 'src/app/Models/supplier.model';
import { SupplierService } from 'src/app/Services/supplier.service';
import { CustomerService } from 'src/app/Services/customer.service';
import { Customer } from 'src/app/Models/customer.model';
import { Employee } from 'src/app/Models/employee.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-transaction-details',
  templateUrl: './transaction-details.component.html',
  styleUrls: ['./transaction-details.component.css']
})
export class TransactionDetailsComponent implements OnInit {

  
  types: OrderType[];
  orderId : number;
  order : Order;
  items : Item[];
  // selecteditems: Item[];
  Finalselecteditems : OrderDetails[];
  draggedItem : Item;
  cols : any;
  currentLang =this.translate.currentLang;
  CurrentUserStore ;
  lastBalanceDate ;

  //For Addition Type
  suppliers: Supplier[]=[];
  DisplaySuppliers=false;

  //For Cashing Type
  customers : Customer[]=[];
  DisplayCustomers=false;

  //For Out Transfer Type
  stores : Store[]=[];
  DisplayStores=false;

  //For Employee Transfer Type
  employees : Employee[]=[];
  DisplayEmployees=false;
  constructor(private typeService : OrdertypeService ,private storeService : StoreService
    , public translate : TranslateService,private itemService : ItemService ,
    private supplierService : SupplierService, private customerService : CustomerService,
    private balanceService : BalanceService, private orderService : OrderService
    ,private router : Router,private route : ActivatedRoute ,private toastr : ToastrService) { }

  ngOnInit() {
    this.CurrentUserStore = localStorage.getItem('StoreId');
    this.route.paramMap.subscribe(
      params => { this.orderId = +params.get('OrderId');
      if(this.orderId !== 0)
      {
        this.orderService.getTransaction(this.orderId).subscribe(
          (data => {this.order = data; }),
          (error => console.log(error))
        );        
      }
      else{
        this.order = new Order(); }
      });
    this.RequiredList();
    this.translate.onLangChange.subscribe(() => {
      this.currentLang = this.translate.currentLang;
      this.onLangChange();
    });
    this.onLangChange();
  }

  RequiredList(){
  this.typeService.GetActiveTypes().subscribe(data => {this.types = data});
  this.itemService.GetAll().subscribe(data =>{this.items = data});
  this.Finalselecteditems = [];
}


onLangChange(){
  if (this.currentLang === 'en') {
    this.cols = [
      {  header: 'Name'},
      {  header: 'Bar Code'},
      {  header: 'Quantity' },
      {  header: 'Unit Price' },
      {  header: 'Production Date'},
      {  header: 'Expiry Date' }
    ];
   }
  else {
    this.cols = [
      {  header: 'الاسم'},
      {  header: 'الرمز الشريطي' },
      {  header: 'الكمية'},
      {  header: 'سعر الوحدة' },
      {  header: 'تاريخ الانتاج' },
      {  header: 'انتهاء الصلاحية' }  
    
    ];
    
  }
}

dragStart(event,item: Item) {
  this.draggedItem = item;
}

drop(event) {
  if (this.draggedItem) {
      let FinaldraggedItem = new OrderDetails();
      FinaldraggedItem.Item = this.draggedItem;
      FinaldraggedItem.ItemId = FinaldraggedItem.Item.ID;
      let draggedItemIndex = this.findIndex(this.draggedItem);
      // this.selecteditems = [...this.selecteditems, this.draggedItem];
      this.Finalselecteditems = [...this.Finalselecteditems, FinaldraggedItem];
      this.items = this.items.filter((val,i) => i!=draggedItemIndex);
      this.draggedItem = null;
  }
}

dragEnd(event) {
  this.draggedItem = null;
}

findIndex(item: Item) {
  let index = -1;
  for(let i = 0; i < this.items.length; i++) {
      if (item.ID === this.items[i].ID) {
          index = i;
          break;
      }
  }
  return index;
}

SubmitData()
  {
    console.log(this.order)
    this.order.ItemList = this.Finalselecteditems;
    this.order.StoreId = this.CurrentUserStore;
    this.balanceService.GetLastBalance(this.CurrentUserStore).subscribe(
      data => {this.lastBalanceDate = data.BalanceDate;
        console.log(this.lastBalanceDate)
        if(this.order.OrderDate <= this.lastBalanceDate)
      {
        this.toastr.error("Transaction Date Not Valid","Error");
        console.log("Transaction date not valid");
      }
      else{
        this.orderService.insertTransaction(this.order).subscribe(
          data => {
          this.router.navigate(['/Orders']);
          this.toastr.success("Order Completed Successfully","Create")});
      }  
      }); 
  }

  RemoveRecord(item:Item)
  {
    this.Finalselecteditems = this.Finalselecteditems.filter((val,i) => val.ItemId!=item.ID);
    this.items = [...this.items, item];
  }

  OnChangeType(t)
  {
    this.DisplaySuppliers =false;
    this.DisplayCustomers =false;
    this.DisplayStores =false;
     this.DisplayEmployees = false;
    this.order.SupplierId = null;
    this.order.CustomerId = null;
    this.order.DeliveredToStore = null
    this.order.GettedFromStore = null;
    this.order.EmployeeId = null;

    //In case type is Addition
    if(t.ID === 1)
    { this.supplierService.GetAll().subscribe(data => {this.suppliers=data;});
      this.DisplaySuppliers = true;}

    //In case type is cashing
    if(t.ID === 2)
    { this.customerService.GetAll().subscribe(data => {this.customers = data});
      this.DisplayCustomers= true;}

    //In case type is out transfer
    if(t.ID === 3)
    { this.storeService.GetAll().subscribe(data => {this.stores = data});
      this.DisplayStores= true;}

    //In case type is internal employee
      if(t.ID === 6)
    { this.orderService.GetEmployees().subscribe(data => {this.employees = data});
      this.DisplayEmployees= true;}
  }
  
}
