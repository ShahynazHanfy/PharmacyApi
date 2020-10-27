import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Models/user.model';
import { UserService } from 'src/app/Services/user.service';
import { TranslateService } from '@ngx-translate/core';
import { StoreService } from 'src/app/Services/store.service';
import { Store } from 'src/app/Models/store.model';
import { ActivatedRoute, Router } from '@angular/router';
import { Role } from 'src/app/Models/role.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

  selectedType : string;
  selectedOperations: string[] = [];
  stores : Store[]=[];
  roles : any;
  CurrentUserstore;

  userId : string;
  user : User;
 
  displayStores = false;
  displayDataEntry = false;
  displaySuper =false;
  constructor(private storeService : StoreService,private router : Router,
    private route : ActivatedRoute,private userService : UserService ,
     public translate : TranslateService , private toastr : ToastrService) { }

  ngOnInit() {
    this.CurrentUserstore  = localStorage.getItem('StoreId');
    if(this.CurrentUserstore == "0")
    this.displaySuper = true;
    this.user = new User();
    this.route.paramMap.subscribe(params => {
     this.userId = params.get('UserId');
     //get user Data
      if(this.userId !== "0")
      { 
          this.userService.GetUser(this.userId).subscribe(
            data => {this.user = data
              console.log(this.user)
          if(data.Roles.includes("Super Admin") || data.Roles.includes("Admin"))
          { this.selectedType = data.Roles[0];
            this.displayStores = !!data.StoreId;
          }
                    
          else
          { this.selectedType = "Data Entry";
          this.displayStores= true;
          this.displayDataEntry= true;
          this.selectedOperations= this.user.Roles;}

          });
      }
      //for adding new user
      else{
        this.user = new User();}
        this.user.StoreId = this.CurrentUserstore;
      });
    this.RequiredList();
  }


  RegisterUser()
  {
    //Assign roles for user
    if(this.selectedType == 'Super Admin' || this.selectedType == 'Admin')
    {
      this.user.Roles.push(this.selectedType);
    }
  
    else
    {
      this.user.Roles = this.selectedOperations;
    }
  
   if(this.userId == "0")
   this.AddNewUser();
  else
  this.UpdateUser();

  this.router.navigate(['/Users']);
  }

  RequiredList()
  {
    this.storeService.GetAll().subscribe( data => {this.stores = data});
      this.roles=['Super Admin','Admin', 'Data Entry']
    // this.userService.GetRoles().subscribe(
    //     data => {this.roles = data});
  }

  ChangeRole(role)
  {
    console.log("selected radio" , this.selectedType)
    if(role == 'Super Admin')
    {
      this.displayStores=false;
      this.displayDataEntry = false;
    }
    if(role == 'Admin')    
      { 
        this.displayStores=true;
        this.displayDataEntry=false; 
      }
   
    if(role == 'Data Entry')
       { 
         this.displayStores=true;
         this.displayDataEntry = true;
       }      
  }

  AddNewUser(){
    this.userService.RegisterUser(this.user).subscribe(
      (data => {
        this.toastr.success("User Added Successfully" , "Register");
        this.user=new User();
      }),
      (err => {this.toastr.error("An Error Occured" , "Error");})
    )
  }
 
  UpdateUser(){
    this.userService.UpdateUser(this.user).subscribe(
      (data => {
        this.toastr.warning("User Updated Successfully" , "Edit");
        this.user=new User();
      }),
      (err => { console.log(err);
        this.toastr.error("An Error Occured" , "Error");
    })
    )
  }

}
