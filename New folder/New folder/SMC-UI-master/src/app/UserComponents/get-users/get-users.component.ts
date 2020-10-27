import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { User } from 'src/app/Models/user.model';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService } from 'primeng/api';
import { UserService } from 'src/app/Services/user.service';
import { Store } from 'src/app/Models/store.model';
import { StoreService } from 'src/app/Services/store.service';

@Component({
  selector: 'app-get-users',
  templateUrl: './get-users.component.html',
  styleUrls: ['./get-users.component.css']
})
export class GetUsersComponent implements OnInit {

  @ViewChild('dt') table: Table;
  loading: boolean = true;
  users : User[]=[];
  stores : Store[]=[]

  //user register dialog
  display: boolean = false;
  user  = new User();
  CurrentUserstore;
  constructor(private translate : TranslateService,private userService : UserService,
    private confirmationService: ConfirmationService,private storeService : StoreService) { }

  ngOnInit() {
    this.CurrentUserstore  = localStorage.getItem('StoreId');
    this.user = new User();
    this.RequiredList();
  }

  RequiredList()
{
 
  this.userService.GetUsers(this.CurrentUserstore).subscribe(
    data => { this.users = data;
              console.log(this.users)
              this.loading=false;});
    
  this.storeService.GetAll().subscribe(
    data => {this.stores = data});
}

onStoreChange(event:any)
{
  console.log(event);
  const t = event;
  if(t != "All Stores")
  {
    this.table.filter(t, 'StoreId', 'equals')
  }
   
}

confirm1(user) {
  this.confirmationService.confirm({
      message: 'Are you sure that you want to proceed?',
      header: 'Confirmation',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        console.log(user)
        this.userService.DeleteUser(user).subscribe(data=>{
          this.RequiredList()
        // this.toastr.success("Store Deleted Successfully","Remove");
        }
      );
      },
      reject: () => {
        // console.log(StoreId)
      }
  });
}

}
