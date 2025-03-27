using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatternSample.Decorator
{
    internal class DecoratorDesignPattern
    {
        //نام دیگر دکوریتور رپر هست
        //other name is Wrapper

    }


    public interface ICoffee
    {
        double GetCost();
        string GetDescription();
    }

    public class SimpleCoffee : ICoffee
    {
        public double GetCost()
        {
            return 1;
        }
        public string GetDescription()
        {
            return "Simple Coffee";
        }
    }

    public class CoffeeDecorator : ICoffee
    {
        private readonly ICoffee _coffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public virtual double GetCost() => _coffee.GetCost();

        public virtual string GetDescription() => _coffee.GetDescription();
    }

    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee)
        {
        }
        public override double GetCost()
        {
            return base.GetCost() + 0.5;
        }
        public override string GetDescription()
        {
            return base.GetDescription() + ", Milk";
        }
    }

    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee)
        {
        }
        public override double GetCost()
        {
            return base.GetCost() + 0.2;
        }
        public override string GetDescription()
        {
            return base.GetDescription() + ", Sugar";
        }
    }

    public class ChocolateDecorator : CoffeeDecorator
    {
        public ChocolateDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override double GetCost()
        {
            return base.GetCost() + 0.6;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " " + "Chocolate";
        }
    }


}
