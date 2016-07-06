using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ComputationalMethods;

namespace ComputationMethodsNUnitTests
{
    [TestFixture]
    public class AlgebraTests
    {
        [Test]
        [TestCase(1, 2, ExpectedResult = 1)]
        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(-5, 0, ExpectedResult = 5)]
        [TestCase(-10, -20, ExpectedResult = 10)]
        [TestCase(72, -96, ExpectedResult = 24)]
        public int GreatestCommonDivisionTest_ValuesAreNotZero_ShouldReturnCorrect(int a, int b)
        {
            // arrange

            // act
            return Algebra.GreatestCommonDivision(a, b);

            // assert
        }

        [Test]
        [TestCase(0, 0)]
        public void GreatestCommonDivisionTest_ValuesAreZero__ShouldThrowArgumentException(int a, int b)
        {
            // arrange

            // act

            // assert is handled by ExpectedException
            Assert.Throws<ArgumentException>(() => Algebra.GreatestCommonDivision(a, b));
        }
    }
}
