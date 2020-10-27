using AutoMapper;
using SMC_Api.DAL.UnitOfWork;
using SMC_Api.Models;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMC_Api.BLL
{
    public class BalanceService
    {
        UnitOfWork unitofwork = new UnitOfWork(new SMC_DBEntities());
        OrderService orderService = new OrderService();
        public IEnumerable<BalanceDTO> GetAllBalances()
        {
            var entities = unitofwork.Balance.GetAll();
            return Mapper.Map<IEnumerable<Balance>, IEnumerable<BalanceDTO>>(entities);
        }
        public IEnumerable<BalanceDTO> GetStoreBalances(int storeId)
        {
            var entities = unitofwork.Balance.GetAll().Where(x => x.StoreId == storeId);
            return Mapper.Map<IEnumerable<Balance>, IEnumerable<BalanceDTO>>(entities);
        }

        public BalanceDTO AddBalance(BalanceDTO obj)
        {
            
            obj.CreationDate = DateTime.Now;
            var LastBalance = unitofwork.Balance.GetAll().Where(x => x.StoreId == obj.StoreId).OrderBy(y=> y.CreationDate).Last();
            List<ItemBalanceDTO> itemList = new List<ItemBalanceDTO>();
            foreach(var i in LastBalance.ItemBalances)
            {
                ItemBalanceDTO item = new ItemBalanceDTO();
                int balance = this.CalculateItemBalanceForStore(i.ItemId, obj.StoreId, LastBalance.BalanceDate);
                item.ItemId = i.ItemId;
                item.Quantity = i.Quantity + balance;
                itemList.Add(item);
            }
            obj.itemList = itemList.ToArray();
            var entity = Mapper.Map<BalanceDTO, Balance>(obj);
            unitofwork.Balance.Add(entity);

            try
            {
                unitofwork.SaveChanges();

                return Mapper.Map<Balance,BalanceDTO>(entity);
            }

            catch
            {
                return Mapper.Map<Balance, BalanceDTO>(entity);
            }

        }

        public BalanceDTO GetBalance(int id)
        {
            var entity = unitofwork.Balance.GetAll().Where(x => x.ID == id).FirstOrDefault();
            return Mapper.Map<Balance, BalanceDTO>(entity);
        }

        public bool UpdateBalance(BalanceDTO obj)
        {
            Balance entity = new Balance();
            entity = Mapper.Map<BalanceDTO, Balance>(obj);
            unitofwork.Balance.Update(entity);
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
       
        public BalanceDTO GetLastBalance(int storeId)
        {
            var entity = unitofwork.Balance.GetAll().Where(x => x.StoreId == storeId).LastOrDefault();
            return Mapper.Map<Balance, BalanceDTO>(entity);
        }

        public BalanceDTO GetGenericLastBalance()
        {
            var entity = unitofwork.Balance.GetAll().LastOrDefault();
            return Mapper.Map<Balance, BalanceDTO>(entity);
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

        public int CalculateItemBalanceForStore(int itemId , int StoreId , DateTime lastBalanceDate)
        {
           int plus = 0, minus = 0;
           var orders = this.orderService.GetOrdersAfterLastBalanceForitemInStore(itemId, StoreId, lastBalanceDate);

            foreach(var o in orders)
            {
                if(o.Order.OrderType.ProcessType == true)
                {
                    plus = plus + o.Quantity;
                }
                else
                {
                    minus = minus + o.Quantity;
                }
            }
            int sum = plus - minus;
            return sum;
        }
       
    }
}