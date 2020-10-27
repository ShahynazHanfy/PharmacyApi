using CrystalDecisions.CrystalReports.Engine;
using SMC_Api.BLL;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace SMC_Api.Controllers
{
    public class ReportController : ApiController
    {
        ReportService Service = new ReportService();

        ReportDocument report = new ReportDocument();

        //[HttpPost]
        //[Route("api/DownloadTransactionsByType")]
        //public HttpResponseMessage DownloadFile(TransactionReportDTO reportDetails)
        //{
        //    var filePath = HttpContext.Current.Server.MapPath($"~/ReportGenerator/NewFolder1/TransactionReport.rpt");
        //    report.Load(filePath);
        //    var result = Request.CreateResponse(HttpStatusCode.OK);
        //    var ds = Service.TransactionReport(reportDetails);
        //    report.SetDataSource(ds);
        //    var fileName = "Transactions" ;
        //    var fileBytes = File.ReadAllBytes(filePath);
        //    var fileMemStream = new MemoryStream(fileBytes);
        //    result.Content = new StreamContent(fileMemStream);
        //    var headers = result.Content.Headers;
        //    headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
        //    headers.ContentDisposition.FileName = fileName;
        //    headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        //    headers.ContentLength = fileMemStream.Length;
        //    return result;
        //}
        [HttpPost]
        [Route("api/DownloadTransactionsByType")]
        public HttpResponseMessage DownloadFile(TransactionReportDTO reportDetails)
        {
            var filePath = HttpContext.Current.Server.MapPath($"~/ReportGenerator/TextFile1.txt");
            //report.Load(filePath);
            var result = Request.CreateResponse(HttpStatusCode.OK);
            //var ds = Service.TransactionReport(reportDetails);
            //report.SetDataSource(ds);
            var fileName = "Test";
            var fileBytes = File.ReadAllBytes(filePath);
            var fileMemStream = new MemoryStream(fileBytes);
            result.Content = new StreamContent(fileMemStream);
            var headers = result.Content.Headers;
            headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            headers.ContentDisposition.FileName = fileName;
            headers.ContentType = new MediaTypeHeaderValue("application/text");
            headers.ContentLength = fileMemStream.Length;
            return result;
        }
        //[HttpPost]
        //[Route("api/DownloadTransactionsByType")]
        //public IHttpActionResult DownloadTransactionsByType(TransactionReportDTO reportDetails)
        //{
        //    //BalanceDTO entity = Service.GetLastBalance(1);
        //    //if (entity == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //return Ok(entity);
        //}
    }
}
