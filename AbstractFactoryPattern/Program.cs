using System;

namespace AbstractFactoryPattern
{
    /// Create our Abstract Factory:
    abstract class AbstractFactory
    {
        public abstract AbstractProductI CreateProductI();

        public abstract AbstractProductII CreateProductII();
    }
    class ConcreteFactoryI : AbstractFactory
    {
        public override AbstractProductI CreateProductI()
        {
            return new FirstProductOfAbstractI();
        }

        public override AbstractProductII CreateProductII()
        {
            return new FirstProductOfAbstractII();
        }
    }
    class ConcreteFactoryII : AbstractFactory
    {
        public override AbstractProductI CreateProductI()
        {
            return new SecondProductOfAbstractI();
        }

        public override AbstractProductII CreateProductII()
        {
            return new SecondProductOfAbstractII();
        }
    }
    class SecondProductOfAbstractI : AbstractProductI
    {
    }

    class SecondProductOfAbstractII : AbstractProductII
    {
        public override void Interact(AbstractProductI i)
        {
            Console.WriteLine(this.GetType().Name +
            " is linking with " + i.GetType().Name);
        }
    }
    /// Our First Abstract Product
    abstract class AbstractProductI
    {
    }

    /// Our Second Abstract Product
    abstract class AbstractProductII
    {
        public abstract void Interact(AbstractProductI i);
    }

    class FirstProductOfAbstractI : AbstractProductI
    {
    }

    class FirstProductOfAbstractII : AbstractProductII
    {
        public override void Interact(AbstractProductI i)
        {
            Console.WriteLine(this.GetType().Name +
            " is linking with " + i.GetType().Name);
        }
    }
    class Client
    {
        private AbstractProductI _abstractProductI;
        private AbstractProductII _abstractProductII;

        public Client(AbstractFactory factory)
        {
            _abstractProductI = factory.CreateProductI();
            _abstractProductII = factory.CreateProductII();
        }

        public void Run()
        {
            _abstractProductII.Interact(_abstractProductI);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactory factoryI = new ConcreteFactoryI();
            Client clientI = new Client(factoryI);
            clientI.Run();

            AbstractFactory factoryII = new ConcreteFactoryII();
            Client clientII = new Client(factoryII);
            clientII.Run();
        }
    }
}
