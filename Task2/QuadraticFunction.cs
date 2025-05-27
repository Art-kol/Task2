using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class QuadraticFunction : Function
    {
        private double b;
        private double c;

        public QuadraticFunction() : this(1.0, 0.0, 0.0) { }
        public QuadraticFunction(double a, double b, double c) : base(a)
        {
            this.b = b;
            this.c = c;
        }

        ~QuadraticFunction()
        {
            Console.WriteLine($"QuadraticFunction with a={a}, b={b}, c={c} is being finalized.");
        }

        // Реализация абстрактных методов
        public override double Calculate(double x)
        {
            return a * x * x + b * x + c;
        }

        public override void Display()
        {
            Console.WriteLine($"Quadratic function: y = {a}x² + {b}x + {c}");
        }

        // Свойства для коэффициентов b и c
        public double B
        {
            get { return b; }
            set { b = value; }
        }

        public double C
        {
            get { return c; }
            set { c = value; }
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;
            QuadraticFunction other = (QuadraticFunction)obj;
            return b == other.b && c == other.c;
        }

        public override int GetHashCode()
        {
            return (a, b, c).GetHashCode();
        }
    }
}
