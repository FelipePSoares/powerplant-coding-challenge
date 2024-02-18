using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PowerplantCodingChallenge.Application;
using PowerplantCodingChallenge.Domain;
using PowerplantCodingChallenge.Server.Dtos;

namespace PowerplantCodingChallenge.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPowerplantService powerplantService;

        public ProductionPlanController(IPowerplantService powerplantService, IMapper mapper)
        {
            this.mapper = mapper;
            this.powerplantService = powerplantService;
        }

        [HttpPost(Name = "ProductionPlan")]
        public IEnumerable<PowerplantResponseDto> ProductionPlan([FromBody] ProductionPlanDto productionPlan)
        {
            var result = powerplantService.CalculateMeritOrder(mapper.Map<ProductionPlan>(productionPlan));

            return result.Select(powerplant => new PowerplantResponseDto(powerplant.Key, powerplant.Value));
        }
    }
}
