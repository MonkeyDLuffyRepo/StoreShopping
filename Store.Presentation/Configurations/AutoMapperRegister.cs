using AutoMapper;
using Store.Domain.PositionDomain;
using Store.Domain.StationDomain;
using Store.Domain.UserDomain;
using Store.Domain.VehiculeDomain;
using Store.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Presentation.Configurations
{
    public class AutoMappingRegister : Profile
    {
        public AutoMappingRegister()
        {
            #region Shared_Mapping
            //CreateMap<OpportunitySearchCriteria, OpportunitySearchCriteriaModel>()
            //    .ReverseMap()
            //    ;

            //CreateMap<OpportunityStage, OpportunityStageModel>()
            //    .ForMember(d => d.CreationDate, opt => opt.ConvertUsing(new DateTimeToStringFormatter()))
            //    .ForMember(d => d.ModificationDate, opt => opt.ConvertUsing(new DateTimeToStringFormatter()))
            //    .ForMember(d => d.ExpectedCloseDate, opt => opt.ConvertUsing(new DateTimeToStringFormatter()))
            //    .ForMember(d => d.CloseDate, opt => opt.ConvertUsing(new DateTimeToStringFormatter()))
            //    ;

            //CreateMap<Opportunity, OpportunityModel>()
            //    .ForMember(d => d.OwnerName, opt => opt.MapFrom(s => s.Owner.DisplayName))
            //    .ForMember(d => d.CreationDate, opt => opt.ConvertUsing(new DateTimeToStringFormatter()))
            //    .ForMember(d => d.ModificationDate, opt => opt.ConvertUsing(new DateTimeToStringFormatter()))
            //    .ForMember(d => d.ExpectedCloseDate, opt => opt.ConvertUsing(new DateTimeToStringFormatter()))
            //    .ForMember(d => d.CloseDate, opt => opt.ConvertUsing(new DateTimeToStringFormatter()))
            //     ;
            //CreateMap<OpportunityModel, Opportunity>()
            //    .ForMember(d => d.Company, opt => opt.Ignore())
            //    .ForMember(d => d.CreationDate, opt => opt.ConvertUsing(new DateTimeParser()))
            //    .ForMember(d => d.ModificationDate, opt => opt.ConvertUsing(new DateTimeParser()))
            //    .ForMember(d => d.ExpectedCloseDate, opt => opt.ConvertUsing(new DateTimeParser()))
            //    .ForMember(d => d.CloseDate, opt => opt.ConvertUsing(new DateTimeParser()))
            //    ;

            //CreateMap<Opportunity, OpportunityDetailModel>()
            //     .IncludeBase<Opportunity, OpportunityModel>()
            //     .ForMember(d => d.Stages, opt => opt.MapFrom(s => s.OpportunityStages))
            //     .ForMember(d => d.Owner, opt => opt.MapFrom(s => s.Owner))
            //     .ForMember(d => d.People, opt => opt.MapFrom(s => s.OpportunityPeople))
            //     .ForMember(d => d.Company, opt => opt.Ignore())
            //     .ForMember(d => d.CurrentStage, opt => opt.Ignore())
            //     .ForMember(d => d.BusniessType, opt => opt.Ignore())
            //     .ForMember(d => d.Source, opt => opt.Ignore())
            //     .ForMember(d => d.Stages, opt => opt.Ignore())
            //     .ForMember(d => d.Companies, opt => opt.Ignore())
            //     ;
            //CreateMap<Person, Model.ContactManagement.PersonModel>()
            //           .ForMember(d => d.CreationDate,
            //        opt
            //            => opt.MapFrom(s => s.CreationDate.Value.ToString("yyyy-MM-dd HH:mm")))
            //          .ForMember(d => d.ModificationDate,
            //        opt
            //            => opt.MapFrom(s => s.ModificationDate.Value.ToString("yyyy-MM-dd HH:mm")))
            //  .ReverseMap();

            //CreateMap<Person, Model.ContactManagement.PersonModel>()
            //    .ForMember(d => d.CompanyName,
            //        opt
            //            => opt.MapFrom(s => s.Company.CompanyName))

            //    .ForMember(d => d.Owner,
            //        opt
            //            => opt.MapFrom(s => s.CreatedBy.DisplayName))

            //    .ForMember(d => d.Modifier,
            //        opt
            //            => opt.MapFrom(s => s.ModifiedBy.DisplayName));

            //CreateMap<Person, BaseModel>()
            //       .ForMember(d => d.Id, opt => opt.MapFrom(s => s.PeopleId))
            //       .ForMember(d => d.Name, opt => opt.MapFrom(s => s.UserName))
            //       ;
            //CreateMap<Person, PersonBaseModel>()
            //        .ForMember(d => d.Id, opt => opt.MapFrom(s => s.PeopleId))
            //        .ForMember(d => d.Name, opt => opt.MapFrom(s => s.UserName))
            //        ;

            //CreateMap<PersonSearchCriteria, Olympus.Model.ContactManagement.PersonSearchCriteriaModel>()
            //      .ForMember(d => d.PersonNatureId, opt => opt.MapFrom(s => s.PeopleNatureId))
            //      .ForMember(d => d.PersonNatureIds, opt => opt.MapFrom(s => s.PeopleNatureIds))
            //    .ReverseMap()
            //    ;
            //CreateMap<Person, UserModel>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.PeopleId))
            //    .ForMember(d => d.CreationDate, opt => opt.ConvertUsing(new DateTimeToStringFormatter()))
            //    .ForMember(d => d.ModificationDate, opt => opt.ConvertUsing(new DateTimeToStringFormatter()))
            //    .ForMember(d => d.Email, opt => opt.MapFrom(s => s.UserName))
            //    .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.Company.CompanyName))
            //    .ForMember(d => d.DisplayName, opt => opt.MapFrom(s => s.FirstName + ' ' + s.LastName))
            //    .ForMember(d => d.OwnerId, opt => opt.MapFrom(s => s.CreatedById))
            //    .ForMember(d => d.Owner, opt => opt.MapFrom(s => s.CreatedBy))
            //.ForMember(d => d.Roles, opt => opt.MapFrom(s => s.UserRoles))
            //.ReverseMap()
            //       .ForMember(d => d.PeopleId, opt => opt.MapFrom(s => s.Id))
            //       .ForMember(d => d.CreationDate, opt => opt.ConvertUsing(new DateTimeParser()))
            //       .ForMember(d => d.ModificationDate, opt => opt.ConvertUsing(new DateTimeParser()))
            //       .ForPath(s => s.Company, opt => opt.Ignore())
            //       .ForPath(s => s.Addresses, opt => opt.Ignore())
            //       .ForPath(s => s.MailAddresses, opt => opt.Ignore())
            //       ;

            //CreateMap<Role, BaseModel>()
            //      .ForMember(d => d.Id, opt => opt.MapFrom(s => s.RoleId))
            //      .ForMember(d => d.Name, opt => opt.MapFrom(s => s.RoleName))
            //      ;
            //CreateMap<Company, BaseModel>()
            //         .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CompanyId))
            //         .ForMember(d => d.Name, opt => opt.MapFrom(s => s.CompanyName))
            //         ;

            //CreateMap<Company, CompanyModel>()
            //     .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CompanyId))
            //     .ForMember(d => d.Name, opt => opt.MapFrom(s => s.CompanyName))
            //     .ForMember(d => d.BusinessIndustryId, opt => opt.MapFrom(s => s.BusinessIndustryId))
            //     .ForMember(d => d.CreationDate, opt => opt.ConvertUsing(new DateTimeToStringFormatter()))
            //     .ForMember(d => d.ModificationDate, opt => opt.ConvertUsing(new DateTimeToStringFormatter()))
            //     .ForMember(d => d.ParentCompany, opt => opt.Ignore())
            //     .ReverseMap()
            //     .ForMember(s => s.CompanyId, opt => opt.MapFrom(s => s.CompanyId))
            //     .ForMember(s => s.CompanyName, opt => opt.MapFrom(s => s.CompanyName))
            //     .ForMember(d => d.CreationDate, opt => opt.ConvertUsing(new DateTimeParser()))
            //     .ForMember(d => d.ModificationDate, opt => opt.ConvertUsing(new DateTimeParser()))
            //     .ForMember(s => s.ParentCompany, opt => opt.Ignore())
            //     .ForMember(s => s.Owner, opt => opt.Ignore())
            //     ;
            #endregion

            #region Person_Mapping

            #endregion

            #region User_Mapping

            CreateMap<Person, UserModel>()
                    .ReverseMap()
                    ;
            #endregion

            #region Vehicule_Mapping
            CreateMap<Vehicule, VehiculeModel>()
                     .ReverseMap()
                     ;
            #endregion

            #region Station_Mapping
            CreateMap<Station, StationModel>()
                     .ReverseMap()
                     ;
            #endregion

            #region Position_Mapping
            CreateMap<Position, PositionModel>()
                      .ReverseMap()
                      ;
            #endregion
        }
    }
}
