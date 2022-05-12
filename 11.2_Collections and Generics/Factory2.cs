namespace _11._2_Collections_and_Generics
{
    internal class Factory2 : IFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA2();
        }

        public IProductB CreateProductB()
        {
            return new ProductB2();
        }
    }
}
