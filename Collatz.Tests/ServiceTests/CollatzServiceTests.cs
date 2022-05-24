using Collatz.Interfaces;
using Collatz.Services;
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
        
            //  Add dependencies for tests
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<ICollatzService, CollatzService>()
                .BuildServiceProvider();
        



        [Theory]
        [InlineData(69,1280, 40)]
        [InlineData(16, 5, 16)]
        [InlineData(256, 42, 64)]
        [InlineData(40, 24, 10)]
        [InlineData(168, 160, 16)]
        public void CollatzService_FindLeastCommonAncestor_ReturnsNumber(int a, int b,int expected)
        {
            //Arrange
            //  Access service
            var _collatz = serviceProvider.GetRequiredService<ICollatzService>();
            //Act
            int x = _collatz.Find_Least_Common_Ancestor(a, b).value;
            //Assert
            x.Should().Be(expected);
        }



        //public void CollatzService_PrintLeadingDigitDistributionFrom_PrintsDistribution(int a, int b, int expected)
        //{
        //    //Arrange

        //    //Act

        //    //Assert
        //}



        //public void CollatzService_PrintCollatzChainFromNumber_PrintsChain(int a, int b, int expected)
        //{
        //    //Arrange

        //    //Act

        //    //Assert
        //}












    }
}