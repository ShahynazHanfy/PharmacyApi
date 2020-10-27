using AutoMapper;
using SMC_Api.DAL.UnitOfWork;
using SMC_Api.Models;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMC_Api.BLL
{
    public class SubgroupService
    {
        UnitOfWork unitofwork = new UnitOfWork(new SMC_DBEntities());
        public IEnumerable<SubgroupDTO> GetAllSubgroups()
        {
            var entities = unitofwork.Subgroup.GetAll().Where(x => x.IsDeleted != true && x.IsActive == true);
            return Mapper.Map<IEnumerable<Subgroup>, IEnumerable<SubgroupDTO>>(entities);
        }

        public IEnumerable<SubgroupDTO> GetSubgroupsByGrpId(int groupId)
        {
            var entities = unitofwork.Subgroup.GetAll().Where(x => x.GroupId == groupId && x.IsDeleted != true && x.IsActive == true );
            return Mapper.Map<IEnumerable<Subgroup>, IEnumerable<SubgroupDTO>>(entities);
        }

        public bool AddSubgroup(SubgroupDTO model)
        {
            var entity = Mapper.Map<SubgroupDTO, Subgroup>(model);
            unitofwork.Subgroup.Add(entity);
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

        public SubgroupDTO GetSubgroup(int id)
        {
            var model = unitofwork.Subgroup.GetAll().Where(x => x.ID == id && x.IsDeleted != true && x.IsActive == true).FirstOrDefault();
            return Mapper.Map<Subgroup, SubgroupDTO>(model);
        }

        public bool UpdateSubgroup(SubgroupDTO obj)
        {
            Subgroup model = new Subgroup();
            model = Mapper.Map<SubgroupDTO, Subgroup>(obj);
            unitofwork.Subgroup.Update(model);
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

        public bool DeleteSubgroup(int id)
        {
            Subgroup entity = new Subgroup();
            entity = unitofwork.Subgroup.Get(id);
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