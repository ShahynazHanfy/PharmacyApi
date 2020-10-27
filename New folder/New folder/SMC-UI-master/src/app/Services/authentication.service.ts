import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map, catchError } from 'rxjs/operators';
import { Observable, BehaviorSubject } from 'rxjs';
import { User } from 'src/app/Models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {


  public fullname : string;
  private userroles = new BehaviorSubject<string>(localStorage.getItem('UserRoles'));
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  public static isLogged = false;

  AccessToken : string;
  constructor(private httpClient: HttpClient ) { 
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  login(userName, password) {
         var data = "username="+userName+"&password="+password+"&grant_type=password";
        var reqHeader = new HttpHeaders({ 
          'Content-Type': 'application/x-www-form-urlencoded',
          'Accept':'*/*'
      });
  
    return this.httpClient.post<any>(`${environment.Login}`,data, {headers:reqHeader})        
    .pipe(map(user => {
               
           localStorage.setItem('currentUser', JSON.stringify(user));
           this.fullname = user.fullname;
           localStorage.setItem('UserName', user.userName);
           localStorage.setItem('StoreId', user.storeId);
           localStorage.setItem('UserRoles', user.userRoles);
           this.currentUserSubject.next(user);
            return user;
        }));
}
  
isAuthorized(allowedRoles : string[]):boolean
{ 
const Userroles = localStorage.getItem('UserRoles');
const found = allowedRoles.some(r=> Userroles.includes(r));
 return found;
}

getToken(){
  const currentUser = JSON.parse(localStorage.getItem('currentUser') || '{}');
  return currentUser.access_token;
}


LogOut()
{
  console.log("logout clicked");
  localStorage.removeItem('currentUser');
  localStorage.removeItem('UserName');
  localStorage.removeItem('StoreId');
  localStorage.removeItem('UserRoles');
  AuthenticationService.isLogged = false;
  this.currentUserSubject.next(null);
}

public get currentUserValue(): User {
  return this.currentUserSubject.value;
}


}
