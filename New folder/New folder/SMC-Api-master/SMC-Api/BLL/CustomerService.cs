using AutoMapper;
using SMC_Api.DAL.UnitOfWork;
using SMC_Api.Models;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMC_Api.BLL
{
    public class CustomerService
    {
        UnitOfWork unitofwork = new UnitOfWork(new SMC_DBEntities());
        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            var entities = unitofwork.Customer.GetAll().Where(x => x.IsDeleted != true && x.IsActive == true);

            return Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(entities);
        }

        //public IEnumerable<SupplierDTO> GetTop10Suppliers()
        //{
        //    var entities = unitofwork.Supplier.ExecWithStoreProcedure("GetTopTenSuppliers");
            
        //    return Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(entities);
        //}

        public bool AddCustomer(CustomerDTO model)
        {
            var entity = Mapper.Map<CustomerDTO, Customer>(model);
            unitofwork.Customer.Add(entity);
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

        public CustomerDTO GetCustomer(int id)
        {
            var entity = unitofwork.Customer.GetAll().Where(x => x.ID == id && x.IsDeleted != true).FirstOrDefault();

            return Mapper.Map<Customer, CustomerDTO>(entity);
        }

        public bool UpdateCustomer(CustomerDTO obj)
        {
            Customer entity = new Customer();
            entity = Mapper.Map<CustomerDTO, Customer>(obj);
            unitofwork.Customer.Update(entity);
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

        public bool DeleteCustomer(int id)
        {
            Customer entity = new Customer();
            entity = unitofwork.Customer.Get(id);
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