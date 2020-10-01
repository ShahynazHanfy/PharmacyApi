using AutoMapper;
using SMC_Api.DAL.UnitOfWork;
using SMC_Api.Models;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMC_Api.BLL
{
    public class UserService
    {
        UnitOfWork unitofwork = new UnitOfWork(new SMC_DBEntities());
        public IEnumerable<RegisterBindingModel> GetUsers(int storeId)
        {
            List<User> users = new List<User>();
            //var currentUser =  this.GetUser(UserId);
            if (storeId == 0)
            {
                 users = unitofwork.User.GetAll().Where(x => x.IsDeleted != true).ToList();
            }
          else
            {
               users = unitofwork.User.GetAll().Where(x => x.IsDeleted != true && x.StoreId == storeId).ToList();
            }

            return Mapper.Map<IEnumerable<User>, IEnumerable<RegisterBindingModel>>(users);
        }

        public IEnumerable<RoleDTO> GetRoles()
        {
            var roles = unitofwork.Role.GetAll();

            return Mapper.Map<IEnumerable<Role>, IEnumerable<RoleDTO>>(roles);
        }


        public RegisterBindingModel GetUser(string id)
        {
            var entity = unitofwork.User.GetAll().Where(x => x.Id == id).FirstOrDefault();
            var user = Mapper.Map<User, RegisterBindingModel>(entity);
            List<string> roles= new List<string>();
            foreach(var r in entity.Roles)
            {
                roles.Add(r.Name);
            }
            user.Roles = roles.ToArray();
            return user;
        }
        
    }
}