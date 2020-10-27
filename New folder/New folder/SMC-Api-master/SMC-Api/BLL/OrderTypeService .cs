using AutoMapper;
using SMC_Api.DAL.UnitOfWork;
using SMC_Api.Models;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMC_Api.BLL
{
    public class OrderTypeService
    {
        UnitOfWork unitofwork = new UnitOfWork(new SMC_DBEntities());
        public IEnumerable<OrderTypeDTO> GetAllTypes()
        {
            var entities = unitofwork.OrderType.GetAll().Where(x =>x.IsDeleted !=true);
            return Mapper.Map<IEnumerable<OrderType>, IEnumerable<OrderTypeDTO>>(entities);
        }

        public IEnumerable<OrderTypeDTO> GetActiveTypes()
        {
            var entities = unitofwork.OrderType.GetAll().Where(x => x.IsActive == true && x.IsDeleted != true);
            return Mapper.Map<IEnumerable<OrderType>, IEnumerable<OrderTypeDTO>>(entities);
        }

        public bool AddType(OrderTypeDTO obj)
        {
            var entity = Mapper.Map<OrderTypeDTO, OrderType>(obj);
            unitofwork.OrderType.Add(entity);
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

        public OrderTypeDTO GetType(int id)
        {
            var entity = unitofwork.OrderType.GetAll().Where(x => x.ID == id).FirstOrDefault();
            return Mapper.Map<OrderType, OrderTypeDTO>(entity);
        }

        public bool UpdateType(OrderTypeDTO obj)
        {
            OrderType entity = new OrderType();
            entity = Mapper.Map<OrderTypeDTO, OrderType>(obj);
            unitofwork.OrderType.Update(entity);
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

        public bool DeleteType(int id)
        {
            OrderType entity = new OrderType();
            entity = unitofwork.OrderType.Get(id);
            if(entity.Orders.Count() == 0)
            {
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
            else
            {
                return false;
            }
           

        }
    }
}