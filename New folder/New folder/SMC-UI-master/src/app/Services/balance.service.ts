import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Store } from '../Models/store.model';
import { Group } from '../Models/group.model';
import { Balance } from '../Models/balance.model';

@Injectable({
  providedIn: 'root'
})
export class BalanceService {
  constructor(private httpClient : HttpClient) { }
 
  httpHeader={headers: new HttpHeaders({
    'content-type':'application/json',
    'Accept': '*/*'
       
  })};

  GetAll(): Observable <Balance[]>{
    return this.httpClient.get<Balance[]> (`${environment.Balance}`,this.httpHeader) ;
}

GetStoreBalances(storeId: number): Observable <Balance[]>{
  return this.httpClient.get<Balance[]> (`${environment.BalanceByStore}${storeId}`,this.httpHeader) ;
}
insertBalance(newBalance: Balance): Observable <Balance>{
  return this.httpClient.post<Balance> (`${environment.Balance}`,newBalance,this.httpHeader) ;
}
  
getBalance(id: number): Observable <Balance>{
  return this.httpClient.get<Balance> (`${environment.Balance}${id}`,this.httpHeader) ;
}

updateBalance(id:number,balance: Balance): Observable <any >{
  return this.httpClient.put<any> (`${environment.Balance}${id}`,balance,this.httpHeader) ;
}

DeleteBalance(id: number): Observable <Balance>{
  return this.httpClient.get<Balance> (`${environment.DeleteBalance}${id}`,this.httpHeader) ;
}

GetLastBalance(storeId : number):Observable<Balance>{
  return this.httpClient.get<Balance> (`${environment.LastBalance}${storeId}`,this.httpHeader) ;
}
GetGenericLastBalance():Observable<Balance>{
  return this.httpClient.get<Balance> (`${environment.GenericLastBalance}`,this.httpHeader) ;
}
}