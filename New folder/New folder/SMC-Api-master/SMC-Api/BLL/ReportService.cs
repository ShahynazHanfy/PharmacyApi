using AutoMapper;
using SMC_Api.DAL.UnitOfWork;
using SMC_Api.Models;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMC_Api.BLL
{
    public class ReportService
    {
        UnitOfWork unitofwork = new UnitOfWork(new SMC_DBEntities());
        //public IEnumerable<OrderDTO> TransactionReport(TransactionReportDTO reportDetails)
        //{  
        //    var entities = unitofwork.Order.GetAll().Where(x => x.StoreId == reportDetails.StoreId &&
        //    x.OrderDate >= reportDetails.fromOrder && x.OrderDate <= reportDetails.toOrder);
            
        //    List<Order> result= new List<Order>();
        //    foreach(var t in reportDetails.TransactionTypes)
        //    {
        //        var transactions = entities.Where(x => x.TransactionType.ID == t.ID);
        //        result.AddRange(transactions);
        //    }
        //    return Mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(result);
        //}
    }
}