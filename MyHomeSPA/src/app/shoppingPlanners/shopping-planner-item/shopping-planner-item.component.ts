import { Component, OnInit, Input } from '@angular/core';
import { ShoppingCard } from '../models/shoppingCard';
import { ShoppingCategory } from '../models/shoppingCategory';
import { TypeOfPurchase } from '../models/typeOfPurchase';

@Component({
  selector: 'tr[app-shopping-planner-item]',
  templateUrl: './shopping-planner-item.component.html',
  styleUrls: ['./shopping-planner-item.component.scss']
})
export class ShoppingPlannerItemComponent implements OnInit {

  @Input() card: ShoppingCard;

  @Input() shoppingCategories: ShoppingCategory[];

  @Input() typeOfPurchases: TypeOfPurchase[];

  isEditShoppingCard: boolean = false;

  constructor() { }

  ngOnInit() {
  }

  editShoppingCard(){
    this.isEditShoppingCard = !this.isEditShoppingCard;
  }

}
