import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ShoppingCategory } from '../models/shoppingCategory';
import { ShoppingCategoryService } from '../services/shopping-category.service';

@Component({
  selector: 'app-shopping-category-item',
  templateUrl: './shopping-category-item.component.html',
  styleUrls: ['./shopping-category-item.component.scss']
})
export class ShoppingCategoryItemComponent implements OnInit {

  @Input() category: ShoppingCategory;

  @Output() loadItems = new EventEmitter();

  isEditItem: boolean = false;

  saveItemValue: ShoppingCategory;

  constructor(private service: ShoppingCategoryService) { }

  ngOnInit() {
  }

  switchingIsEditItem(){
    this.isEditItem = !this.isEditItem;
  }

  edit(){
    this.switchingIsEditItem();
    this.saveItemValue = this.getCopy(this.category);
  }

  save(){
    this.saveItemValue = null;
    this.switchingIsEditItem();
    this.service.put(this.category).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  cancel(){
    this.category = this.getCopy(this.saveItemValue);
    this.saveItemValue = null;
    this.switchingIsEditItem();
  }

  delete(){
    this.service.delete(this.category).subscribe((data) => {
      this.loadItems.emit();
    });
  }

  getCopy(item: ShoppingCategory): ShoppingCategory {

      let copy = new ShoppingCategory();

      copy.id = item.id;
      copy.name = item.name;
      copy.color = item.color;
      copy.imagePath = copy.imagePath;
      copy.isOn = copy.isOn;

      return copy;
  }

}