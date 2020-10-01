import { OrderDetails } from "./orderdetails.model";
import { Store } from "./store.model";
import { OrderType } from "./ordertype.model";

export class Order{
    ID : number;
    OrderNumber : number;
    TypeId : number;
    TotalAmount : number;
    OrderDate : Date;
    CreationDate : Date;
    StoreId : number;
    SupplierId : number;
    CustomerId : number;
    DeliveredToStore : number;
    GettedFromStore : number;
    EmployeeId : number;
    Comments : string;
    Attachment : File;
    ItemList : OrderDetails[];
    Store : Store;
    Type : OrderType;

}