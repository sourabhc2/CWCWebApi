using AutoMapper;
using CWC.DAL.Entity;
using CWC.Models.RequestDTOs;
using CWC.Models.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWCAPI.Helper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<UserReqDTOs, Users>();  
            CreateMap<AuthReqDTOs, Users>();
            CreateMap<Users, AuthResDTOs>();
            CreateMap<VendorsReqDto, Vendors>().ForMember(x => x.ID, opt => opt.UseDestinationValue())
                                                 .ForMember(x => x.AddedBy, opt => opt.UseDestinationValue())
                                                 .ForMember(x => x.IsNewApproved, opt => opt.UseDestinationValue())
                                                 .ForMember(x => x.IsDeleted, opt => opt.UseDestinationValue());

            CreateMap<MenuItemReqDTOs, Menuitems>().ForMember(x => x.ID, opt => opt.UseDestinationValue())
                                                .ForMember(x => x.AddedBy, opt => opt.UseDestinationValue())
                                                .ForMember(x => x.DeletedBy, opt => opt.UseDestinationValue())
                                                 .ForMember(x => x.InventoryID, opt => opt.UseDestinationValue())
                                                .ForMember(x => x.ItemApprvFrmSuperAdm, opt => opt.UseDestinationValue())
                                                .ForMember(x => x.ItemDelFromSuperAdm, opt => opt.UseDestinationValue());
            CreateMap<OrderReqDTOs, Order>();
            CreateMap<CWC.Models.RequestDTOs.OrderItems, OrderItem>();
            CreateMap<InventoryReqDTOs, Inventory>();
        }
    }
}
