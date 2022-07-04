using Collatz.Collatz;
using Collatz.Interfaces;
using Collatz.Services;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Collatz.Tests.ServiceTests
{
    public class CollatzServiceTests
    {
        private readonly ICollatzService _collatzService;
        
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<ICollatzService, CollatzService>()
                .BuildServiceProvider();

        public CollatzServiceTests()
        {
            _collatzService = A.Fake<ICollatzService>();
        }

        [Theory]
        [InlineData(69,1280, 40)]
        [InlineData(16, 5, 16)]
        [InlineData(256, 42, 64)]
        [InlineData(40, 24, 10)]
        [InlineData(168, 160, 16)]
        public void CollatzService_FindLeastCommonAncestor_ReturnsNumber(int a, int b,int expected)
        {
            //  Arrange
            var _collatz = serviceProvider.GetRequiredService<ICollatzService>();
            //A.CallTo(() => _collatzService.Find_Least_Common_Ancestor(a,b)).Returns(expected);           
            
            //  Act
            int x = _collatz.Find_Least_Common_Ancestor(a, b).value;
            
            //  Assert
            x.Should().Be(expected);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(12)]
        [InlineData(34)]
        [InlineData(23)]
        [InlineData(234)]
        [InlineData(3465)]
        public void CollatzService_PrintLeadingDigitDistributionFrom_PrintsDistribution(int x)
        {
            //  Arrange
            var _collatz = serviceProvider.GetRequiredService<ICollatzService>();
            //  Act
            _collatz.Print_Leading_Digit_Distribution_From(x);
            //  Assert

        }

        [Theory]
        [InlineData(6)]
        [InlineData(12)]
        [InlineData(34)]
        [InlineData(23)]
        [InlineData(234)]
        [InlineData(3465)]
        public void CollatzService_PrintCollatzChainFromNumber_PrintsChain(int x)
        {
            //  Arrange
            var _collatz = serviceProvider.GetRequiredService<ICollatzService>();
            //  Act
            _collatz.Print_Collatz_Chain_From_Number(x);
            //  Assert
            
        }
    }
}
