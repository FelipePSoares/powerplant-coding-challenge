using AutoMapper;
using AutoMapperDemo;

namespace PowerplantCodingChallenge.Server.Tests
{
    public class BaseTests
    {
        protected readonly IMapper mapper;

        public BaseTests()
        {
            this.mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            }).CreateMapper();
        }
    }
}
