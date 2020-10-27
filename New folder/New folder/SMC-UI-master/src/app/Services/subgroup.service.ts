import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Subgroup } from '../Models/subgroup.model';

@Injectable({
  providedIn: 'root'
})
export class SubgroupService {
  
  constructor(private httpClient : HttpClient) { }
  
  httpHeader={headers: new HttpHeaders({
    'content-type':'application/json',
    'Accept': '*/*'
       
  })};
  GetAll(): Observable <Subgroup[]>{
    return this.httpClient.get<Subgroup[]> (`${environment.Subgroup}`,this.httpHeader) ;
}


insertSubgroup(newsubgroup: Subgroup): Observable <any >{
  return this.httpClient.post<any> (`${environment.Subgroup}`,newsubgroup,this.httpHeader) ;
}
  
getSubgroup(id: number): Observable <Subgroup>{
  return this.httpClient.get<Subgroup> (`${environment.Subgroup}${id}`,this.httpHeader) ;
}

updateSubgroup(id:number,subgroup: Subgroup): Observable <any >{
  return this.httpClient.put<any> (`${environment.Subgroup}${id}`,subgroup,this.httpHeader) ;
}

DeleteSubgroup(id: number): Observable <Subgroup>{
  return this.httpClient.get<Subgroup> (`${environment.Subgroup}${id}`,this.httpHeader) ;
}

getSubgroupsByGrpId(id: number): Observable <Subgroup[]>{
  return this.httpClient.get<Subgroup[]> (`${environment.SubgroupByGrpId}${id}`,this.httpHeader) ;
}

}
