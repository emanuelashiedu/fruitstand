using AutoMapper;
using FruitStand.Data.Models;
using FruitStand.Models;


namespace FruitStand.Providers
{
    public class AutoMapperAppProfileConfig : Profile
    {
        protected override void Configure()
        {

            CreateMap<FruitStandBindingModel, FruitStandViewModel>()
                .ForMember(dest => dest.saleDate,
                           opts => opts.MapFrom(src => src.SaleDate));

            CreateMap<FruitStandViewModel, FruitStandBindingModel>()
                .ForMember(dest => dest.SaleDate,
                           opts => opts.MapFrom(src => src.saleDate));

            CreateMap<FruitStandModel, FruitStandViewModel>()
                .ForMember(dest => dest.saleDate,
                           opts => opts.MapFrom(src => src.SalesDate))
                .ForMember(dest => dest.Fruit,
                           opts => opts.MapFrom(src => src.FruitType));
            //.ForMember(dest => dest.Id,
            //           opts => opts.MapFrom(src => src.Key.Id));

            CreateMap<FruitStandViewModel, FruitStandModel>()
                .ForMember(dest => dest.SalesDate,
                           opts => opts.MapFrom(src => src.saleDate))
                .ForMember(dest => dest.FruitType,
                           opts => opts.MapFrom(src => src.Fruit));
                 //.ForMember(dest => dest.Key.Id,
                 //          opts => opts.MapFrom(src => src.Id));

            
        }
    }
}