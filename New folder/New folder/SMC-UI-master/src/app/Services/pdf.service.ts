import { Injectable } from '@angular/core';
import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';
import { Item } from '../Models/item.model';
import { Store } from '../Models/store.model';
import { Order } from '../Models/order.model';
import { OrderDetails } from '../Models/orderdetails.model';
import { DatePipe } from '@angular/common';
import { ItemBalance } from '../Models/itembalance.model';
pdfMake.vfs = pdfFonts.pdfMake.vfs;

@Injectable()
export class PDFService {

  constructor() { }

//   generatePdf() : void{
//     const documentDefinition = { content: 'This is an sample PDF printed with pdfMake' };
//     pdfMake.createPdf(documentDefinition).download();
//    }

//    resume = new Resume();
  
generatePdf(action = 'download' , title , rows , tableType) {
  const documentDefinition = this.getGeneralDocumentDefinition(title,rows,tableType);
  switch (action) {
    case 'open': pdfMake.createPdf(documentDefinition).open(); break;
    case 'print': pdfMake.createPdf(documentDefinition).print(); break;
    case 'download': pdfMake.createPdf(documentDefinition).download(); break;
    default: pdfMake.createPdf(documentDefinition).open(); break;
  }
}
generatePdfWithMultiTables(action = 'download' , title , tables , tableType) {
  // console.log(tables);
  const documentDefinition = this.getGeneralDocumentDefinitionForMultiple(title,tables,tableType);
  console.log(documentDefinition);
  switch (action) {
    case 'open': pdfMake.createPdf(documentDefinition).open(); break;
    case 'print': pdfMake.createPdf(documentDefinition).print(); break;
    case 'download': pdfMake.createPdf(documentDefinition).download(); break;
    default: pdfMake.createPdf(documentDefinition).open(); break;
  }
}
getGeneralDocumentDefinitionForMultiple(title , tables, type) {
  console.log(tables);
   var dd =  {content: [
    // {
    //   text: title,
    //   bold: true,
    //   fontSize: 20,
    //   alignment: 'center',
    //   margin: [0, 0, 0, 20]
    // }
  ]};
  var test = { text:"Test Content Append ",bold:true,color:'red'};
  dd.content.push(test);
 
  return dd;
  }
  
   getGeneralDocumentDefinition(title , rows , type) {
  return {
    content: [
      {columns: [
				{text: "Date: "+ new Date().toLocaleDateString()},
        {text: title,bold: true,fontSize: 11,underlined:true,margin:[0,60,0,0]},
        {text: 'AlMostakbal Technology', margin:[30,0,0,20]}]},
     type == 'item' ?  this.GenerateItemsTable(rows) : 
     type == 'store' ? this.GenerateStoresTable(rows) : 
     type == 'expireditems' ? this.GenerateExpiredItemsTable(rows) : 
     type == 'reorderitems' ? this.GenerateReorderItemsTable(rows) : 
     this.GenerateTransactionsTable(rows),
    ],
      styles: {
        
        tableHeader: {
          bold: true,
        }
      }
  };
  }
 
  GenerateItemsTable(items: Item[]) {
    return {
      table: {
        widths: ['auto', 'auto', 'auto', 'auto','auto','auto'],
        body: [
          [{text: 'Name',style: 'tableHeader'},
          {text: 'Description',style: 'tableHeader'},
          {text: 'Group',style: 'tableHeader'},
          {text: 'SubGroup',style: 'tableHeader'},
          {text: 'UOM',style: 'tableHeader'},
          {text: 'Reorder Level',style: 'tableHeader'}],
          ...items.map(i => {
            return [i.Name, i.Description,i.Subgroup.Group.Name,i.Subgroup.Name, i.UOM, i.ReorderLevel];
          })
        ]
      }
    };
  }
  GenerateStoresTable(rows: Store[]) {
    return {
      table: {
        widths: [125, 125, 125, 125],
        body: [
          [{text: 'Name',style: 'tableHeader'},
          {text: 'Address',style: 'tableHeader'},
          {text: 'Area',style: 'tableHeader'},
          {text: 'Telephone',style: 'tableHeader'}
          ],
          ...rows.map(i => {
            return [i.Name, i.Address,i.Area,i.Telephone];
          })
        ]
      }
    };
  }
  GenerateExpiredItemsTable(rows: OrderDetails[]) {
    return {
      table: {
        widths: ['auto', 'auto', 'auto', 'auto','auto','auto'],
        body: [
          [{text: 'Item Name',style: 'tableHeader'},
          {text: 'Bar Code',style: 'tableHeader'},
          {text: 'production Date',style: 'tableHeader',},
          {text: 'Expiry Date',style: 'tableHeader'},
          {text: 'Quantity',style: 'tableHeader'},
          {text: 'Unit Price',style: 'tableHeader'}            
          ],
          ...rows.map(i => {
            return [i.Item.Name, i.Item.BarCode,new Date(i.ProductionDate).toLocaleDateString(),new Date(i.ExpiryDate).toLocaleDateString(), i.Quantity,i.UnitPrice];
          })]
      }
    };
  }
  GenerateTransactionsTable(rows: Order[]) {
    return {
      table: {
        widths: ['auto', 'auto','auto', 'auto', 'auto'],
        body: [
          [{text: 'Number',style: 'tableHeader'},
          {text: 'Date',style: 'tableHeader'},
          {text: 'Items',style: 'tableHeader'},
          {text: 'Store',style: 'tableHeader'},
          {text: 'Type', style: 'tableHeader'}
          ],
          ...rows.map(i => {
            return [i.OrderNumber,new Date(i.OrderDate).toLocaleDateString(),this.GenerateOrderItemsTable(i.ItemList),i.Store.Name,i.Type.Name];
          })
        ]
      }
    };
  }
  GenerateReorderItemsTable(rows: ItemBalance[]) {
    return {
        table: {
        widths: ['auto', 'auto', 'auto', 'auto','auto','auto'],
        body: [
          [{text: 'Item Name',style: 'tableHeader'},
          {text: 'Bar Code',style: 'tableHeader'},
          {text: 'Quantity',style: 'tableHeader'},
          {text: 'Reorder Level',style: 'tableHeader'},
          {text: 'SubGroup',style: 'tableHeader'},
          {text: 'Group',style: 'tableHeader'}
          ],
          ...rows.map(i => {
            return [i.Item.Name, i.Item.BarCode,i.Quantity,i.Item.ReorderLevel,
              i.Item.Subgroup.Name,i.Item.Subgroup.Group.Name];
          })]
      }
    };
  }
 GenerateOrderItemsTable(rows:OrderDetails[])
 {
   return {
  table: {
    widths: ['auto', 'auto'],
    body: [
      [{text: 'Name',style: 'tableHeader'},
      {text: 'Quantity',style: 'tableHeader'},           
      ],
      ...rows.map(i => {
        return [i.Item.Name, i.Quantity];
      })]
  }
};
 }
//   getProfilePicObject() {
//     if (this.resume.profilePic) {
//       return {
//         image: this.resume.profilePic ,
//         width: 75,
//         alignment : 'right'
//       };
//     }
//     return null;
//   }
//   fileChanged(e) {
//     const file = e.target.files[0];
//     this.getBase64(file);
//   }
//   getBase64(file) {
//     const reader = new FileReader();
//     reader.readAsDataURL(file);
//     reader.onload = () => {
//       console.log(reader.result);
//       this.resume.profilePic = reader.result as string;
//     };
//     reader.onerror = (error) => {
//       console.log('Error: ', error);
//     };
//   }
//   addSkill() {
//     this.resume.skills.push(new Skill());
//   }

}
