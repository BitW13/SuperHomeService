import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { JwtService } from './jwt.service';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(private service: JwtService, private router: Router) { }

  canActivate() {
    if(!this.service.logIn){
      this.router.navigate(['']);
      return false; 
    }
    else{
      return true;
    }
  }
}