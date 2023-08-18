using AutoMapper;
using lafise.test.Application.Common.Mappings;
using NUnit.Framework;

namespace Application.UnitTests.Common.Mappings.MappingTest
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
    }
}
