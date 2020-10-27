import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SubgroupService } from 'src/app/Services/subgroup.service';
import { Subgroup } from 'src/app/Models/subgroup.model';
import { Group } from 'src/app/Models/group.model';
import { GroupService } from 'src/app/Services/group.service';
import { SelectItem } from 'primeng/api';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-subgroup-details',
  templateUrl: './subgroup-details.component.html',
  styleUrls: ['./subgroup-details.component.css']
})
export class SubgroupDetailsComponent implements OnInit {

  SubgroupId: number;
  subgroup: Subgroup;
  selectedGroup: Group = new Group();
  groups: Group[] = [];
  groupData: Group;
  currentUserStore;

  constructor(private route: ActivatedRoute, private groupService: GroupService,
    private subgroupService: SubgroupService, private router: Router,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.currentUserStore = localStorage.getItem('StoreId');
    this.route.paramMap.subscribe(params => {
      this.SubgroupId = +params.get('SubgroupId');
      console.log(this.SubgroupId);
      if (this.SubgroupId !== 0) {
        this.subgroupService.getSubgroup(this.SubgroupId).subscribe(
          (data => {
            this.subgroup = data;
            this.selectedGroup = data.Group;
            // console.log(this.subgroup);
            if (this.subgroup.image == null) {
              this.subgroup.image = "../../../assets/images/no-image.jpg";
            }
          }),
          (error => console.log(error))
        );
      }
      else {
        this.subgroup = new Subgroup();
        this.subgroup.image = "../../../assets/images/no-image.jpg";
      }
    });
    this.RequiredList();
  }

  RequiredList() {
    this.groupService.GetAll().subscribe(
      data => {
        this.groups = data;
      });
  }

  SubmitData() {
    if (this.SubgroupId == 0) {
      this.subgroupService.insertSubgroup(this.subgroup).subscribe(
        (data => {
          this.router.navigate(['/GroupsAndSubgroups']);
          this.toastr.success("SubGroup Added Successfully", "Create");
        }),
        (err => { this.toastr.error("An Error Occured", "Error"); })
      )
    }
    else {
      this.subgroupService.updateSubgroup(this.SubgroupId, this.subgroup).subscribe(
        (data => {
          this.router.navigate(['/GroupsAndSubgroups']);
          this.toastr.warning("SubGroup Updated Successfully", "Edit");
        }),
        (err => { this.toastr.error("An Error Occured", "Error"); })
      )
    }
  }

  Uploadimage(event) {
    var reader = new FileReader();
    reader.onload = (e: any) => {
    const image = new Image();
    image.src = e.target.result;
    image.onload = rs => {
    const imgBase64Path = e.target.result;
    this.setImgtoGroup(imgBase64Path);
      };
    };
    reader.readAsDataURL(event.target.files[0]);
  }

  setImgtoGroup(img) {
    this.subgroup.image = img;
  }

}
