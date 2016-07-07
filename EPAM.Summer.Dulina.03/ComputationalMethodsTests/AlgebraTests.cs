using System;
using ComputationalMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputationalMethodsTests
{
    [TestClass]
    public class AlgebraTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GreatestCommonDivisionTest_ValuesAreZero_ShouldThrowArgumentException()
        {
            // arrange

            // act
            Algebra.GreatestCommonDivision(0, 0);

            // assert is handled by ExpectedException
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\GreatestCommonDivisionBinaryTests.csv", "GreatestCommonDivisionBinaryTests#csv", DataAccessMethod.Sequential), DeploymentItem("GreatestCommonDivisionBinaryTests.csv")]
        [TestMethod]
        public void GreatestCommonDivisionTest_ValuesAreNotZero_ShouldReturnCorrect()
        {
            // arrange
            int a = Convert.ToInt32(TestContext.DataRow[0]);
            int b = Convert.ToInt32(TestContext.DataRow[1]);
            int expected = Convert.ToInt32(TestContext.DataRow[2]);

            // act
            int actual = Algebra.GreatestCommonDivision(a, b);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\NumbersForRootOfDegreeN.xml", "TestCase", DataAccessMethod.Sequential), DeploymentItem("NumbersForRootOfDegreeN.xml")]
        [TestMethod]
        public void RootOfDegreeNTest_DataDrivenValues_AllShouldPass()
        {
            // arrange
            double value = Convert.ToDouble(TestContext.DataRow["Value"]);
            double n = Convert.ToDouble(TestContext.DataRow["Power"]);
            double accuracy = Convert.ToDouble(TestContext.DataRow["Accuracy"]);
            double expected = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);

            // act
            double actual = Algebra.RootOfDegreeN(value, n, accuracy);

            // assert
            Assert.IsFalse(Math.Abs(expected - actual) > accuracy);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RootOfDegreeNTest_NegativeValue_ShouldThrowArgumentException()
        {
            // arrange
            double value = -1;

            // act
            Algebra.RootOfDegreeN(value, 1);

            // assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RootOfDegreeNTest_NegativeAccuracy_ShouldThrowArgumentException()
        {
            // arrange
            double accuracy = -1;

            // act
            Algebra.RootOfDegreeN(2, 1, accuracy);

            // assert is handled by ExpectedException

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RootOfDegreeNTest_AccuracyGreaterThanOne_ShouldThrowArgumentException()
        {
            // arrange
            double accuracy = 1.5;

            // act
            Algebra.RootOfDegreeN(2, 1, accuracy);

            // assert is handled by ExpectedException

        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\BitStuffingTests.xml",
            "TestCase", DataAccessMethod.Sequential), DeploymentItem("BitStuffingTests.xml")]
        [TestMethod]
        public void BitStuffing_DataDrivenValues_AllShouldPass()
        {
            // arrange
            int a = Convert.ToInt32(Convert.ToString(TestContext.DataRow["FirstNumber"]), 2);
            int b = Convert.ToInt32(Convert.ToString(TestContext.DataRow["SecondNumber"]), 2);
            int from = Convert.ToInt32(TestContext.DataRow["From"]);
            int to = Convert.ToInt32(TestContext.DataRow["To"]);
            string result = Convert.ToString(TestContext.DataRow["Result"]);

            // act
            int actual = Algebra.BitStuffing(a, b, from, to);

            // assert
            Assert.AreEqual(result, Convert.ToString(actual, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BitStuffing_NegativeFrom_ShouldThrowArgumentException()
        {
            // arrange
            int from = -1;
            int to = 1;

            // act
            Algebra.BitStuffing(2, 1, from, to);

            // assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BitStuffing_NegativeTo_ShouldThrowArgumentException()
        {
            // arrange
            int from = 1;
            int to = -1;

            // act
            Algebra.BitStuffing(2, 1, from, to);

            // assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BitStuffing_FromToDifference_ShouldThrowArgumentException()
        {
            // arrange
            int from = 0;
            int to = 2;

            // act
            Algebra.BitStuffing(31, 11, from, to);

            // assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BitStuffing_SizeOfIntOverflow_ShouldThrowArgumentException()
        {
            // arrange
            int from = 31;
            int to = 40;

            // act
            Algebra.BitStuffing(31, 11, from, to);

            // assert is handled by ExpectedException
        }
    }
}