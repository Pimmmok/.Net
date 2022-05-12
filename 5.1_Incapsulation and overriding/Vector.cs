using System;

namespace _5._1_Incapsulation_and_overriding
{
    public class Vector
    {
        public string Name { get; set; } = "A";
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector()
        {
            X = Y = Z = 0;
        }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector(string name, double x, double y, double z)
        {
            Name = name;
            X = x;
            Y = y;
            Z = z;
        }

        public bool Equals(Vector otherVector)
        {
            if (otherVector == null)
            {
                return false;
            }

            if (GetType() != otherVector.GetType())
            {
                return false;
            }

            return X == otherVector.X && Y == otherVector.Y && Z == otherVector.Z;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Vector vectorObj = obj as Vector;
            return vectorObj != null && Equals(vectorObj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public override string ToString()
        {
            return new string(" Vektor "
                              + Name
                              + " ( "
                              + X.ToString("f3")
                              + " , "
                              + Y.ToString("f3")
                              + " , "
                              + Z.ToString("f3")
                              + " )");
        }

        public static bool operator ==(Vector vectorOne, Vector vectorTwo)
        {
            return ((object)vectorOne) == null || ((object)vectorTwo) == null ? Equals(vectorOne, vectorTwo)
                : vectorOne.Equals(vectorTwo);
        }

        public static bool operator !=(Vector vectorOne, Vector vectorTwo)
        {
            return ((object)vectorOne) == null || ((object)vectorTwo) == null
                ? !Object.Equals(vectorOne, vectorTwo)
                : !vectorOne.Equals(vectorTwo);
        }

        public static Vector operator +(Vector vectorOne, Vector vectorTwo)
        {
            Vector temp = new Vector
            {
                Name = vectorOne.Name + " + " + vectorTwo.Name,
                X = vectorOne.X + vectorTwo.X,
                Y = vectorOne.Y + vectorTwo.Y,
                Z = vectorOne.Z + vectorTwo.Z
            };
            return temp;
        }
        public static Vector operator -(Vector vectorOne, Vector vectorTwo)
        {
            Vector temp = new Vector
            {
                Name = vectorOne.Name + " - " + vectorTwo.Name,
                X = vectorOne.X - vectorTwo.X,
                Y = vectorOne.Y - vectorTwo.Y,
                Z = vectorOne.Z - vectorTwo.Z
            };
            return temp;
        }
        public static Vector operator *(Vector vectorOne, Vector vectorTwo)
        {
            Vector temp = new Vector
            {
                Name = vectorOne.Name + " * " + vectorTwo.Name,
                X = (vectorOne.Y * vectorTwo.Z) - (vectorOne.Z * vectorTwo.Y),
                Y = -((vectorOne.X * vectorTwo.Z) - (vectorOne.Z * vectorTwo.X)),
                Z = (vectorOne.X * vectorTwo.Y) - (vectorOne.Y * vectorTwo.X)
            };
            return temp;
        }

        public double CalculateScalarMultiplication(Vector otherVector)
        {
            return (X * otherVector.X) + (Y * otherVector.Y) + (Z * otherVector.Z);
        }

        public double CalculateLength()
        {
            return Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
        }

        public double CalculateAngleBetweenVectors(Vector otherVector)
        {
            double lengthOfVector = CalculateLength();
            double lengthOfOtherVector = otherVector.CalculateLength();
            return lengthOfVector != 0 & lengthOfOtherVector != 0
                ? Math.Acos(CalculateScalarMultiplication(otherVector)
                / CalculateLength() / otherVector.CalculateLength()) * 180 / Math.PI
                : double.NaN;
        }
    }
}
