import { Purchase } from './purchase';
import { TypeOfPurchase } from './typeOfPurchase';
import { ShoppingCategory } from './shoppingCategory';

export class ShoppingCard {

    public purchase: Purchase;

    public typeOfPurchase: TypeOfPurchase;

    public shoppingCategory: ShoppingCategory;

    constructor() {

        this.purchase = new Purchase();

        this.typeOfPurchase = new TypeOfPurchase();

        this.shoppingCategory = new ShoppingCategory();
    }
}