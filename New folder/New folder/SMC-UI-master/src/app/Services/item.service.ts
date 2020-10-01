import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Item } from '../Models/item.model';
import { OrderDetails } from '../Models/orderdetails.model';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private httpClient : HttpClient) { }
 
  httpHeader={headers: new HttpHeaders({
    'content-type':'application/json',
    'Accept': '*/*'
       
  })};

  GetAll(): Observable <Item[]>{
    return this.httpClient.get<Item[]> (`${environment.Item}`,this.httpHeader) ;
}

insertItem(newStore: Item): Observable <any >{
  return this.httpClient.post<any> (`${environment.Item}`,newStore,this.httpHeader) ;
}
  
getItem(id: number): Observable <Item>{
  return this.httpClient.get<Item> (`${environment.Item}${id}`,this.httpHeader) ;
}

updateItem(id:number,store: Item): Observable <any >{
  return this.httpClient.put<any> (`${environment.Item}${id}`,store,this.httpHeader) ;
}

DeleteItem(id: number): Observable <Item>{
  return this.httpClient.get<Item> (`${environment.DeleteItem}${id}`,this.httpHeader) ;
}

ExpiredItemsWithinDays(NOF: number): Observable <OrderDetails[]>{
  return this.httpClient.get<OrderDetails[]> (`${environment.ExpiredItems}${NOF}`,this.httpHeader) ;
}
}
