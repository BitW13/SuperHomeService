import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ShoppingCard } from '../models/shoppingCard';
import { ShoppingCategory } from '../models/shoppingCategory';
import { TypeOfPurchase } from '../models/typeOfPurchase';
import { PurchaseService } from '../services/purchase.service';
import { Purchase } from '../models/purchase';

@Component({
  selector: 'app-shopping-planner-item',
  templateUrl: './shopping-planner-item.component.html',
  styleUrls: ['./shopping-planner-item.component.scss']
})
export class ShoppingPlannerItemComponent implements OnInit {

  panelOpenState: boolean = false;

  @Input() card: ShoppingCard;

  @Input() categories: ShoppingCategory[];

  @Input() typeOfPurchases: TypeOfPurchase[];

  @Output() getModels = new EventEmitter();  

  saveItemValue: Purchase;

  constructor(private service: PurchaseService) { }  

  ngOnInit() {
    this.saveItemValue = this.getCopy(this.card.purchase);
  }

  edit() {
    this.saveItemValue = this.getCopy(this.card.purchase);
  }

  save() {

    this.saveItemValue = null;

    this.service.put(this.card.purchase).subscribe((data) => { });
  }

  cancel() {

    this.card.purchase = this.getCopy(this.saveItemValue);

    this.saveItemValue = null;
  }

  delete() {

    this.service.delete(this.card.purchase).subscribe((data) => {
      this.getModels.emit();
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

  getTotalPrice() {

    this.card.purchase.totalPrice = this.card.purchase.priceOfOneUnit * this.card.purchase.amount;
  }
}
