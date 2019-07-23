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

  @Output() getTypeOfPurshases = new EventEmitter();

  saveItemValue: TypeOfPurchase;

  constructor(private service: TypeOfPurchaseService) { }  

  ngOnInit() {
  }

  edit() {
    this.saveItemValue = this.getCopy(this.type);
  }

  save() {

    this.saveItemValue = null;

    this.service.put(this.type).subscribe((data) => {
      this.getTypeOfPurshases.emit();
    });
  }

  cancel() {

    this.type = this.getCopy(this.saveItemValue);

    this.saveItemValue = null;
  }

  delete() {

    this.service.delete(this.type).subscribe((data) => {
      this.getTypeOfPurshases.emit();
    });
  }

  getCopy(item: TypeOfPurchase): TypeOfPurchase {

      let copy = new TypeOfPurchase();

      copy.id = item.id;
      copy.name = item.name;

      return copy;
  }
}
