using NUnit.Framework;

namespace _4_Creating_of_new_type.Tests
{

    public class MethodsTests
    {
        [TestCase(4, 3, 10, ExpectedResult = false)]
        [TestCase(0, 0, 1, ExpectedResult = false)]
        [TestCase(0, 0, 0, ExpectedResult = false)]
        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(-3, -4, -5, ExpectedResult = true)]
        [TestCase(3, 4, -5, ExpectedResult = true)]
        [TestCase(10, 10, 10, ExpectedResult = true)]
        public bool Exists_�orrectnessOfTheSides_ShouldBeTrue(double sideOne, double sideTwo, double sideThree)
        {
            Triangle triangle = new Triangle(sideOne, sideTwo, sideThree);
            return triangle.Exists();
        }

        [TestCase(3, 4, 5, ExpectedResult = 12)]
        [TestCase(10, 10, 10, ExpectedResult = 30)]
        [TestCase(11, 17, 27, ExpectedResult = 55)]
        public double �alculatePerimeter_Perimeter_ShouldBeCalculatedCorrectly(double sideOne, double sideTwo, double sideThree)
        {
            Triangle triangle = new Triangle(sideOne, sideTwo, sideThree);
            return triangle.�alculatePerimeter();
        }

        [TestCase(3, 4, 5, 0.001, 6)]
        [TestCase(5, 5, 6, 0.001, 12)]
        [TestCase(11, 11, 11, 0.001, 52.395)]
        public void �alculateArea_Area_ShouldBeCalculatedCorrectly(double sideOne, double sideTwo, double sideThree, double precision, double expected)
        {
            Triangle triangle = new Triangle(sideOne, sideTwo, sideThree);
            double actual = triangle.�alculateArea();
            Assert.AreEqual(expected, actual, precision);
        }
    }
}