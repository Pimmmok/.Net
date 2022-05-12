using System;
using System.Text;

namespace _5._2_Incapsulation_and_overriding
{
    public class Polynomial
    {
        public double[] ArrayOfCoefficients { get; }
        public int Degree { get; }

        public Polynomial(double[] arrayOfCoefficients)
        {
            ArrayOfCoefficients = arrayOfCoefficients;
            Degree = arrayOfCoefficients.Length - 1;
        }

        public Polynomial()
        {
        }
        public bool Equals(Polynomial otherPolynomial)
        {
            if (otherPolynomial == null)
            {
                return false;
            }

            if (GetType() != otherPolynomial.GetType())
            {
                return false;
            }

            if (Degree != otherPolynomial.Degree)
            {
                return false;
            }

            for (int i = 0; i <= Degree; i++)
            {
                if (ArrayOfCoefficients[i] != otherPolynomial.ArrayOfCoefficients[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Polynomial polynomialObj = obj as Polynomial;
            return polynomialObj != null && Equals(polynomialObj);
        }

        public override int GetHashCode()
        {

            int hash = 0;
            for (int i = 0; i <= Degree; i++)
            {
                hash ^= ArrayOfCoefficients[i].GetHashCode();
            }
            return hash;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = Degree; i >= 0; i--)
            {
                double tempCoefficient = ArrayOfCoefficients[i];
                if (tempCoefficient != 0)
                {
                    if (i == 0)
                    {
                        _ = tempCoefficient < 0 ? stringBuilder.Append(tempCoefficient.ToString())
                            : stringBuilder.Append("+" + tempCoefficient.ToString());
                    }
                    else
                    {
                        if (i == Degree)
                        {
                            _ = stringBuilder.Append(tempCoefficient.ToString() + "x^" + i.ToString());
                        }
                        else
                        {
                            if (tempCoefficient < 0)
                            {
                                _ = stringBuilder.Append(tempCoefficient.ToString() + "x^" + i.ToString());
                            }
                            else
                            {
                                _ = stringBuilder.Append("+" + tempCoefficient.ToString() + "x^" + i.ToString());
                            }
                        }
                    }
                }
            }
            return stringBuilder.ToString();
        }
        public static bool operator ==(Polynomial polynomialOne, Polynomial polynomialTwo)
        {
            return ((object)polynomialOne) == null || ((object)polynomialTwo) == null
                ? Equals(polynomialOne, polynomialTwo)
                : polynomialOne.Equals(polynomialTwo);
        }

        public static bool operator !=(Polynomial polynomialOne, Polynomial polynomialTwo)
        {
            return ((object)polynomialOne) == null || ((object)polynomialTwo) == null
                ? !Equals(polynomialOne, polynomialTwo)
                : !polynomialOne.Equals(polynomialTwo);
        }

        public static Polynomial operator +(Polynomial polynomialOne, Polynomial polynomialTwo)
        {
            int degree = polynomialOne.Degree > polynomialTwo.Degree ? polynomialOne.Degree : polynomialTwo.Degree;
            double[] arrayOfCoefficients = new double[degree + 1];
            for (int i = 0; i <= degree; i++)
            {
                if (i <= polynomialOne.Degree && i <= polynomialTwo.Degree)
                {
                    arrayOfCoefficients[i] = polynomialOne.ArrayOfCoefficients[i] + polynomialTwo.ArrayOfCoefficients[i];
                }
                if (i > polynomialOne.Degree && i <= polynomialTwo.Degree)
                {
                    arrayOfCoefficients[i] = polynomialTwo.ArrayOfCoefficients[i];
                }
                if (i <= polynomialOne.Degree && i > polynomialTwo.Degree)
                {
                    arrayOfCoefficients[i] = polynomialOne.ArrayOfCoefficients[i];
                }
            }
            return new Polynomial(arrayOfCoefficients);
        }
        public static Polynomial operator -(Polynomial polynomialOne, Polynomial polynomialTwo)
        {
            int degree = polynomialOne.Degree > polynomialTwo.Degree ? polynomialOne.Degree : polynomialTwo.Degree;
            double[] arrayOfCoefficients = new double[degree + 1];
            for (int i = 0; i <= degree; i++)
            {
                if (i <= polynomialOne.Degree && i <= polynomialTwo.Degree)
                {
                    arrayOfCoefficients[i] = polynomialOne.ArrayOfCoefficients[i] - polynomialTwo.ArrayOfCoefficients[i];
                }
                if (i > polynomialOne.Degree && i <= polynomialTwo.Degree)
                {
                    arrayOfCoefficients[i] = -polynomialTwo.ArrayOfCoefficients[i];
                }
                if (i <= polynomialOne.Degree && i > polynomialTwo.Degree)
                {
                    arrayOfCoefficients[i] = polynomialOne.ArrayOfCoefficients[i];
                }
            }
            return new Polynomial(arrayOfCoefficients);
        }
        public static Polynomial operator *(Polynomial polynomialOne, Polynomial polynomialTwo)
        {
            int degree = polynomialOne.Degree + polynomialTwo.Degree;
            double[] arrayOfCoefficients = new double[degree + 1];
            for (int i = 0; i <= polynomialOne.Degree; i++)
            {
                for (int j = 0; j <= polynomialTwo.Degree; j++)
                {
                    arrayOfCoefficients[i + j] += polynomialOne.ArrayOfCoefficients[i] *
                    polynomialTwo.ArrayOfCoefficients[j];
                }
            }
            return new Polynomial(arrayOfCoefficients);
        }
    }
}
