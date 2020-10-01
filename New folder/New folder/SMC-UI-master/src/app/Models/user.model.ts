export class User {
    Id: string;
   // token: string;
    FirstName : string;
    LastName : string;
    Email: string;
    PhoneNumber : string;
    StoreId : number = 1;
    IsActive : boolean;
    IsDeleted : boolean;
    // UserName: string;
    Password: string;
    ConfirmPassword:string;
    Roles : string[] =[]; 
}