using AloneCoreApp.Application.ViewModels.Product;
using AloneCoreApp.Application.ViewModels.System;
using AloneCoreApp.Data.Entities;
using AutoMapper;

namespace AloneCoreApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Function, FunctionViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<AppUser, AppUserViewModel>();
        }
    }
}
