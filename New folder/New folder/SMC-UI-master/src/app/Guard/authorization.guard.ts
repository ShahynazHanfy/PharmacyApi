import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../Services/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationGuard implements CanActivate {
  AuthorizedRoles : string[] = [];
  constructor(private router: Router,
    private authenticationService: AuthenticationService ) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot)
  {
    const currentUser = this.authenticationService.currentUserValue;
    this.AuthorizedRoles = route.data.roles;
    if (currentUser) { 
         
     return this.authenticationService.isAuthorized(this.AuthorizedRoles);;
        }
       // not logged in so redirect to login page with the return url
    this.router.navigate(['/Login'])
    return false;
  }

}
