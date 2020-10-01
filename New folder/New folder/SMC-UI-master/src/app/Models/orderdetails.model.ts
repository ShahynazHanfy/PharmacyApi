import { Item } from "./item.model";
import { Order } from "./order.model";

export class OrderDetails
{
    ID : number;
    TransactionId : number;
    ItemId : number;
    Quantity : number;
    UnitPrice : number;
    ProductionDate : Date;
    ExpiryDate : Date;
    Item : Item;
}