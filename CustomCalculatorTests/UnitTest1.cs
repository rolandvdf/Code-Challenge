using System;
using CustomCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomCalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        private ICalculator _calculator;

        public UnitTest1()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        public void CalculatorAddOperatorWorks()
        {
            Assert.AreEqual(2, _calculator.EvaluateOperations("1+1"));
            Assert.AreEqual(1, _calculator.EvaluateOperations("0+1"));
            Assert.AreEqual(1, _calculator.EvaluateOperations("+1"));
            Assert.AreEqual(10, _calculator.EvaluateOperations("9+1"));
        }

        [TestMethod]
        public void CalculatorMinOperatorWorks()
        {
            Assert.AreEqual(0, _calculator.EvaluateOperations("1-1"));
            Assert.AreEqual(-1, _calculator.EvaluateOperations("0-1"));
            Assert.AreEqual(-1, _calculator.EvaluateOperations("-1"));
            Assert.AreEqual(9, _calculator.EvaluateOperations("10-1"));
        }

        [TestMethod]
        public void CalculatorPlusAndMinOperatorWorks()
        {
            Assert.AreEqual(0, _calculator.EvaluateOperations("-1+1"));
            Assert.AreEqual(-1, _calculator.EvaluateOperations("5-1+4"));
           
        }
    }
}
}
