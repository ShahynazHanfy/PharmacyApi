using AutoMapper;
using SMC_Api.DAL.UnitOfWork;
using SMC_Api.Models;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMC_Api.BLL
{
    public class StoreService
    {
        UnitOfWork unitofwork = new UnitOfWork(new SMC_DBEntities());
        public IEnumerable<StoreDTO> GetAllStores()
        {
            var stores = unitofwork.Store.GetAll().Where(x => x.IsDeleted != true && x.IsActive == true);

            return Mapper.Map<IEnumerable<Store>, IEnumerable<StoreDTO>>(stores);
        }

        public bool AddStore(StoreDTO model)
        {
            var store = Mapper.Map<StoreDTO, Store>(model);
            unitofwork.Store.Add(store);
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

        public StoreDTO GetStore(int id)
        {
            var store = unitofwork.Store.GetAll().Where(x => x.ID == id && x.IsDeleted != true && x.IsActive == true).FirstOrDefault();

            return Mapper.Map<Store, StoreDTO>(store);
        }

        public bool UpdateStore(StoreDTO obj)
        {
            Store store = new Store();
            store = Mapper.Map<StoreDTO, Store>(obj);
            unitofwork.Store.Update(store);
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

        public bool DeleteStore(int id)
        {
            Store store = new Store();
            store = unitofwork.Store.Get(id);
            store.IsDeleted = true;
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
    }
}