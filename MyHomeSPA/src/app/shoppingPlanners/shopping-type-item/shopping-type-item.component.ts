import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TypeOfPurchase } from '../models/typeOfPurchase';
import { TypeOfPurchaseService } from '../services/type-of-purchase.service';

@Component({
  selector: 'app-shopping-type-item',
  templateUrl: './shopping-type-item.component.html',
  styleUrls: ['./shopping-type-item.component.scss']
})
export class ShoppingTypeItemComponent implements OnInit {

  @Input() type: TypeOfPurchase;

  @Output() loadItems = new EventEmitter();

  saveItemValue: TypeOfPurchase;

  isEditItem: boolean = false;

  constructor(private service: TypeOfPurchaseService) { }

  switchingIsEditItem(){
    this.isEditItem = !this.isEditItem;
  }

  ngOnInit() {
  }

  edit(){
    this.switchingIsEditItem();
    this.saveItemValue = this.getCopy(this.type);
  }

  save(){
    this.saveItemValue = null;
    this.switchingIsEditItem();
    this.service.put(this.type).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  cancel(){
    this.type = this.getCopy(this.saveItemValue);
    this.saveItemValue = null;
    this.switchingIsEditItem();
  }

  delete(){
    this.service.delete(this.type).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  getCopy(item: TypeOfPurchase): TypeOfPurchase {

      let copy = new TypeOfPurchase();

      copy.id = item.id;
      copy.name = item.name;

      return copy;
  }
}
