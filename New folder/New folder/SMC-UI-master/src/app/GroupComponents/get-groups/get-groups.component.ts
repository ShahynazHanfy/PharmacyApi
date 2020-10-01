import { Component, OnInit } from '@angular/core';
import { Group } from 'src/app/Models/group.model';
import { GroupService } from 'src/app/Services/group.service';
import { SelectItem, ConfirmationService, DialogService } from 'primeng/api';
import { TranslateService } from '@ngx-translate/core';
import { GetSubgroupsComponent } from 'src/app/SubgroupComponents/get-subgroups/get-subgroups.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-get-groups',
  templateUrl: './get-groups.component.html',
  styleUrls: ['./get-groups.component.css'],
  
})
export class GetGroupsComponent implements OnInit {

  groups : Group[] = [];
  display: boolean = false;
  currentUserStore;
  constructor(private groupService : GroupService ,public translate: TranslateService,
    private confirmationService: ConfirmationService ,private toastr : ToastrService ) { }

  ngOnInit() {
    this.currentUserStore = localStorage.getItem('StoreId');
    this.RequiredList();
  }

  RequiredList()
  {
   this.groupService.GetAll().subscribe(
      data=>{
      this.groups = data;}
  )
  }

  DeleteGroup(GroupId) {
    this.confirmationService.confirm({
        message: 'Are you sure that you want to proceed?',
        header: 'Confirmation',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.groupService.DeleteGroup(GroupId).subscribe(data=>{
            this.RequiredList()
            this.toastr.success("Group Deleted Successfully","Remove");
          }
        );
        },
        reject: () => {
        }
    });
}


}
