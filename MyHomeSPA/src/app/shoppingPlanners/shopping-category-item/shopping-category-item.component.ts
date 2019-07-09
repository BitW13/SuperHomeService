import { Component, OnInit, Input } from '@angular/core';
import { ShoppingCategory } from '../models/shoppingCategory';

@Component({
  selector: 'app-shopping-category-item',
  templateUrl: './shopping-category-item.component.html',
  styleUrls: ['./shopping-category-item.component.scss']
})
export class ShoppingCategoryItemComponent implements OnInit {

  @Input() category: ShoppingCategory;

  isEditCategory: boolean = false;

  constructor() { }

  ngOnInit() {
  }

  editCategory(){
    this.isEditCategory = !this.isEditCategory;
  }

}
