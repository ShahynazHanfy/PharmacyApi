using AutoMapper;
using SMC_Api.DAL.UnitOfWork;
using SMC_Api.Models;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMC_Api.BLL
{
    public class ItemService
    {
        UnitOfWork unitofwork = new UnitOfWork(new SMC_DBEntities());
        BalanceService balanceService = new BalanceService();
        public IEnumerable<ItemDTO> GetAllItems()
        {
            var entities = unitofwork.Item.GetAll().Where(x => x.IsDeleted != true && x.IsActive == true);
            return Mapper.Map<IEnumerable<Item>, IEnumerable<ItemDTO>>(entities);
        }
        //public IEnumerable<Item> GetTopTenBestSelling()
        //{
        //    var entities = unitofwork.OrderDetail.GetAll().Where(x => x.Transaction.TypeId==2);
        //    return entities.Select(z =>.GroupBy(x => x.ItemId);
            
        //}


        public bool AddItem(ItemDTO model)
        {
            var entity = Mapper.Map<ItemDTO, Item>(model);
            unitofwork.Item.Add(entity);
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

        public ItemDTO GetItem(int id)
        {
            var model = unitofwork.Item.GetAll().Where(x => x.ID == id && x.IsDeleted != true && x.IsActive == true).FirstOrDefault();
            return Mapper.Map<Item, ItemDTO>(model);
        }

        public bool UpdateItem(ItemDTO obj)
        {
            Item model = new Item();
            model = Mapper.Map<ItemDTO, Item>(obj);
            unitofwork.Item.Update(model);
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

        public bool DeleteItem(int id)
        {
            Item entity = new Item();
            entity = unitofwork.Item.Get(id);
            entity.IsDeleted = true;
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

        public IEnumerable<OrderDetailsDTO> GetExpiredItems(int NOD)
        {
            var entities = unitofwork.OrderDetail.GetAll().Where(x => x.ExpiryDate.Date >= DateTime.Now &&
            x.ExpiryDate <= DateTime.Now.AddDays(NOD));
            return Mapper.Map<IEnumerable<OrderDetail>, IEnumerable<OrderDetailsDTO>>(entities);

        }

        public IEnumerable<ItemBalanceDTO> GetItemsNeedToReorderedForStore(int StoreId)
        {
            var lastBalance = balanceService.GetLastBalance(StoreId);
            List<ItemBalanceDTO> itemList = new List<ItemBalanceDTO>();
            foreach (var i in lastBalance.itemList)
            {
                ItemBalanceDTO item = new ItemBalanceDTO();
                int balance = balanceService.CalculateItemBalanceForStore(i.ItemId, StoreId, lastBalance.BalanceDate);
                item.ItemId = i.ItemId;
                item.Item = i.Item;
                item.Quantity = i.Quantity + balance;
                if (item.Quantity <= this.GetItem(i.ItemId).ReorderLevel)
                {
                    itemList.Add(item);
                }
            }
            return itemList;
        }
        //public IEnumerable<ItemBalanceDTO> GetItemsNeedToReorderedAllStores()
        //{
        //    List<ItemBalanceDTO> itemList = new List<ItemBalanceDTO>();

        //    foreach (var s in unitofwork.Store.GetAll())
        //    {
        //        var lastBalance = balanceService.GetLastBalance(s.ID);
        //        foreach (var i in lastBalance.itemList)
        //        {
        //            ItemBalanceDTO item = new ItemBalanceDTO();
        //            int balance = balanceService.CalculateItemBalanceForStore(i.ItemId, s.ID, lastBalance.BalanceDate);
        //            item.ItemId = i.ItemId;
        //            item.Item = i.Item;
        //            item.Quantity = i.Quantity + balance;
        //            if (item.Quantity <= this.GetItem(i.ItemId).ReorderLevel)
        //            {
        //                itemList.Add(item);
        //            }
        //        }
        //    }
            
        //    return itemList;

        //}
    }
}