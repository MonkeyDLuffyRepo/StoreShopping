using AutoMapper;
using Shop.Application.Domains;
using Shop.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Presentation.Configurations
{
    public class AutoMappingRegister : Profile
    {
        public AutoMappingRegister()
        {
            #region Shared_Mapping
            CreateMap<Category, BaseModel>()
                    .ReverseMap()
                    ;
             CreateMap<Color, BaseModel>()
                    .ReverseMap()
                    ;
             CreateMap<Conservation, BaseModel>()
                    .ReverseMap()
                    ;
             CreateMap<Country, BaseModel>()
                    .ReverseMap()
                    ;
             CreateMap<Originality, BaseModel>()
                    .ReverseMap()
                    ;
             CreateMap<Region, BaseModel>()
                    .ReverseMap()
                    ;
              CreateMap<Taste, BaseModel>()
                    .ReverseMap()
                    ;
              CreateMap<Vintage, BaseModel>()
                    .ReverseMap()
                    ;
              CreateMap<Volume, BaseModel>()
                    .ReverseMap()
                    ;
            CreateMap<Category, ProductCategoryModel>()
                    .ReverseMap()
                    ;

            #endregion

            #region User_Mapping
            CreateMap<Customer, UserModel>()
                   .ForMember(d => d.Password, opt => opt.Ignore())
                   .ReverseMap()
                   .ForMember(d => d.Password, opt => opt.Ignore())
                   .ForMember(d => d.PasswordSalt, opt => opt.Ignore())
                   ;
            #endregion

            #region Customer_Mapping

            CreateMap<Customer, CustomerModel>()
                    .ReverseMap()
                    ;
            #endregion

            #region Panier_Mapping
            CreateMap<Panier, PanierModel>()
                     .ReverseMap()
                     ;
            CreateMap<PanierProduct, PanierProductModel>()
                     .ReverseMap()
                     ;
            #endregion

            #region Product_Mapping
            CreateMap<Product, ProductModel>()
                     .ReverseMap()
                     ;
            #endregion

            #region Store_Mapping
            CreateMap<ShopStore, ShopStoreModel>()
                      .ReverseMap()
                      ;
            #endregion
        }
    }
}
