using AutoMapper;
using PowerplantCodingChallenge.Domain;
using PowerplantCodingChallenge.Server.Dtos;
namespace AutoMapperDemo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FuelCostDto, FuelCost>();
            CreateMap<PowerplantDto, Powerplant>();
            CreateMap<ProductionPlanDto, ProductionPlan>();
        }
    }
}