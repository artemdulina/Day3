﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputationalMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ComputationalMethods.Tests
{
    [TestClass()]
    public class AlgebraTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod()]
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
            if (Math.Abs(expected - actual) > accuracy)
            {
                Assert.Fail("Accuracy test failed");
            }
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\ExceptionsConditionsForRootOfDegreeN.xml", "TestCase", DataAccessMethod.Sequential), DeploymentItem("ExceptionsConditionsForRootOfDegreeN.xml")]
        [TestMethod]
        public void RootOfDegreeNTest_ValueAndAccuracyArguments__ShouldThrowArgumentException()
        {
            // arrange
            double value = Convert.ToDouble(TestContext.DataRow["Value"]);
            double accuracy = Convert.ToDouble(TestContext.DataRow["Accuracy"]);

            // act
            try
            {
                double actual = Algebra.RootOfDegreeN(value, 1, accuracy);
            }
            catch (ArgumentException exception)
            {
                return;
            }
            // assert is handled by ExpectedException
            Assert.Fail(string.Format("ShouldThrowArgumentException: value:{0} or accuracy:{1}", value, accuracy));

        }
    }
}