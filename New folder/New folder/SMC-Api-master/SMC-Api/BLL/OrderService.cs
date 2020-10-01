using AutoMapper;
using SMC_Api.DAL.UnitOfWork;
using SMC_Api.Models;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMC_Api.BLL
{
    public class OrderService
    {
        UnitOfWork unitofwork = new UnitOfWork(new SMC_DBEntities());

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var entities = unitofwork.Employee.GetAll();
            return Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(entities);
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            var entities = unitofwork.Order.GetAll();
            return Mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(entities);
        }

        public IEnumerable<OrderDTO> GetStoreOrders(int storeId)
        {
            var entities = unitofwork.Order.GetAll().Where(x => x.StoreId == storeId);
            return Mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(entities);
        }

        public bool AddOrder(OrderDTO obj)
        {
            obj.CreationDate = DateTime.Now;
            obj.TotalAmount = obj.ItemList.Sum(x => x.Quantity * x.UnitPrice);
            foreach(var i in obj.ItemList)
            {
                i.Item = null;
            }
            var entity = Mapper.Map<OrderDTO, Order>(obj);
            unitofwork.Order.Add(entity);
            
            try
            {
                unitofwork.SaveChanges();
                return true;
            }

            catch
            {
                return false;
            }
           
        }

        public OrderDTO GetOrder(int id)
        {
            var entity = unitofwork.Order.GetAll().Where(x => x.ID == id).FirstOrDefault();
            return Mapper.Map<Order, OrderDTO>(entity);
        }

        public bool UpdateOrder(OrderDTO obj)
        {
            Order entity = new Order();
            entity = Mapper.Map<OrderDTO, Order>(obj);
            unitofwork.Order.Update(entity);
            try
            {
                unitofwork.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }

        }

        public IEnumerable<OrderDetail> GetOrdersAfterLastBalanceForitemInStore(int itemId, int StoreId, DateTime lastBalanceDate)
        {
           
            var orders = unitofwork.OrderDetail.GetAll().
                Where(x => x.ItemId == itemId && x.Order.StoreId == StoreId
                && x.Order.OrderDate > lastBalanceDate).ToList();
            return orders;
        }

        public IEnumerable<OrderDTO> GetOrderByTypes(TransactionReportDTO details)
        {

            var result = unitofwork.Order.GetAll().Where(x => x.OrderDate >= details.FromOrder &&
            x.OrderDate <= details.ToOrder && details.Types.Contains(x.TypeId));
            result = result.OrderBy(y => y.TypeId);
            return Mapper.Map<IEnumerable<Order>,IEnumerable<OrderDTO>>(result);
        }


        //public bool DeleteTransaction(int id)
        //{
        //    Transaction entity = new Transaction();
        //    entity = unitofwork.Transaction.Get(id);
        //    if(entity.Transactions.Count() == 0)
        //    {
        //        entity.IsDeleted = true;
        //        try
        //        {
        //            unitofwork.SaveChanges();
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }


        //}
    }
}