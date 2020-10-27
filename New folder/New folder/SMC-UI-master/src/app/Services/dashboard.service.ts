import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MonthBalance } from '../Models/MonthBalance.model';
import { Order } from '../Models/order.model';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  constructor(private httpClient : HttpClient) { }
 
  httpHeader={headers: new HttpHeaders({
    'content-type':'application/json',
    'Accept': '*/*'
       
  })};

 GetYearBalance():Observable<MonthBalance[]>
 {
     return this.httpClient.get<MonthBalance[]>(`${environment.YearBalance}`,this.httpHeader)
 }

 GetYearBalancePerQuarter():Observable<MonthBalance[]>
 {
     return this.httpClient.get<MonthBalance[]>(`${environment.YearBalancePerQuarter}`,this.httpHeader)
 }

 GetQuarterBalancePerMonth(QuarterNum:number):Observable<MonthBalance[]>
 {
     return this.httpClient.get<MonthBalance[]>(`${environment.QuarterBalancePerMonth}${QuarterNum}`,this.httpHeader)
 }

  GetQuarterBalance(QuarterNum:number):Observable<MonthBalance>
 {
     return this.httpClient.get<MonthBalance>(`${environment.QuarterBalance}${QuarterNum}`,this.httpHeader)
 }

 GetLastInOrder():Observable<Order>
 {
     return this.httpClient.get<Order>(`${environment.LastInOrder}`,this.httpHeader)
 }

 GetLastOutOrder():Observable<Order>
 {
     return this.httpClient.get<Order>(`${environment.LastOutOrder}`,this.httpHeader)
 }
//  GetMonthBalanceForQuarter(QuarterNum:number):Observable<MonthBalance[]>
//  {
//      return this.httpClient.get<MonthBalance[]>(`${environment.QuarterMonthBalanceDetails}${QuarterNum}`,this.httpHeader)
//  }

}