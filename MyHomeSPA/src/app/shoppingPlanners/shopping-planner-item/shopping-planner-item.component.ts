import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ShoppingCard } from '../models/shoppingCard';
import { ShoppingCategory } from '../models/shoppingCategory';
import { TypeOfPurchase } from '../models/typeOfPurchase';
import { PurchaseService } from '../services/purchase.service';
import { Purchase } from '../models/purchase';

@Component({
  selector: 'tr[app-shopping-planner-item]',
  templateUrl: './shopping-planner-item.component.html',
  styleUrls: ['./shopping-planner-item.component.scss']
})
export class ShoppingPlannerItemComponent implements OnInit {

  @Input() card: ShoppingCard;

  @Input() shoppingCategories: ShoppingCategory[];

  @Input() typeOfPurchases: TypeOfPurchase[];

  @Output() loadItems = new EventEmitter();

  

  saveItemValue: Purchase;

  isEditItem: boolean = false;

  constructor(private service: PurchaseService) { }

  switchingIsEditItem(){
    this.isEditItem = !this.isEditItem;
  }

  ngOnInit() {
  }

  edit(){
    this.switchingIsEditItem();
    this.saveItemValue = this.getCopy(this.card.purchase);
  }

  save(){
    this.saveItemValue = null;
    this.switchingIsEditItem();
    this.service.put(this.card.purchase).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  cancel(){
    this.card.purchase = this.getCopy(this.saveItemValue);
    this.saveItemValue = null;
    this.switchingIsEditItem();
  }

  delete(){
    this.service.delete(this.card.purchase).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  getCopy(item: Purchase): Purchase {

      let copy = new Purchase();

      copy.id = item.id;
      copy.name = item.name;
      copy.description = item.description;
      copy.typeOfPurchaseId = item.typeOfPurchaseId;
      copy.amount = item.amount;
      copy.priceOfOneUnit = item.priceOfOneUnit;
      copy.getTotalPrice();
      copy.isDone = item.isDone;
      copy.shoppingCategoryId = item.shoppingCategoryId;

      return copy;
  }
}
