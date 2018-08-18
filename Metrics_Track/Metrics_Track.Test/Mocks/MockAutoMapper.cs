namespace Metrics_Track.Test.Mocks
{
    using AutoMapper;
    using Metrics_Track.Web.Infrastructure.Mapping;

    public static class MockAutoMapper
    {
        static MockAutoMapper()
        {
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
        }

        public static IMapper GetMapper() => Mapper.Instance;                
    }
}
