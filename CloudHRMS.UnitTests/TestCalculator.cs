using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudHRMS.UnitTests
{
    public class TestCalculator
    {
        [Fact]
        public void CheckSum3NumbersTrue()
        {
            //1 Arrange
            Calculator calculator = new Calculator();
            int a = 1, b = 1, c = 1;
            int expectedResult = 3;
            //2 Action
            int actualResult = calculator.Add(a, b, c);
            //3 Assert
            Assert.Equal(expectedResult, actualResult);


        }
        [Fact]
        public void CheckSum3NumbersFalse()
        {
            //1 Arrange
            Calculator calculator = new Calculator();
            int a = 1, b = 1, c = 1;
            int expectedResult = 5;
            //2 Action
            int actualResult = calculator.Add(a, b, c);
            //3 Assert
            Assert.NotEqual(expectedResult, actualResult);

        }
    }
}

