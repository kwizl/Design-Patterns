namespace DecoratorPattern
{
    public abstract class Coffee
    {
        public abstract double Cost();
        public abstract string Description();
    }

    public class SimpleCoffee : Coffee
    {
        public override double Cost()
        {
            return 5;
        }

        public override string Description()
        {
            return "Simple Coffee";
        }
    }

    public abstract class CoffeeDecorator : Coffee
    {
        protected Coffee _coffee;
        protected CoffeeDecorator(Coffee coffee)
        {
            _coffee = coffee;
        }

        public abstract override double Cost();
        public abstract override string Description();
    }

    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(Coffee coffee) : base(coffee) { }

        public override double Cost()
        {
            return _coffee.Cost() + 1;
        }

        public override string Description()
        {
            return _coffee.Description() + ", with milk";
        }
    }

    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(Coffee coffee) : base(coffee) { }

        public override double Cost()
        {
            return _coffee.Cost() + 1;
        }

        public override string Description()
        {
            return _coffee.Description() + ", with sugar";
        }
    }
}
