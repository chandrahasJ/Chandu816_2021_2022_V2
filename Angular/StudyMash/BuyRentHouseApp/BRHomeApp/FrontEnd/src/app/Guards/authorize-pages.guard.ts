import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthorizePagesGuard implements CanActivate {
  constructor(public router : Router, private authService : AuthService){

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):
    Observable<boolean | UrlTree> |boolean | UrlTree {
    if (!this.authService.isAuthenticated()) {
      this.router.navigate(['/user/login']);
      return false;
    }
    return true;
  }



}
