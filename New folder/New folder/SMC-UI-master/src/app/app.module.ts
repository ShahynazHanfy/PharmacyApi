import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr'; 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './UserComponents/login/login.component';
import { GetUsersComponent } from './UserComponents/get-users/get-users.component';
import { HttpClientModule, HttpClient } from  '@angular/common/http';
import { FormsModule }   from '@angular/forms';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import {ConfirmationService, DialogService} from 'primeng/api';
import {FieldsetModule} from 'primeng/fieldset';
import { TableModule } from 'primeng/table';
import {DialogModule} from 'primeng/dialog';
import {DataViewModule} from 'primeng/dataview';
import { PanelModule } from 'primeng/panel';
import {AccordionModule} from 'primeng/accordion';
import {TabViewModule} from 'primeng/tabview';
import { PaginatorModule } from 'primeng/paginator';
import {DropdownModule} from 'primeng/dropdown';
import {GMapModule} from 'primeng/gmap';
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import { MainComponent } from './Layout/main/main.component';
import { GetStoresComponent } from './StoreComponents/get-stores/get-stores.component';
import { SideNavComponent } from './Layout/side-nav/side-nav.component';
import { GetGroupsComponent } from './GroupComponents/get-groups/get-groups.component';
import { GroupDetailsComponent } from './GroupComponents/group-details/group-details.component';
import { GetSubgroupsComponent } from './SubgroupComponents/get-subgroups/get-subgroups.component';
import { SubgroupDetailsComponent } from './SubgroupComponents/subgroup-details/subgroup-details.component';
import { GetItemsComponent } from './ItemComponents/get-items/get-items.component';
import { ItemDetailsComponent } from './ItemComponents/item-details/item-details.component';
import { GroupSubgroupComponent } from './GroupAndSubgroup/group-subgroup/group-subgroup.component';
import { StoreDetailsComponent } from './StoreComponents/store-details/store-details.component';
import { GetTransactiontypesComponent } from './TransactionTypeComponents/get-transactiontypes/get-transactiontypes.component';
import { GetOrdersComponent } from './TransactionComponents/get-transactions/get-orders.component';
import { TransactionDetailsComponent } from './TransactionComponents/transaction-details/transaction-details.component';
import {DragDropModule} from 'primeng/dragdrop';
import {OrderListModule} from 'primeng/orderlist';
import {CardModule} from 'primeng/card';
import {CheckboxModule} from 'primeng/checkbox';
import {RadioButtonModule} from 'primeng/radiobutton';
import { UserDetailsComponent } from './UserComponents/user-details/user-details.component';
import { GetBalancesComponent } from './BalanceComponents/get-balances/get-balances.component';
import { BalanceDetailsComponent } from './BalanceComponents/balance-details/balance-details.component';
import { ExcelService } from './Services/excel.service';
import { PDFService } from './Services/pdf.service';
import { TransactionReportComponent } from './ReportsComponents/transaction-report/transaction-report.component';
import { ExpireditemsReportComponent } from './ReportsComponents/expireditems-report/expireditems-report.component';
import { GetSuppliersComponent } from './SupplierComponents/get-suppliers/get-suppliers.component';
import { SupplierDetailsComponent } from './SupplierComponents/supplier-details/supplier-details.component';
import { GetCustomersComponent } from './CustomerComponents/get-customers/get-customers.component';
import { CustomerDetailsComponent } from './CustomerComponents/customer-details/customer-details.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import {ChartModule} from 'primeng/chart';
@NgModule({
  declarations: [
    AppComponent,LoginComponent,GetUsersComponent,UserDetailsComponent,
    MainComponent,GetStoresComponent,SideNavComponent,GetGroupsComponent
    ,GroupDetailsComponent, GetSubgroupsComponent, SubgroupDetailsComponent,
     GetItemsComponent, ItemDetailsComponent, GroupSubgroupComponent, StoreDetailsComponent,
      GetTransactiontypesComponent, GetOrdersComponent, TransactionDetailsComponent,
       GetBalancesComponent, BalanceDetailsComponent, TransactionReportComponent, 
       ExpireditemsReportComponent, GetSuppliersComponent, SupplierDetailsComponent,
        GetCustomersComponent, CustomerDetailsComponent, DashboardComponent
  ],
  imports: [
    BrowserModule,HttpClientModule,FormsModule,GMapModule,FieldsetModule,TableModule,DropdownModule
    ,PanelModule,BrowserAnimationsModule,ConfirmDialogModule,OrderListModule,AccordionModule
    ,DragDropModule,DataViewModule,TabViewModule,CardModule,CheckboxModule,RadioButtonModule,ChartModule,
    DialogModule,PaginatorModule,AppRoutingModule,ToastrModule.forRoot(),TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
  })
  ],
 
  providers: [ConfirmationService, DialogService ,ExcelService,PDFService],
  bootstrap: [AppComponent]
})
export class AppModule { }
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}