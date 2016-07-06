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
        public void GreatestCommonDivisionTest_ValuesAreZero__ShouldThrowArgumentException()
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
        public void RootOfDegreeNTest_NegativeValue__ShouldThrowArgumentException()
        {
            // arrange
            double value = -1;

            // act
            Algebra.RootOfDegreeN(value, 1);

            // assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RootOfDegreeNTest_NegativeAccuracy__ShouldThrowArgumentException()
        {
            // arrange
            double accuracy = -1;

            // act
            Algebra.RootOfDegreeN(2, 1, accuracy);

            // assert is handled by ExpectedException

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RootOfDegreeNTest_AccuracyGreaterThanOne__ShouldThrowArgumentException()
        {
            // arrange
            double accuracy = 1.5;

            // act
            Algebra.RootOfDegreeN(2, 1, accuracy);

            // assert is handled by ExpectedException

        }
    }
}