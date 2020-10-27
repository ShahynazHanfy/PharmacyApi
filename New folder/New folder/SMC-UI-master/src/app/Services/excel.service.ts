import { Injectable } from '@angular/core';
// import { Workbook } from 'exceljs';
// import * as FileSaver from 'file-saver';
// import * as XLSX from 'xlsx';

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';

@Injectable()
export class ExcelService {

  constructor() { }

  // public exportAsExcelFile(json: any[], excelFileName: string): void {
    
  //   const myworksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(json);
  //   console.log("work sheet contain ",myworksheet)
  //   const myworkbook: XLSX.WorkBook = { Sheets: { 'data': myworksheet }, SheetNames: ['data'] };
  //   const excelBuffer: any = XLSX.write(myworkbook, { bookType: 'xlsx', type: 'array' });
  //   this.saveAsExcelFile(excelBuffer, excelFileName);
  // }

  // private saveAsExcelFile(buffer: any, fileName: string): void {
  //   const data: Blob = new Blob([buffer], {
  //     type: EXCEL_TYPE
  //   });
  //   FileSaver.saveAs(data, fileName + '_exported'+ EXCEL_EXTENSION);
  // }

  // public exportAsCustomExcelFile(json: any[], excelFileName: string): void {
  //   const fs = require('fs');
  //  //Excel Title, Header, Data
  //  const header = ['Transaction Number','Type','Transaction Date','Total Amount' ,'Store','Comments'];
  //  const data = json;
  //  //Create workbook and worksheet
  //  let workbook = new Workbook();
  //  let worksheet = workbook.addWorksheet(excelFileName);
  //  //Add Header Row
  //  let headerRow = worksheet.addRow(header);
  //  // Cell Style : Fill and Border
  //  headerRow.eachCell((cell, number) => {
  //    cell.fill = {
  //      type: 'pattern',
  //      pattern: 'solid',
  //      fgColor: { argb: 'FFFFFF00' },
  //      bgColor: { argb: 'FF0000FF' }
  //    }
  //    cell.border = { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } }
  //  })
  //  // Add Data and Conditional Formatting
  //  data.forEach((element) => {
  //    let eachRow = [];
  //    eachRow.push(element.TransactionNumber)
  //    eachRow.push(element.TransactionType.Name)
  //    eachRow.push(element.TransactionDate)
  //    eachRow.push(element.TotalAmount)
  //    eachRow.push(element.Store.Name)
  //    eachRow.push(element.TransactionNumber)
  //    worksheet.addRow(eachRow);   
  //  })
   
  //  worksheet.addRow([]);
   
  // //  Generate Excel File with given name
  //  workbook.xlsx.writeBuffer().then((data) => {
  //    let blob = new Blob([data], { type: EXCEL_TYPE });
  //    fs.saveAs(blob, excelFileName + '_export_' +  EXCEL_EXTENSION);
  //  })
 
  // }

}
