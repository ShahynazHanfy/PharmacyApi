import { Component, OnInit, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { OrdertypeService } from 'src/app/Services/ordertype.service';
import { OrderType } from 'src/app/Models/ordertype.model';
import { Table } from 'primeng/table';
import { ConfirmationService } from 'primeng/api';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-get-transactiontypes',
  templateUrl: './get-transactiontypes.component.html',
  styleUrls: ['./get-transactiontypes.component.css']
})
export class GetTransactiontypesComponent implements OnInit {

  @ViewChild('dt') table: Table;
  loading: boolean = true;
  types : OrderType[]=[];
  processtypes : any;
  filterType : any ;
  AuthorizedToAdd=false;
  AuthorizedToEdit=false;
  AuthorizedToRemove=false;

  //to check if it's a new type or editing 
  Editing = false;

  //details dialog
  display: boolean = false;
  type  = new OrderType();

  constructor(private translate : TranslateService,private confirmationService: ConfirmationService,
    private typeService : OrdertypeService , private authService : AuthenticationService,
    private toastr : ToastrService ) { }

  ngOnInit() {
    this.AuthorizedToAdd = this.authService.isAuthorized(['Add','Admin','SuperAdmin'])
    this.AuthorizedToEdit = this.authService.isAuthorized(['Update','Admin','SuperAdmin'])
    this.AuthorizedToRemove = this.authService.isAuthorized(['Delete','Admin','SuperAdmin'])
    this.type = new OrderType();
    this.RequiredList();
  }

RequiredList()
{
  this.typeService.GetAll().subscribe(
    data => {this.types = data;
             this.loading=false;});

    this.processtypes = [
      {name:"+" , value:"1"},
      {name:"-", value:"0"}
    ]
}

onProcessTypeChange(event:any)
{
  const t = event;
  if(t == 1)
    {
      this.table.filter("true", 'ProcessType', 'equals')
    }
  if(t == 0)
   {
     this.table.filter("false", 'ProcessType', 'equals')
   }

}

DisplayDetailsDialog(typeId)
{
  if(typeId == 0)
  {
    this.type = new OrderType();
    this.type.ID =0;
    this.Editing=false;
  }
  else{
    this.typeService.getType(typeId).subscribe(
      data => {this.type = data},
      error => { console.log(error)});
      this.Editing=true;

  }
  this.display = true
}

SubmitData(){
  if(this.type.ID !== 0)
  {
    this.typeService.updateType(this.type.ID , this.type).subscribe(
     data => {
      this.display=false;
      this.toastr.warning("Type Updated Successfully","Edit")
      this.RequiredList();
     });
  }
  else{
    this.typeService.insertType(this.type).subscribe(
      (data => {
        this.toastr.success("Type Added Successfully","Create");
        this.display=false;
        this.RequiredList();
      }),
      (err => { console.log(err);
        this.toastr.error("An Error Occured","Error");
      })
    )
  }
  
}

DeleteType(TransactionTypeId)
{
  this.confirmationService.confirm({
    message: 'Are you sure that you want to Delete this type?',
    header: 'Confirmation',
    icon: 'pi pi-exclamation-triangle',
    accept: () => {
      this.typeService.DeleteType(TransactionTypeId).subscribe(data=>{
        this.RequiredList();
        this.toastr.success("Type Deleted Successfully","Remove");
      }
    );
    },
    reject: () => {
    }
});
}


}
