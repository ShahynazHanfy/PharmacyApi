using AutoMapper;
using SMC_Api.DAL.UnitOfWork;
using SMC_Api.Models;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMC_Api.BLL
{
    public class SupplierService
    {
        UnitOfWork unitofwork = new UnitOfWork(new SMC_DBEntities());
        public IEnumerable<SupplierDTO> GetAllSuppliers()
        {
            var entities = unitofwork.Supplier.GetAll().Where(x => x.IsDeleted != true && x.IsActive == true);

            return Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(entities);
        }

        //public IEnumerable<SupplierDTO> GetTop10Suppliers()
        //{
        //    var entities = unitofwork.Supplier.ExecWithStoreProcedure("GetTopTenSuppliers");
            
        //    return Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(entities);
        //}

        public bool AddSupplier(SupplierDTO model)
        {
            var entity = Mapper.Map<SupplierDTO, Supplier>(model);
            unitofwork.Supplier.Add(entity);
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

        public SupplierDTO GetSupplier(int id)
        {
            var entity = unitofwork.Supplier.GetAll().Where(x => x.ID == id && x.IsDeleted != true).FirstOrDefault();

            return Mapper.Map<Supplier, SupplierDTO>(entity);
        }

        public bool UpdateSupplier(SupplierDTO obj)
        {
            Supplier entity = new Supplier();
            entity = Mapper.Map<SupplierDTO, Supplier>(obj);
            unitofwork.Supplier.Update(entity);
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

        public bool DeleteSupplier(int id)
        {
            Supplier entity = new Supplier();
            entity = unitofwork.Supplier.Get(id);
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
    }
}