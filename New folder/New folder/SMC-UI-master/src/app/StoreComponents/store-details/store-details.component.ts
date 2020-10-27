import { Component, OnInit } from '@angular/core';
import { Store } from 'src/app/Models/store.model';
import { ActivatedRoute, Router } from '@angular/router';
import { StoreService } from 'src/app/Services/store.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-store-details',
  templateUrl: './store-details.component.html',
  styleUrls: ['./store-details.component.css']
})
export class StoreDetailsComponent implements OnInit {

  StoreId : number;
  Store : Store = new Store();
  keepers : any;

  currentUserStore;
  constructor(private route : ActivatedRoute , private toastr : ToastrService,
    private storeService : StoreService , private router : Router) { }

  ngOnInit() {
    this.currentUserStore = localStorage.getItem('StoreId');
    this.route.paramMap.subscribe(params => {
      this.StoreId = +params.get('StoreId');
      if(this.StoreId !== 0)
      {
        this.storeService.getStore(this.StoreId).subscribe(
          (data => {
            this.Store = data;
            console.log(this.Store);
            if(this.Store.image == "")
            {
              this.Store.image = "../../../assets/images/no-image.jpg";
            }
          }),
          (error => console.log(error))
        );        
      }
      else{
        this.Store = new Store();
        this.Store.image = "../../../assets/images/no-image.jpg";
      }
    });
    this.RequiresList();
  }

  RequiresList(){
 this.keepers = [
  { ID:"1" , Name : "Ahmed"},
  { ID:"2" , Name : "Tamer"},
  { ID:"3" , Name : "Ali"},
  { ID:"4" , Name : "Mohamed"}];
  }

  SubmitData(){
    if(this.StoreId == 0)
  {
    this.storeService.insertStore(this.Store).subscribe(
      (data => {
      this.router.navigate(['/Stores']);
      this.toastr.success("Store Added Successfully","Create");}),
      (err => { console.log(err); 
        this.toastr.error("An Error Occured","Error");})) 
  }   
  else{
    this.storeService.updateStore(this.StoreId , this.Store).subscribe(
      (data => {
      this.router.navigate(['/Stores']);
      this.toastr.warning("Store Updated Successfully","Edit");}),
      (err => { 
        console.log(err); 
        this.toastr.error("An Error Occured","Error");}))
  }
  }


Uploadimage(event)
  {
//  this.newStore.image = <File>event.target.files[0];
var reader = new FileReader();
		// reader.readAsDataURL(event.target.files[0]);
		reader.onload = (e : any) => {
      const image = new Image();
       image.src = e.target.result;
       image.onload = rs => {
        const imgBase64Path = e.target.result;
        this.setImgtoStore(imgBase64Path);
       };
    };  
    reader.readAsDataURL(event.target.files[0]);
  }

  setImgtoStore(img){
    this.Store.image=img;
  }


}
