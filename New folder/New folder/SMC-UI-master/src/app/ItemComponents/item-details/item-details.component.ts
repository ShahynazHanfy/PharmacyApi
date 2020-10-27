import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemService } from 'src/app/Services/item.service';
import { Item } from 'src/app/Models/item.model';
import { SubgroupService } from 'src/app/Services/subgroup.service';
import { Subgroup } from 'src/app/Models/subgroup.model';
import { Group } from 'src/app/Models/group.model';
import { GroupService } from 'src/app/Services/group.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.css']
})
export class ItemDetailsComponent implements OnInit {

  ItemId : number;
  item : Item ;
  subgroups : Subgroup[] ;
  groupId : number = 0;
  groups : Group[];
  currentUserStore;
  constructor(private route : ActivatedRoute , private subgroupService : SubgroupService,
    private groupService : GroupService ,private itemService : ItemService , private router : Router
    ,private toastr : ToastrService) { }

  ngOnInit() {
    this.currentUserStore = localStorage.getItem('StoreId');
    this.route.paramMap.subscribe(params => {
      this.ItemId = +params.get('ItemId');
      if(this.ItemId !== 0)
      {
        this.itemService.getItem(this.ItemId).subscribe(
          (data => {this.item = data;
            console.log(this.item);
            this.groupId = this.item.Subgroup.GroupId;
            this.subgroupService.getSubgroupsByGrpId(this.groupId).subscribe(data =>{this.subgroups = data;})
            if(this.item.image == "")
            {
              this.item.image = "../../../assets/images/no-image.jpg";
            }
          }),
          (error => console.log(error))
        );        
      }
      else{
        this.item = new Item();
        this.item.image = "../../../assets/images/no-image.jpg";
      }
    });
    this.RequiredList();
  }

  RequiredList(){
    this.groupService.GetAll().subscribe(data => {this.groups = data;});
    
}

onChangeGroup(g : any)
  {
    this.subgroupService.getSubgroupsByGrpId(g).subscribe(data =>{this.subgroups = data;});
  }

  SubmitData()
  {
   if(this.ItemId == 0)
   {
    this.itemService.insertItem(this.item).subscribe(
    (data => {this.router.navigate(['/Items']);
     this.toastr.success("Item Added Successfully" , "Create");
}),
    (err => { 
      this.toastr.error("An Error Occured" , "Error");
    })
    )
   }
   else
   {
    this.itemService.updateItem(this.ItemId , this.item).subscribe(
      (data => {
        this.router.navigate(['/Items']);
        this.toastr.warning("Item Upadeted Successfully" , "Edit");
}),
      (err => { 
       this.toastr.success("An Error Occured" , "Error");  
       }))
   }
  }

  Uploadimage(event)
  {
     
      var reader = new FileReader();
		  reader.onload = (e : any) => {
      const image = new Image();
      image.src = e.target.result;
      image.onload = rs => {
      const imgBase64Path = e.target.result;
      this.setImgtoItem(imgBase64Path);
       };
    };  
    reader.readAsDataURL(event.target.files[0]);
  }

  setImgtoItem(img){
    this.item.image=img;
  }
}
