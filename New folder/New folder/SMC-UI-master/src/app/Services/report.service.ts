import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TransactionReport } from '../Models/transactionreport.model';
import { Balance } from '../Models/balance.model';
import { ItemBalance } from '../Models/itembalance.model';
import { OrderDetails } from '../Models/orderdetails.model';
import { Order } from '../Models/order.model';
import { Supplier } from '../Models/supplier.model';


@Injectable({
  providedIn: 'root'
})
export class ReportService {
  constructor(private httpClient : HttpClient) { }
 
  httpHeader={headers: new HttpHeaders({
    'content-type':'application/json',
    'Accept': '*/*'      
  })};

  GetItemsReachedReorderLevelForStore(storeId :  number): Observable <ItemBalance[]>{
    return this.httpClient.get<ItemBalance[]> (`${environment.ItemsWhichNeedToReordered}${storeId}`,this.httpHeader) ;
}

TransactionReport(report : TransactionReport):Observable<Order[]>{
  return this.httpClient.post<Order[]> (`${environment.TransactionReport}`,report ,this.httpHeader);
}

GetTop10SuppliersForItem(itemId :  number): Observable <Supplier[]>{
  return this.httpClient.get<Supplier[]> (`${environment.ItemsWhichNeedToReordered}${itemId}`,this.httpHeader) ;
}
  // TransactionReport(report : TransactionReport){
  //   return this.httpClient.post<any> (`${environment.TransactionReport}`,report ,this.httpHeader)
  //   .subscribe(response => this.downLoadFile2(response,"application/octet-stream"))
  // }

  // downLoadFile2(data: any, type: string) {
  //   console.log("file download 2")
  //   let blob = new Blob([data], { type: type});
  //   let url = window.URL.createObjectURL(blob);
  //   let pwa = window.open(url);
  //   if (!pwa || pwa.closed || typeof pwa.closed == 'undefined') {
  //       alert( 'Please disable your Pop-up blocker and try again.');
  //   }
  // }
}