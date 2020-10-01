import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/Models/item.model';
import { ItemService } from 'src/app/Services/item.service';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService } from 'primeng/api';
import { PDFService } from 'src/app/Services/pdf.service';
import pdfMake from "pdfmake/build/pdfmake";  
import pdfFonts from "pdfmake/build/vfs_fonts";  
import { Group } from 'src/app/Models/group.model';
import { Subgroup } from 'src/app/Models/subgroup.model';
import { GroupService } from 'src/app/Services/group.service';
import { SubgroupService } from 'src/app/Services/subgroup.service';
import { ToastrService } from 'ngx-toastr';
pdfMake.vfs = pdfFonts.pdfMake.vfs;  
@Component({
  selector: 'app-get-items',
  templateUrl: './get-items.component.html',
  styleUrls: ['./get-items.component.css']
})
export class GetItemsComponent implements OnInit {

  Allitems : Item[] = [];
  FilteredItems : Item[] = [];
  groups : Group[] = [];
  subgroups : Subgroup[] = [];

  display: boolean = false;
  currentUserStore;
  
  constructor(private itemService : ItemService ,public translate: TranslateService,
    private groupService : GroupService , private subgroupService : SubgroupService,
    private confirmationService: ConfirmationService,private pdfService : PDFService ,
    private toastr : ToastrService) { }

  ngOnInit() {
    this.currentUserStore = localStorage.getItem('StoreId');
    this.RequiredList();
  }

  RequiredList()
  {
   this.itemService.GetAll().subscribe(data=>{this.Allitems = data; this.FilteredItems = data})
   this.groupService.GetAll().subscribe(data=>{this.groups = data;})
   this.subgroupService.GetAll().subscribe(data=>{this.subgroups = data;})
  }

  DeleteItem(itemId) {
    this.confirmationService.confirm({
        message: 'Are you sure that you want to proceed?',
        header: 'Confirmation',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.itemService.DeleteItem(itemId).subscribe(data=>{
            this.RequiredList()
            this.toastr.success("Item Deleted Successfully","Remove");
          }
        );
        },
        reject: () => {
         
        }
    });
}

exportPdf()
{
this.pdfService.generatePdf('download','Goods',this.Allitems,'item');
}

onGroupChange(grpId)
{
  this.subgroupService.getSubgroupsByGrpId(grpId).subscribe(data=>{this.subgroups = data;})
  this.FilteredItems = this.Allitems.filter(x => x.Subgroup.GroupId == grpId)
}

onSubgroupChange(subgrpId)
{
  this.FilteredItems = this.Allitems.filter(x => x.SubgroupId == subgrpId)

}

// exportPdf()
// {
//   let docDefinition = {  
//     header: 'C#Corner PDF Header',  
//     content: 'Sample PDF generated with Angular and PDFMake for C#Corner Blog'  
//   };  
//    pdfMake.createPdf(docDefinition).open();  
// }
}
