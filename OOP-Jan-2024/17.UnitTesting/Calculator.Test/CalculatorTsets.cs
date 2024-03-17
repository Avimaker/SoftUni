using System;
namespace Calculator.Test
{
	public class CalculatorTsets
	{
		[Test]
		public void CalculatorArr_ShouldReturnCorrectly()
		{
			Calculator calculator = new Calculator();
			int result = calculator.Add(5, 6);
			Assert.AreEqual(11, result, $"Adding 5 and 6 should return 11 and not {result}");


		}

        [Test]
        public void SecondTest()
        {

        }

    }
}

