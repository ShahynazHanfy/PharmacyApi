import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './UserComponents/login/login.component';
import { GetUsersComponent } from './UserComponents/get-users/get-users.component';
import { GetStoresComponent } from './StoreComponents/get-stores/get-stores.component';
import { GroupDetailsComponent } from './GroupComponents/group-details/group-details.component';
import { GroupSubgroupComponent } from './GroupAndSubgroup/group-subgroup/group-subgroup.component';
import { SubgroupDetailsComponent } from './SubgroupComponents/subgroup-details/subgroup-details.component';
import { GetSubgroupsComponent } from './SubgroupComponents/get-subgroups/get-subgroups.component';
import { ItemDetailsComponent } from './ItemComponents/item-details/item-details.component';
import { GetItemsComponent } from './ItemComponents/get-items/get-items.component';
import { StoreDetailsComponent } from './StoreComponents/store-details/store-details.component';
import { GetTransactiontypesComponent } from './TransactionTypeComponents/get-transactiontypes/get-transactiontypes.component';
import { TransactionDetailsComponent } from './TransactionComponents/transaction-details/transaction-details.component';
import { UserDetailsComponent } from './UserComponents/user-details/user-details.component';
import { AuthorizationGuard } from './Guard/authorization.guard';
import { GetOrdersComponent } from './TransactionComponents/get-transactions/get-orders.component';
import { GetBalancesComponent } from './BalanceComponents/get-balances/get-balances.component';
import { BalanceDetailsComponent } from './BalanceComponents/balance-details/balance-details.component';
import { TransactionReportComponent } from './ReportsComponents/transaction-report/transaction-report.component';
import { ExpireditemsReportComponent } from './ReportsComponents/expireditems-report/expireditems-report.component';
import { GetSuppliersComponent } from './SupplierComponents/get-suppliers/get-suppliers.component';
import { SupplierDetailsComponent } from './SupplierComponents/supplier-details/supplier-details.component';
import { GetCustomersComponent } from './CustomerComponents/get-customers/get-customers.component';
import { CustomerDetailsComponent } from './CustomerComponents/customer-details/customer-details.component';
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  {path:'' , component:LoginComponent},
  {path:'Login' , component:LoginComponent  },

  {path:'Dashboard' , component:DashboardComponent},

  {path:'Stores' , component:GetStoresComponent ,  
  canActivate: [AuthorizationGuard] ,
  data: { roles: ['Admin' , 'Super Admin'] }},

  {path:'StoreDetails/:StoreId' , component:StoreDetailsComponent ,
  canActivate: [AuthorizationGuard] ,
  data: { roles: ['Admin' , 'Super Admin'] }},

  {path:'Suppliers' , component:GetSuppliersComponent ,  
  canActivate: [AuthorizationGuard] ,
  data: { roles: ['Admin' , 'Super Admin'] }},

  
  {path:'SupplierDetails/:SupplierId' , component:SupplierDetailsComponent ,
  canActivate: [AuthorizationGuard] ,
  data: { roles: ['Admin' , 'Super Admin'] }},
  
  {path:'Customers' , component:GetCustomersComponent ,  
  canActivate: [AuthorizationGuard] ,
  data: { roles: ['Admin' , 'Super Admin'] }},


  {path:'CustomerDetails/:CustomerId' , component:CustomerDetailsComponent ,
  canActivate: [AuthorizationGuard] ,
  data: { roles: ['Admin' , 'Super Admin'] }},

  {path:'GroupsAndSubgroups' , component:GroupSubgroupComponent,
  canActivate: [AuthorizationGuard] ,
  data: { roles: ['Admin' , 'Super Admin'] } },

  {path:'GroupDetails/:GroupId' , component:GroupDetailsComponent ,
   canActivate: [AuthorizationGuard] ,
  data: { roles: ['Admin' , 'Super Admin'] }},

  {path:'SubgroupDetails/:SubgroupId' , component:SubgroupDetailsComponent , 
  canActivate: [AuthorizationGuard] ,
  data: { roles: ['Admin' , 'Super Admin'] } },

  {path:'ViewGrpSubgroups/:groupId' , component:GetSubgroupsComponent ,
  canActivate: [AuthorizationGuard] ,
  data: { roles: ['Admin' , 'Super Admin'] }},

  {path:'ItemDetails/:ItemId' , component:ItemDetailsComponent ,
  canActivate: [AuthorizationGuard] ,
  data: { roles: ['Admin' , 'Super Admin'] }},
  
  {path:'Items' , component:GetItemsComponent ,
  canActivate: [AuthorizationGuard] ,
  data: { roles: ['Admin' , 'Super Admin'] }},
  {path:'Types' , component:GetTransactiontypesComponent },
  
  {path:'Orders' , component:GetOrdersComponent },

  {path:'OrderDetails/:OrderId' , component:TransactionDetailsComponent },
  
  {path:'Users' , component:GetUsersComponent ,
  canActivate: [AuthorizationGuard] ,
  data: { roles: ['Admin' , 'Super Admin'] } },
  
  {path:'UserDetails/:UserId' , component:UserDetailsComponent ,
  canActivate: [AuthorizationGuard] ,
  data: { roles: ['Admin' , 'Super Admin'] }  },

  {path:'Balances' , component:GetBalancesComponent },

  {path:'BalanceDetails/:BalanceId' , component:BalanceDetailsComponent },

  {path:'Reports' , component:TransactionReportComponent },
  // {path:'ExpiredItems' , component:ExpireditemsReportComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
