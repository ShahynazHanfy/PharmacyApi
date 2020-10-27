import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Supplier } from '../Models/supplier.model';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {
  constructor(private httpClient : HttpClient) { }
 
  httpHeader={headers: new HttpHeaders({
    'content-type':'application/json',
    'Accept': '*/*'
       
  })};

  GetAll(): Observable <Supplier[]>{
    return this.httpClient.get<Supplier[]> (`${environment.Supplier}`,this.httpHeader) ;
}

insertSupplier(newSupplier: Supplier): Observable <any >{
  return this.httpClient.post<any> (`${environment.Supplier}`,newSupplier,this.httpHeader) ;
}
  
getSupplier(id: number): Observable <Supplier>{
  return this.httpClient.get<Supplier> (`${environment.Supplier}${id}`,this.httpHeader) ;
}

updateSupplier(id:number,supplier: Supplier): Observable <any >{
  return this.httpClient.put<any> (`${environment.Supplier}${id}`,supplier,this.httpHeader) ;
}

DeleteSupplier(id: number): Observable <Supplier>{
  return this.httpClient.get<Supplier> (`${environment.DeleteSupplier}${id}`,this.httpHeader) ;
}
}