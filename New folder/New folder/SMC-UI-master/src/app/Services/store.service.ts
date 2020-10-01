import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Store } from '../Models/store.model';

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  constructor(private httpClient : HttpClient) { }
 
  httpHeader={headers: new HttpHeaders({
    'content-type':'application/json',
    'Accept': '*/*'
       
  })};

  GetAll(): Observable <Store[]>{
    return this.httpClient.get<Store[]> (`${environment.Store}`,this.httpHeader) ;
}

insertStore(newStore: Store): Observable <any >{
  return this.httpClient.post<any> (`${environment.Store}`,newStore,this.httpHeader) ;
}
  
getStore(id: number): Observable <Store>{
  return this.httpClient.get<Store> (`${environment.Store}${id}`,this.httpHeader) ;
}

updateStore(id:number,store: Store): Observable <any >{
  return this.httpClient.put<any> (`${environment.Store}${id}`,store,this.httpHeader) ;
}

DeleteStore(id: number): Observable <Store>{
  return this.httpClient.get<Store> (`${environment.DeleteStore}${id}`,this.httpHeader) ;
}
}