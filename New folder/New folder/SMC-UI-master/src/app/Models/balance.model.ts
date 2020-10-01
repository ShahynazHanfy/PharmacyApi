import { Store } from "./store.model";
import { ItemBalance } from "./itembalance.model";

export class Balance
{
    ID : number;
    CreationDate : Date;
    BalanceDate : Date;
    StoreId : number;
    Store : Store;
    itemList : ItemBalance[];
}