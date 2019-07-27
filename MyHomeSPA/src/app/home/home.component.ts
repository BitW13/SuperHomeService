import { Component, OnInit } from '@angular/core';
import { JwtService } from '../main/auth/jwt.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private service: JwtService) { }

  ngOnInit() {
  }

  logOut(){
    this.service.logOut();
  }
}
