namespace _11._2_Collections_and_Generics
{
    internal class Factory1 : IFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA1();
        }

        public IProductB CreateProductB() 
        {
            return new ProductB1();
        }
    }
}
