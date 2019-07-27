import { Component, OnInit } from '@angular/core';
import { JwtService } from '../main/auth/jwt.service';
import { User } from '../main/auth/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  email: string;

  password: string;

  constructor(private service: JwtService, private router: Router) { }

  ngOnInit() {
  }

  hide = true;

  login(){

    let user: User = new User(this.email, this.password);

    this.service.login(user).subscribe(data=>{
      this.router.navigate(['home']);
    });
  }

  register(){

    let user: User = new User(this.email, this.password);

    this.service.register(user);
  }
}
