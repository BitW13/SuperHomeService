import { Component, OnInit } from '@angular/core';
import { ShoppingCategory } from '../models/shoppingCategory';
import { TypeOfPurchase } from '../models/typeOfPurchase';
import { PurchaseService } from '../services/purchase.service';
import { ShoppingCategoryService } from '../services/shopping-category.service';
import { TypeOfPurchaseService } from '../services/type-of-purchase.service';
import { Purchase } from '../models/purchase';

@Component({
  selector: 'app-shopping-planner',
  templateUrl: './shopping-planner.component.html',
  styleUrls: ['./shopping-planner.component.scss']
})
export class ShoppingPlannerComponent implements OnInit {

  cards;

  categories;

  typeOfPurchases;

  constructor(private purchaseService: PurchaseService, private categoryService: ShoppingCategoryService, private typeOfPurchaseService: TypeOfPurchaseService) { }

  ngOnInit() {
    this.loadItems();
  }

  loadItems() {
    this.getModels();
    this.getTypeOfPurshases();
    this.getCategories();
  }
  
  getModels() {

    this.purchaseService.getCards().subscribe((data) => {
      this.cards = data;
    });
  }

  getTypeOfPurshases(){

    this.typeOfPurchaseService.getItems().subscribe((data) => {
      this.typeOfPurchases = data;
    });
  }

  getCategories() {

    this.categoryService.getItems().subscribe((data) => {
      this.categories = data;
    });
  }  

  addPurchase() {

    this.purchaseService.post(new Purchase()).subscribe((data) => {
      this.getModels();
    });
  }

  addTypeOfPurchases(){

    this.typeOfPurchaseService.post(new TypeOfPurchase()).subscribe((data) => {
      this.getTypeOfPurshases();
    });
  }

  addCategory() {
    
    this.categoryService.post(new ShoppingCategory()).subscribe((data) => {
      this.getCategories();
    });
  }
}
