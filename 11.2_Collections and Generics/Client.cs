namespace _11._2_Collections_and_Generics
{
    internal class Client
    {
        private readonly IProductA _productA;
        private readonly IProductB _productB;
        public Client(IFactory factory)
        {

            _productA = factory.CreateProductA();
            _productB = factory.CreateProductB();
        }

        public string GetNameProductA()
        {
            return _productA.GetNameProductA();
        }

        public string GetNameProductB()
        {
            return _productB.GetNameProductB();
        }
    }
}
