using SMC_Api.Models;
using SMC_Api.ModelsDTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMC_Api.Mappings
{
    public class AutoMapperWebProfile : Profile
    {

        public AutoMapperWebProfile()
        {
            CreateMap<User, RegisterBindingModel>()
                .ForMember(s => s.Id, map => map.MapFrom(ur => ur.Id))
                .ForMember(s => s.Email, map => map.MapFrom(ur => ur.Email))
                .ForMember(s => s.PhoneNumber, map => map.MapFrom(ur => ur.PhoneNumber))
                .ForMember(s => s.UserName, map => map.MapFrom(ur => ur.UserName))
                .ForMember(s => s.FirstName, map => map.MapFrom(ur => ur.FirstName))
                .ForMember(s => s.LastName, map => map.MapFrom(ur => ur.LastName))
                .ForMember(s => s.IsDeleted, map => map.MapFrom(ur => ur.IsDeleted))
                .ForMember(s => s.IsActive, map => map.MapFrom(ur => ur.IsActive))
                .ForMember(s => s.StoreId, map => map.MapFrom(ur => ur.StoreId))
            .ReverseMap().ForMember(s => s.Roles, r => r.Ignore())
            .ForMember(s => s.UserClaims, r => r.Ignore())
            .ForMember(s => s.UserLogins, r => r.Ignore());

            CreateMap<Store, StoreDTO>()
            .ForMember(s => s.ID, map => map.MapFrom(ur => ur.ID))
            .ForMember(s => s.Name, map => map.MapFrom(ur => ur.Name))
            .ForMember(s => s.Address, map => map.MapFrom(ur => ur.Address))
            .ForMember(s => s.AddressAr, map => map.MapFrom(ur => ur.AddressAr))
            .ForMember(s => s.Area, map => map.MapFrom(ur => ur.Area))
            .ForMember(s => s.Telephone, map => map.MapFrom(ur => ur.Telephone))
            .ForMember(s => s.StorKeeperId, map => map.MapFrom(ur => ur.StorKeeperId))
            .ForMember(s => s.Remarks, map => map.MapFrom(ur => ur.Remarks))
            .ForMember(s => s.image, map => map.MapFrom(ur => ur.image))
            .ForMember(s => s.IsActive, map => map.MapFrom(ur => ur.IsActive))
            .ForMember(s => s.IsDeleted, map => map.MapFrom(ur => ur.IsDeleted))
        .ReverseMap();

            CreateMap<Group, GroupDTO>()
           .ForMember(s => s.ID, map => map.MapFrom(ur => ur.ID))
           .ForMember(s => s.Name, map => map.MapFrom(ur => ur.Name))
           .ForMember(s => s.NameAr, map => map.MapFrom(ur => ur.NameAr))
           .ForMember(s => s.Description, map => map.MapFrom(ur => ur.Description))
           .ForMember(s => s.DescriptionAr, map => map.MapFrom(ur => ur.DescriptionAr))
           .ForMember(s => s.image, map => map.MapFrom(ur => ur.image))
           .ForMember(s => s.IsActive, map => map.MapFrom(ur => ur.IsActive))
           .ForMember(s => s.IsDeleted, map => map.MapFrom(ur => ur.IsDeleted))

       .ReverseMap();

            CreateMap<Subgroup, SubgroupDTO>()
         .ForMember(s => s.ID, map => map.MapFrom(ur => ur.ID))
         .ForMember(s => s.Name, map => map.MapFrom(ur => ur.Name))
         .ForMember(s => s.NameAr, map => map.MapFrom(ur => ur.NameAr))
         .ForMember(s => s.Description, map => map.MapFrom(ur => ur.Description))
         .ForMember(s => s.DescriptionAr, map => map.MapFrom(ur => ur.DescriptionAr))
         .ForMember(s => s.image, map => map.MapFrom(ur => ur.image))
         .ForMember(s => s.GroupId, map => map.MapFrom(ur => ur.GroupId))
         .ForMember(s => s.Group, map => map.MapFrom(ur => ur.Group))
         .ForMember(s => s.IsActive, map => map.MapFrom(ur => ur.IsActive))
         .ForMember(s => s.IsDeleted, map => map.MapFrom(ur => ur.IsDeleted))

     .ReverseMap();


            CreateMap<Item, ItemDTO>()
         .ForMember(s => s.ID, map => map.MapFrom(ur => ur.ID))
         .ForMember(s => s.Name, map => map.MapFrom(ur => ur.Name))
         .ForMember(s => s.NameAr, map => map.MapFrom(ur => ur.NameAr))
         .ForMember(s => s.Description, map => map.MapFrom(ur => ur.Description))
         .ForMember(s => s.DescriptionAr, map => map.MapFrom(ur => ur.DescriptionAr))
         .ForMember(s => s.image, map => map.MapFrom(ur => ur.image))
         .ForMember(s => s.SubgroupId, map => map.MapFrom(ur => ur.SubgroupId))
         .ForMember(s => s.Subgroup, map => map.MapFrom(ur => ur.Subgroup))
         .ForMember(s => s.Size, map => map.MapFrom(ur => ur.Size))
         .ForMember(s => s.UOM, map => map.MapFrom(ur => ur.UOM))
         .ForMember(s => s.ReorderLevel, map => map.MapFrom(ur => ur.ReorderLevel))
         .ForMember(s => s.BarCode, map => map.MapFrom(ur => ur.BarCode))
         .ForMember(s => s.ExpiryDateReminder, map => map.MapFrom(ur => ur.ExpiryDateReminder))
         .ForMember(s => s.Type, map => map.MapFrom(ur => ur.Type))
         .ForMember(s => s.IsActive, map => map.MapFrom(ur => ur.IsActive))
         .ForMember(s => s.IsDeleted, map => map.MapFrom(ur => ur.IsDeleted))

     .ReverseMap();

            CreateMap<Supplier, SupplierDTO>()
            .ForMember(s => s.ID, map => map.MapFrom(ur => ur.ID))
            .ForMember(s => s.CompanyName, map => map.MapFrom(ur => ur.CompanyName))
            .ForMember(s => s.City, map => map.MapFrom(ur => ur.City))
            .ForMember(s => s.Telephone, map => map.MapFrom(ur => ur.Telephone))
            .ForMember(s => s.Email, map => map.MapFrom(ur => ur.Email))
            .ForMember(s => s.Telephone, map => map.MapFrom(ur => ur.Telephone))
            .ForMember(s => s.ContactPerson, map => map.MapFrom(ur => ur.ContactPerson))
            .ForMember(s => s.Address, map => map.MapFrom(ur => ur.Address))
            .ForMember(s => s.FieldOfWork, map => map.MapFrom(ur => ur.FieldOfWork))
            .ForMember(s => s.Category, map => map.MapFrom(ur => ur.Category))
            .ForMember(s => s.Advantages, map => map.MapFrom(ur => ur.Advantages))
            .ForMember(s => s.TaxCertificate, map => map.MapFrom(ur => ur.TaxCertificate))
            .ForMember(s => s.CommercialRegistration, map => map.MapFrom(ur => ur.CommercialRegistration))
            .ForMember(s => s.IsDeleted, map => map.MapFrom(ur => ur.IsDeleted))
            .ForMember(s => s.IsActive, map => map.MapFrom(ur => ur.IsActive))
        .ReverseMap();

            CreateMap<Customer, CustomerDTO>()
           .ForMember(s => s.ID, map => map.MapFrom(ur => ur.ID))
           .ForMember(s => s.CompanyName, map => map.MapFrom(ur => ur.CompanyName))
           .ForMember(s => s.City, map => map.MapFrom(ur => ur.City))
           .ForMember(s => s.Telephone, map => map.MapFrom(ur => ur.Telephone))
           .ForMember(s => s.Email, map => map.MapFrom(ur => ur.Email))
           .ForMember(s => s.Telephone, map => map.MapFrom(ur => ur.Telephone))
           .ForMember(s => s.ContactPerson, map => map.MapFrom(ur => ur.ContactPerson))
           .ForMember(s => s.Address, map => map.MapFrom(ur => ur.Address))
           .ForMember(s => s.FieldOfWork, map => map.MapFrom(ur => ur.FieldOfWork))
           .ForMember(s => s.Category, map => map.MapFrom(ur => ur.Category))
           .ForMember(s => s.Advantages, map => map.MapFrom(ur => ur.Advantages))
           .ForMember(s => s.TaxCertificate, map => map.MapFrom(ur => ur.TaxCertificate))
           .ForMember(s => s.CommercialRegistration, map => map.MapFrom(ur => ur.CommercialRegistration))
           .ForMember(s => s.IsDeleted, map => map.MapFrom(ur => ur.IsDeleted))
           .ForMember(s => s.IsActive, map => map.MapFrom(ur => ur.IsActive))
       .ReverseMap();

            CreateMap<Employee, EmployeeDTO>()
   .ForMember(s => s.ID, map => map.MapFrom(ur => ur.ID))
   .ForMember(s => s.Name, map => map.MapFrom(ur => ur.Name))
   .ForMember(s => s.Department, map => map.MapFrom(ur => ur.Department))
.ReverseMap();

            CreateMap<OrderType, OrderTypeDTO>()
      .ForMember(s => s.ID, map => map.MapFrom(ur => ur.ID))
      .ForMember(s => s.Name, map => map.MapFrom(ur => ur.Name))
      .ForMember(s => s.NameAr, map => map.MapFrom(ur => ur.NameAr))
      .ForMember(s => s.ProcessType, map => map.MapFrom(ur => ur.ProcessType))
      .ForMember(s => s.IsActive, map => map.MapFrom(ur => ur.IsActive))
      .ForMember(s => s.IsDeleted, map => map.MapFrom(ur => ur.IsDeleted))
  .ReverseMap();

            CreateMap<Order, OrderDTO>()
    .ForMember(s => s.ID, map => map.MapFrom(ur => ur.ID))
    .ForMember(s => s.OrderNumber, map => map.MapFrom(ur => ur.OrderNumber))
    .ForMember(s => s.CreationDate, map => map.MapFrom(ur => ur.CreationDate))
    .ForMember(s => s.TypeId, map => map.MapFrom(ur => ur.TypeId))
    .ForMember(s => s.StoreId, map => map.MapFrom(ur => ur.StoreId))
    .ForMember(s => s.Store, map => map.MapFrom(ur => ur.Store))
    .ForMember(s => s.OrderDate, map => map.MapFrom(ur => ur.OrderDate))
    .ForMember(s => s.Type, map => map.MapFrom(ur => ur.OrderType))
    .ForMember(s => s.SupplierId, map => map.MapFrom(ur => ur.SupplierId))
    .ForMember(s => s.CustomerId, map => map.MapFrom(ur => ur.CustomerId))
    .ForMember(s => s.GettedFromStore, map => map.MapFrom(ur => ur.GettedFromStore))
    .ForMember(s => s.DeliveredToStore, map => map.MapFrom(ur => ur.DeliveredToStore))
    .ForMember(s => s.EmployeeId, map => map.MapFrom(ur => ur.EmployeeId))
    .ForMember(s => s.ItemList, map => map.MapFrom(ur => ur.OrderDetails))
    .ForMember(s => s.TotalAmount, map => map.MapFrom(ur => ur.TotalAmount))
    .ForMember(s => s.Comments, map => map.MapFrom(ur => ur.Comments))
    .ForMember(s => s.Attachment, map => map.MapFrom(ur => ur.Attachment))
.ReverseMap();


            CreateMap<OrderDetail, OrderDetailsDTO>()
    .ForMember(s => s.ID, map => map.MapFrom(ur => ur.ID))
    .ForMember(s => s.OrderId, map => map.MapFrom(ur => ur.OrderId))
    .ForMember(s => s.ItemId, map => map.MapFrom(ur => ur.ItemId))
    .ForMember(s => s.Item, map => map.MapFrom(ur => ur.Item))
    .ForMember(s => s.Quantity, map => map.MapFrom(ur => ur.Quantity))
    .ForMember(s => s.UnitPrice, map => map.MapFrom(ur => ur.UnitPrice))
    .ForMember(s => s.ProductionDate, map => map.MapFrom(ur => ur.ProductionDate))
    .ForMember(s => s.ExpiryDate, map => map.MapFrom(ur => ur.ExpiryDate))
.ReverseMap();

            CreateMap<Balance, BalanceDTO>()
 .ForMember(s => s.ID, map => map.MapFrom(ur => ur.ID))
 .ForMember(s => s.StoreId, map => map.MapFrom(ur => ur.StoreId))
 .ForMember(s => s.Store, map => map.MapFrom(ur => ur.Store))
 .ForMember(s => s.CreationDate, map => map.MapFrom(ur => ur.CreationDate))
 .ForMember(s => s.BalanceDate, map => map.MapFrom(ur => ur.BalanceDate))
 .ForMember(s => s.itemList, map => map.MapFrom(ur => ur.ItemBalances))
.ReverseMap();

            CreateMap<ItemBalance, ItemBalanceDTO>()
.ForMember(s => s.ID, map => map.MapFrom(ur => ur.ID))
.ForMember(s => s.BalanceId, map => map.MapFrom(ur => ur.BalanceId))
.ForMember(s => s.ItemId, map => map.MapFrom(ur => ur.ItemId))
.ForMember(s => s.Item, map => map.MapFrom(ur => ur.Item))
.ForMember(s => s.Quantity, map => map.MapFrom(ur => ur.Quantity))
.ReverseMap();

        }



        public override string ProfileName
        {
            get
            {
                return "AutoMapperWebProfile";
            }
        }
    }
}