import { Component, OnInit, Input } from '@angular/core';
import { Subgroup } from 'src/app/Models/subgroup.model';
import { SubgroupService } from 'src/app/Services/subgroup.service';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, DynamicDialogRef, DynamicDialogConfig } from 'primeng/api';
import { ActivatedRoute } from '@angular/router';
import { GroupService } from 'src/app/Services/group.service';
import { Group } from 'src/app/Models/group.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-get-subgroups',
  templateUrl: './get-subgroups.component.html',
  styleUrls: ['./get-subgroups.component.css']
})
export class GetSubgroupsComponent implements OnInit {

  @Input() groupId: number;
  subgroups : Subgroup[] = [];
  group : Group;
  currentUserStore;
  
  constructor(private subgroupService : SubgroupService ,
    private route : ActivatedRoute ,public translate: TranslateService,
    private groupService : GroupService,private toastr : ToastrService,
    private confirmationService: ConfirmationService) {

     }

  ngOnInit() {
    this.currentUserStore = localStorage.getItem('StoreId');
    this.route.paramMap.subscribe(params => {
      this.groupId = +params.get('groupId');
    });
    this.RequiredList();
  }

  RequiredList()
  {
   
    if(this.groupId == 0)
    {
      this.subgroupService.GetAll().subscribe(
        data=>{
        this.subgroups = data;});
    }
    else{
      this.groupService.getGroup(this.groupId).subscribe(
        data => {
          this.group = data;
        });
      this.subgroupService.getSubgroupsByGrpId(this.groupId).subscribe(
        data=>{
        this.subgroups = data;});
    }
 
  }

  DeleteSubgroup(SubroupId) {
    this.confirmationService.confirm({
        message: 'Are you sure that you want to proceed?',
        header: 'Confirmation',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.subgroupService.DeleteSubgroup(SubroupId).subscribe(data=>{
            this.RequiredList()
            this.toastr.success("SubGroup Deleted Successfully","Remove");
          }
        );
        },
        reject: () => {
         
        }
    });
}
}
