import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Customer } from '../Models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  constructor(private httpClient : HttpClient) { }
 
  httpHeader={headers: new HttpHeaders({
    'content-type':'application/json',
    'Accept': '*/*'
       
  })};

  GetAll(): Observable <Customer[]>{
    return this.httpClient.get<Customer[]> (`${environment.Customer}`,this.httpHeader) ;
}

insertCustomer(newCustomer: Customer): Observable <any >{
  return this.httpClient.post<any> (`${environment.Customer}`,newCustomer,this.httpHeader) ;
}
  
getCustomer(id: number): Observable <Customer>{
  return this.httpClient.get<Customer> (`${environment.Customer}${id}`,this.httpHeader) ;
}

updateCustomer(id:number,customer: Customer): Observable <any >{
  return this.httpClient.put<any> (`${environment.Customer}${id}`,customer,this.httpHeader) ;
}

DeleteCustomer(id: number): Observable <Customer>{
  return this.httpClient.get<Customer> (`${environment.DeleteCustomer}${id}`,this.httpHeader) ;
}
}