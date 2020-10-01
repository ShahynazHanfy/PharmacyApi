import { Component, OnInit } from '@angular/core';
import { Group } from 'src/app/Models/group.model';
import { ActivatedRoute, Router } from '@angular/router';
import { GroupService } from 'src/app/Services/group.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-group-details',
  templateUrl: './group-details.component.html',
  styleUrls: ['./group-details.component.css']
})
export class GroupDetailsComponent implements OnInit {

  GroupId : number;
  group : Group = new Group();
  currentUserStore;
  constructor(private route : ActivatedRoute , private toastr : ToastrService,
    private groupService : GroupService , private router : Router) { }

  ngOnInit() {
    this.currentUserStore = localStorage.getItem('StoreId');
    this.route.paramMap.subscribe(params => {
      this.GroupId = +params.get('GroupId');
      if(this.GroupId !== 0)
      {
        this.groupService.getGroup(this.GroupId).subscribe(
          (data => {
            this.group = data;
            console.log(this.group);
            if(this.group.image == "")
            {
              this.group.image = "../../../assets/images/no-image.jpg";
            }
          }),
          (error => console.log(error))
        );        
      }
      else{
        this.group = new Group();
        this.group.image = "../../../assets/images/no-image.jpg";
      }
    });
  }

  SubmitData()
  {
   if(this.GroupId == 0)
   {
    this.groupService.insertGroup(this.group).subscribe(
      (data => {
        this.router.navigate(['/GroupsAndSubgroups']);
        this.toastr.success("Group Added Successfully","Create");
      }),
      (err => { this.toastr.error("An Error Occured","Error"); })
    )
   }
   else
   {
    this.groupService.updateGroup(this.GroupId , this.group).subscribe(
      (data => {
        this.router.navigate(['/GroupsAndSubgroups']);
        this.toastr.warning("Group Updated Successfully","Edit");
      }),
      (err => { this.toastr.error("An Error Occured","Error"); })
    )
   }
  }

  Uploadimage(event)
  {
console.log(event.target.files[0]);
//  this.newStore.image = <File>event.target.files[0];
var reader = new FileReader();
		// reader.readAsDataURL(event.target.files[0]);
		reader.onload = (e : any) => {
      const image = new Image();
       image.src = e.target.result;
       image.onload = rs => {
        const imgBase64Path = e.target.result;
        this.setImgtoGroup(imgBase64Path);
       };
    };  
    reader.readAsDataURL(event.target.files[0]);
  }

  setImgtoGroup(img){
   
    this.group.image=img;
   
  }
}
