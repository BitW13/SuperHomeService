import { Component, OnInit, Input } from '@angular/core';
import { TypeOfPurchase } from '../models/typeOfPurchase';

@Component({
  selector: 'app-shopping-type-item',
  templateUrl: './shopping-type-item.component.html',
  styleUrls: ['./shopping-type-item.component.scss']
})
export class ShoppingTypeItemComponent implements OnInit {

  @Input() type: TypeOfPurchase;

  isEditTypeOfPurchase: boolean = false;

  constructor() { }

  ngOnInit() {
  }

  editTypeOfPurchase(){
    this.isEditTypeOfPurchase = !this.isEditTypeOfPurchase;
  }

}
