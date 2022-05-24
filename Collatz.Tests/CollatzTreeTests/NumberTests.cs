using Collatz.Collatz;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Collatz.Tests.CollatzTreeTests
{
   
    public class NumberTests
    {
        [Theory]
        [InlineData(204,2)]
        [InlineData(14, 1)]
        [InlineData(93324, 9)]
        [InlineData(4, 4)]
        public void Number_setLeadingDigit_ReturnInt(int x, int expected)
        {
            //  Arrange
            //  Act
            var number = new Number(x); //this function is called in the class constructor
            //  Assert
            number.Leading_Digit.Should().Be(expected);
        }

        [Theory]
        [InlineData(204, false)]
        [InlineData(14, false)]
        [InlineData(15, false)]
        [InlineData(9, true)]
        [InlineData(4, true)]
        [InlineData(100, true)]
        [InlineData(25, true)]
        [InlineData(936734, false)]
        [InlineData(93324, false)]
        [InlineData(81, true)]
        public void Number_isNumberSquare_ReturnsBool(int x, bool expected)
        {
            //  Arrange
            //  Act
            var result = new Number(x);
            //  Assert
            result.isPerfectSquare.Should().Be(expected);
        }
    }
}
