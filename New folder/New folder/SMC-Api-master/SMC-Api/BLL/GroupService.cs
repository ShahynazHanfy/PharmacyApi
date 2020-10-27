using AutoMapper;
using SMC_Api.DAL.UnitOfWork;
using SMC_Api.Models;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMC_Api.BLL
{
    public class GroupService
    {
        UnitOfWork unitofwork = new UnitOfWork(new SMC_DBEntities());
        public IEnumerable<GroupDTO> GetAllGroups()
        {
            var groups = unitofwork.Group.GetAll().Where(x => x.IsDeleted != true && x.IsActive == true);
            return Mapper.Map<IEnumerable<Group>, IEnumerable<GroupDTO>>(groups);
        }

        public bool AddGroup(GroupDTO model)
        {
            var group = Mapper.Map<GroupDTO, Group>(model);
            unitofwork.Group.Add(group);
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

        public GroupDTO GetGroup(int id)
        {
            var group = unitofwork.Group.GetAll().Where(x => x.ID == id && x.IsDeleted != true && x.IsActive == true).FirstOrDefault();
            return Mapper.Map<Group, GroupDTO>(group);
        }

        public bool UpdateGroup(GroupDTO obj)
        {
            Group group = new Group();
            group = Mapper.Map<GroupDTO, Group>(obj);
            unitofwork.Group.Update(group);
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

        public bool DeleteGroup(int id)
        {
            Group group = new Group();
            group = unitofwork.Group.Get(id);
            group.IsDeleted = true;
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