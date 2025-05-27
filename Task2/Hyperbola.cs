using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Hyperbola : Function
    {
        public Hyperbola() : this(1.0) { }
        public Hyperbola(double a) : base(a)
        {
            if (a == 0)
                throw new ArgumentException("Coefficient 'a' cannot be zero for hyperbola.");
        }

        ~Hyperbola()
        {
            Console.WriteLine($"Hyperbola with a={a} is being finalized.");
        }

        // Реализация абстрактных методов
        public override double Calculate(double x)
        {
            if (x == 0)
                throw new DivideByZeroException("x cannot be zero for hyperbola function.");
            return a / x;
        }

        public override void Display()
        {
            Console.WriteLine($"Hyperbola: y = {a}/x");
        }

        // Переопределение свойства A для проверки на ноль
        public new double A
        {
            get { return a; }
            set
            {
                if (value == 0)
                    throw new ArgumentException("Coefficient 'a' cannot be zero for hyperbola.");
                a = value;
            }
        }
    }
}
