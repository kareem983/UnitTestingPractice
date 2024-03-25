using UnitTestingPractice.Controllers;

namespace UnitTests
{
    public class MathimaticalControllerTest
    {
        private readonly MathematicalController mathematicalController;

        public MathimaticalControllerTest()
        {
            mathematicalController = new MathematicalController();
        }


        [Fact]
        public void GetSumTwoNumbers_True()
        {
            //Arrange
            int x = 2, y = 3;
            
            // Act
            int result = mathematicalController.GetSumTwoNumbers(x, y);

            // Assert
            Assert.True(result == 5);
        }

        [Fact]
        public void GetSumTwoNumbers_Fail()
        {
            //Arrange
            int x = 2, y = 3;

            // Act
            int result = mathematicalController.GetSumTwoNumbers(x, y);

            // Assert
            Assert.False(result != 5);
        }

        [Fact]
        public void GetAbstractTwoNumbers_True()
        {
            //Arrange
            int x = 10, y = 3;

            // Act
            int result = mathematicalController.GetAbstractTwoNumbers(x, y);

            // Assert
            Assert.True(result == 7);
        }

        [Fact]
        public void GetAbstractTwoNumbers_Fail()
        {
            //Arrange
            int x = 10, y = 3;

            // Act
            int result = mathematicalController.GetAbstractTwoNumbers(x, y);

            // Assert
            Assert.False(result != 7);
        }

        [Fact]
        public void GetMultiplyTwoNumbers_True()
        {
            //Arrange
            int x = 10, y = 3;

            // Act
            int result = mathematicalController.GetMultiplyTwoNumbers(x, y);

            // Assert
            Assert.True(result == 30);
        }

        [Fact]
        public void GetMultiplyTwoNumbers_Fail()
        {
            //Arrange
            int x = 10, y = 3;

            // Act
            int result = mathematicalController.GetMultiplyTwoNumbers(x, y);

            // Assert
            Assert.False(result != 30);
        }

        [Fact]
        public void GetDividTwoNumbers_True()
        {
            //Arrange
            int x = 10, y = 2;

            // Act
            int result = mathematicalController.GetDividTwoNumbers(x, y);

            // Assert
            Assert.True(result == 5);
        }

        [Fact]
        public void GetDividTwoNumbers2_True()
        {
            //Arrange
            int x = 10, y = 0;

            // Act
            int result = mathematicalController.GetDividTwoNumbers(x, y);

            // Assert
            Assert.True(result == 0);
        }


        [Fact]
        public void GetDividTwoNumbers_Fail()
        {
            //Arrange
            int x = 10, y = 2;

            // Act
            int result = mathematicalController.GetDividTwoNumbers(x, y);

            // Assert
            Assert.False(result != 5);
        }


    }
}