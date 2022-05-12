using System;

namespace _4_Creating_of_new_type
{
    public struct Triangle
    {
        private double sideOne;
        private double sideTwo;
        private double sideThree;

        public Triangle(double sideOne, double sideTwo, double sideThree)
        {
            this.sideOne = Math.Abs(sideOne);
            this.sideTwo = Math.Abs(sideTwo);
            this.sideThree = Math.Abs(sideThree);
        }

        public void GetSide(out double sideOne, out double sideTwo, out double sideThree)
        {
            sideOne = this.sideOne;
            sideTwo = this.sideTwo;
            sideThree = this.sideThree;
        }
        public void SetSide(double sideOne, double sideTwo, double sideThree)
        {
            this.sideOne = Math.Abs(sideOne); ;
            this.sideTwo = Math.Abs(sideTwo);
            this.sideThree = Math.Abs(sideThree);
        }
        public bool Exists()
        {
            return (sideOne + sideTwo > sideThree) && (sideTwo + sideThree > sideOne) && (sideOne + sideThree) > sideTwo;
        }

        public double СalculatePerimeter()
        {
            return sideOne + sideTwo + sideThree;
        }

        public double СalculateArea()
        {
            double halfPerimeter = СalculatePerimeter() / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - sideOne) * (halfPerimeter - sideTwo) * (halfPerimeter - sideThree));
        }

        public override string ToString()
        {
            return new string(" Object : side one = "
                + sideOne.ToString()
                + ", side two = "
                + sideTwo.ToString()
                + ", side three = "
                + sideThree.ToString());
        }
    }
}
