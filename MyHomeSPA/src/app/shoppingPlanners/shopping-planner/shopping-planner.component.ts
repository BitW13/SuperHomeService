import { Component, OnInit } from '@angular/core';
import { ShoppingCard } from '../models/shoppingCard';
import { ShoppingCategory } from '../models/shoppingCategory';
import { TypeOfPurchase } from '../models/typeOfPurchase';

@Component({
  selector: 'app-shopping-planner',
  templateUrl: './shopping-planner.component.html',
  styleUrls: ['./shopping-planner.component.scss']
})
export class ShoppingPlannerComponent implements OnInit {

  shoppingCards = [

    new ShoppingCard(),

    new ShoppingCard(),

    new ShoppingCard(),

    new ShoppingCard(),

    new ShoppingCard()
  ]

  shoppingCategories = [

    new ShoppingCategory(),

    new ShoppingCategory()
  ]

  typeOfPurchases = [

    new TypeOfPurchase(),

    new TypeOfPurchase(),

    new TypeOfPurchase(),

    new TypeOfPurchase()
  ]

  constructor() { }

  ngOnInit() {
  }

  addCategory(){
    
  }

  addShoppingCard(){
    
  }
}
