import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../Models/user.model';
import { environment } from 'src/environments/environment';
import { Role } from '../Models/role.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private httpClient : HttpClient) { }
 
  httpHeader={headers: new HttpHeaders({
    'content-type':'application/json',
    'Accept': '*/*'
       
  })};

  RegisterUser(newUser: User): Observable <any >{
    return this.httpClient.post<any>(`${environment.Register}`,newUser,this.httpHeader) ;
  }

  GetUsers(storeId): Observable <User[] >{
    return this.httpClient.get<User[]> (`${environment.Users}${storeId}`,this.httpHeader) ;
  }

  GetRoles():Observable<Role[]>{
    return this.httpClient.get<Role[]>(`${environment.Roles}`, this.httpHeader);
  }

  GetUser(id: string): Observable <User>{
    return this.httpClient.get<User> (`${environment.User}${id}`,this.httpHeader) ;
  }

  UpdateUser(user: User): Observable <any >{
    return this.httpClient.post<any> (`${environment.Update}`,user,this.httpHeader) ;
  }

  DeleteUser(user: User): Observable <any >{
    return this.httpClient.post<any> (`${environment.Delete}`,user,this.httpHeader) ;
  }
}
