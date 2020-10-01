using SMC_Api.DAL.Repositories;
using SMC_Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace SMC_Api.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SMC_DBEntities _context;

        //constructor to assign the context and pass this context to all the repositories
        public UnitOfWork(SMC_DBEntities context)
        {
            _context = context;
            User = new UserRepository(_context);
            Role = new RoleRepository(_context);
            Store = new StoreRepository(_context);
            Group = new GroupRepository(_context);
            Subgroup = new SubgroupRepository(_context);
            Item = new ItemRepository(_context);
            OrderType = new OrderTypeRepository(_context);
            Order = new OrderRepository(_context);
            OrderDetail = new OrderDetailRepository(_context);
            Balance = new BalanceRepository(_context);
            Supplier = new SupplierRepository(_context);
            Customer = new CustomerRepository(_context);
            Employee = new EmployeeRepository(_context);
        }
        public UserRepository User { get; set; }
        public RoleRepository Role { get; set; }
        public StoreRepository Store { get; set; }
        public GroupRepository Group { get; set; }
        public SubgroupRepository Subgroup { get; set; }
        public ItemRepository Item { get; set; }
        public OrderTypeRepository OrderType { get; set; }
        public OrderRepository Order { get; set; }
        public OrderDetailRepository OrderDetail { get; set; }
        public BalanceRepository Balance { get; set; }
        public SupplierRepository Supplier { get; set; }
        public CustomerRepository Customer { get; set; }
        public EmployeeRepository Employee { get; set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        //public IEnumerable ExecuteReader(string spName , SqlParameter[] parameters=null)
        //{
        //    if (parameters != null && parameters.Any())
        //    {
        //        var parameterBuilder = new StringBuilder();
        //        parameterBuilder.Append(string.Format("Exec {0} ", spName));
        //        for (int i = 0; i < parameters.Length; i++)
        //        {
        //            if (parameters[i].SqlDbType == SqlDbType.VarChar
        //                || parameters[i].SqlDbType == SqlDbType.NVarChar
        //                || parameters[i].SqlDbType == SqlDbType.Char
        //                || parameters[i].SqlDbType == SqlDbType.NChar
        //                || parameters[i].SqlDbType == SqlDbType.Text
        //                || parameters[i].SqlDbType == SqlDbType.NText)
        //            {
        //                parameterBuilder.Append(string.Format("{0}='{1}'", parameters[i].ParameterName, string.IsNullOrEmpty(
        //                    parameters[i].Value.ToString()) ? string.Empty : parameters[i].Value.ToString()));
        //            }
        //            else if (parameters[i].SqlDbType == SqlDbType.BigInt
        //                || parameters[i].SqlDbType == SqlDbType.Int
        //                || parameters[i].SqlDbType == SqlDbType.TinyInt
        //                || parameters[i].SqlDbType == SqlDbType.Decimal
        //                || parameters[i].SqlDbType == SqlDbType.Float
        //                || parameters[i].SqlDbType == SqlDbType.Money
        //                || parameters[i].SqlDbType == SqlDbType.SmallInt
        //                || parameters[i].SqlDbType == SqlDbType.SmallMoney)
        //            {
        //                parameterBuilder.Append(string.Format("{0}='{1}'", parameters[i].ParameterName, parameters[i].Value));
        //            }

        //            else if (parameters[i].SqlDbType == SqlDbType.Bit)
        //            {
        //                parameterBuilder.Append(string.Format("{0}='{1}'", parameters[i].ParameterName,
        //                    Convert.ToBoolean(parameters[i].Value)));

        //            }
        //            if(i < parameters.Length -1)
        //            {
        //                parameterBuilder.Append(",");
        //            }
        //        }
        //        var query = parameterBuilder.ToString();
        //        var result = _context.Database.SqlQuery(query);
        //        return result
        //    }
           
        //}
    }
}