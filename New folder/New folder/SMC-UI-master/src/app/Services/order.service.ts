import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../Models/order.model';
import { environment } from 'src/environments/environment';
import { Employee } from '../Models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

    constructor(private httpClient : HttpClient) { }
   
    httpHeader={headers: new HttpHeaders({
      'content-type':'application/json',
      'Accept': '*/*'
         
    })};

    GetAll(): Observable <Order[]>{
      return this.httpClient.get<Order[]> (`${environment.Order}`,this.httpHeader) ;
  }

    GetStoreTransactions(storeId:number): Observable <Order[]>{
      return this.httpClient.get<Order[]> (`${environment.OrderByStore}${storeId}`,this.httpHeader) ;
  }
  
  insertTransaction(transaction: Order): Observable <any >{
    return this.httpClient.post<any> (`${environment.Order}`,transaction,this.httpHeader) ;
  }
    
  getTransaction(id: number): Observable <Order>{
    return this.httpClient.get<Order> (`${environment.Order}${id}`,this.httpHeader) ;
  }
  
  updateTransaction(id:number,transaction: Order): Observable <any >{
    return this.httpClient.put<any> (`${environment.Order}${id}`,transaction,this.httpHeader) ;
  }
  
  DeleteTransaction(id: number): Observable <Order>{
    return this.httpClient.get<Order> (`${environment.DeleteOrder}${id}`,this.httpHeader) ;
  }

  GetEmployees(): Observable <Employee[]>{
    return this.httpClient.get<Employee[]> (`${environment.Employee}`,this.httpHeader) ;
}
  
}
