export class Purchase {

    public id: number;

    public name: string;

    public description: string;

    public typeOfPurchaseId: number;

    public amount: number;

    public priceOfOneUnit: number;

    public totalPrice: number;

    public isDone: boolean;

    public shoppingCategoryId: number;

    constructor() {

        this.id = 0;

        this.name='';

        this.description = '';

        this.typeOfPurchaseId = 0;

        this.amount = 1;

        this.priceOfOneUnit = 1;

        this.totalPrice = this.amount*this.priceOfOneUnit;

        this.isDone = false;

        this.typeOfPurchaseId = 0;

        this.shoppingCategoryId = 0;
    }

    public getTotalPrice(): number{

        this.totalPrice = this.priceOfOneUnit * this.amount;

        return this.totalPrice;
    }
}