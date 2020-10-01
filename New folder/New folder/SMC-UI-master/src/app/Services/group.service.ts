import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Store } from '../Models/store.model';
import { Group } from '../Models/group.model';

@Injectable({
  providedIn: 'root'
})
export class GroupService {
  constructor(private httpClient : HttpClient) { }
 
  httpHeader={headers: new HttpHeaders({
    'content-type':'application/json',
    'Accept': '*/*'
       
  })};

  GetAll(): Observable <Group[]>{
    return this.httpClient.get<Group[]> (`${environment.Group}`,this.httpHeader) ;
}

insertGroup(newGroup: Group): Observable <any >{
  return this.httpClient.post<any> (`${environment.Group}`,newGroup,this.httpHeader) ;
}
  
getGroup(id: number): Observable <Group>{
  return this.httpClient.get<Group> (`${environment.Group}${id}`,this.httpHeader) ;
}

updateGroup(id:number,group: Group): Observable <any >{
  return this.httpClient.put<any> (`${environment.Group}${id}`,group,this.httpHeader) ;
}

DeleteGroup(id: number): Observable <Group>{
  return this.httpClient.get<Group> (`${environment.DeleteGroup}${id}`,this.httpHeader) ;
}
}