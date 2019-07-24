import { Component, OnInit } from '@angular/core';
import { Page } from './page';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  pages = [

    new Page()
  ]

  constructor() { }

  ngOnInit() {
  }

}
