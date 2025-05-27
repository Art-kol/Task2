using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class LinearFunction : Function
    {
        private double b;

        public LinearFunction() : this(1.0, 0.0) { }
        public LinearFunction(double a, double b) : base(a)
        {
            this.b = b;
        }

        ~LinearFunction()
        {
            Console.WriteLine($"LinearFunction with a={a}, b={b} is being finalized.");
        }

        // Реализация абстрактных методов
        public override double Calculate(double x)
        {
            return a * x + b;
        }

        public override void Display()
        {
            Console.WriteLine($"Linear function: y = {a}x + {b}");
        }

        // Свойство для коэффициента b
        public double B
        {
            get { return b; }
            set { b = value; }
        }

        // Переопределение Equals для LinearFunction
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;
            LinearFunction other = (LinearFunction)obj;
            return b == other.b;
        }

        public override int GetHashCode()
        {
            return (a, b).GetHashCode();
        }
    }
}
