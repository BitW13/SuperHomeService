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

  shoppingCards;

  shoppingCategories;

  typeOfPurchases;

  constructor(private purchaseService: PurchaseService, private categoryService: ShoppingCategoryService, private typeOfPurchaseService: TypeOfPurchaseService) { }

  ngOnInit() {
    this.loadItems();
  }

  loadItems() {
    this.getModels();
    this.getTypeOFPurshases();
    this.getCategories();
  }
  
  getModels() {
    this.purchaseService.getCards().subscribe((data) => {
      this.shoppingCards = data;
    });
  }

  getTypeOFPurshases(){
    this.typeOfPurchaseService.getItems().subscribe((data) => {
      this.typeOfPurchases = data;
    });
  }

  getCategories() {
    this.categoryService.getItems().subscribe((data) => {
      this.shoppingCategories = data;
    });
  }  

  addPurchase() {
    this.purchaseService.post(new Purchase()).subscribe((data) => {
      this.loadItems();
    });
  }

  addTypeOfPurchases(){
    this.typeOfPurchaseService.post(new TypeOfPurchase()).subscribe((data) => {
      this.loadItems();
    });
  }

  addCategory() {
    this.categoryService.post(new ShoppingCategory()).subscribe((data) => {
      this.loadItems();
    });
  }
}
