import { Group } from "./group.model";
import { Subgroup } from "./subgroup.model";

export class Item {
     ID : number;
     Name : string;
     NameAr : string;
     Description : string;
     DescriptionAr : string;
     BrandId : number
     SubgroupId  : number;
     Quantity : number;
     image : string;
     Size : string;
     UOM : string;
     ReorderLevel : number;
     BarCode : string
     ExpiryDateReminder : number;
     Type : string;
     IsActive : boolean;
     Subgroup:Subgroup;
}