import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { OrderType } from '../Models/ordertype.model';

@Injectable({
  providedIn: 'root'
})
export class OrdertypeService {

  constructor(private httpClient : HttpClient) { }
 
  httpHeader={headers: new HttpHeaders({
    'content-type':'application/json',
    'Accept': '*/*'
       
  })};

  GetAll(): Observable <OrderType[]>{
    return this.httpClient.get<OrderType[]> (`${environment.OrderType}`,this.httpHeader) ;
}

GetActiveTypes(): Observable <OrderType[]>{
  return this.httpClient.get<OrderType[]> (`${environment.ActiveTypes}`,this.httpHeader) ;
}

insertType(newType: OrderType): Observable <any >{
  return this.httpClient.post<any> (`${environment.OrderType}`,newType,this.httpHeader) ;
}
  
getType(id: number): Observable <OrderType>{
  return this.httpClient.get<OrderType> (`${environment.OrderType}${id}`,this.httpHeader) ;
}

updateType(id:number,type: OrderType): Observable <any >{
  return this.httpClient.put<any> (`${environment.OrderType}${id}`,type,this.httpHeader) ;
}

DeleteType(id: number): Observable <OrderType>{
  return this.httpClient.get<OrderType> (`${environment.DeleteType}${id}`,this.httpHeader) ;
}
}
