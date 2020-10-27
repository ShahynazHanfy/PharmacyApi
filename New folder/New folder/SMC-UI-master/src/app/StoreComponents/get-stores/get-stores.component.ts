import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { StoreService } from 'src/app/Services/store.service';
import { ConfirmationService } from 'primeng/api';
import { PDFService } from 'src/app/Services/pdf.service';
import { ToastrService } from 'ngx-toastr';
// import { ToastrService } from 'ngx-toastr';
// declare var google: any;
@Component({
  selector: 'app-get-stores',
  templateUrl: './get-stores.component.html',
  styleUrls: ['./get-stores.component.css']
})
export class GetStoresComponent implements OnInit {

  //Map
  options: any;
  overlays: any[];

//currentUserStore
currentUserStore ;

  AllStores : any;
  FilteredStores : any;
  cols : any;
  currentLang =this.translate.currentLang;

    constructor(private translate : TranslateService ,private toastr : ToastrService,
      private storeService : StoreService ,private pdfService : PDFService,
      private confirmationService: ConfirmationService){

    }

    ngOnInit() {
      this.currentUserStore = localStorage.getItem('StoreId');
      this.RequiredList();
      this.translate.onLangChange.subscribe(() => {
        this.currentLang = this.translate.currentLang;
        this.onLangChange();
      }
      );
      this.onLangChange();
  //     this.options = {
  //       center: {lat: 36.890257, lng: 30.707417},
  //       zoom: 12
  //   };
  //   this.overlays = [
  //     new google.maps.Marker({position: {lat: 36.879466, lng: 30.667648}, title:"Konyaalti"}),
  //     new google.maps.Marker({position: {lat: 36.883707, lng: 30.689216}, title:"Ataturk Park"}),
  //     new google.maps.Marker({position: {lat: 36.885233, lng: 30.702323}, title:"Oldtown"}),
  //     new google.maps.Polygon({paths: [
  //         {lat: 36.9177, lng: 30.7854},{lat: 36.8851, lng: 30.7802},{lat: 36.8829, lng: 30.8111},{lat: 36.9177, lng: 30.8159}
  //     ], strokeOpacity: 0.5, strokeWeight: 1,fillColor: '#1976D2', fillOpacity: 0.35
  //     }),
  //     new google.maps.Circle({center: {lat: 36.90707, lng: 30.56533}, fillColor: '#1976D2', fillOpacity: 0.35, strokeWeight: 1, radius: 1500}),
  //     new google.maps.Polyline({path: [{lat: 36.86149, lng: 30.63743},{lat: 36.86341, lng: 30.72463}], geodesic: true, strokeColor: '#FF0000', strokeOpacity: 0.5, strokeWeight: 2})
  // ];
    }
  
    onLangChange(){
      if (this.currentLang === 'en') {
        this.cols = [
          {  header: 'Name' , field:'Name' },
          {  header: 'Address' , field:'Address' },
          {  header: 'Area' , field:'Area' },
          {  header: 'Telephone' , field:'Telephone' },
          // {  header: 'Location' , field:'Location' },
          {  header: 'Remarks' , field:'Remarks' }
        ];
       }
      else {
        this.cols = [
          {  header: 'اسم الفرع' , field:'Name' },
          {  header: 'العنوان' , field:'Address' },
          {  header: 'المساحه' , field:'Area' },
          {  header: 'رقم التليفون' , field:'Telephone' },
          // {  header: 'الموقع' , field:'Location' },
          {  header: 'ملاحظات' , field:'Remarks' }  
        
        ];
        
      }
    }
  
    RequiredList(){
  this.storeService.GetAll().subscribe(
    data=>{
      this.AllStores = data;
      this.FilteredStores = data;
    }
  );
  }
  
  confirm1(StoreId) {
    this.confirmationService.confirm({
        message: 'Are you sure that you want to proceed?',
        header: 'Confirmation',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.storeService.DeleteStore(StoreId).subscribe(data=>{
            this.RequiredList()
            this.toastr.success("Store Deleted Successfully","Remove");
          }
        );
        },
        reject: () => {
          console.log(StoreId)
        }
    });
}
  
exportPdf()
{
this.pdfService.generatePdf('download','Stores',this.AllStores,'store');
}

}
