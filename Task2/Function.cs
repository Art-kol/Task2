using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public abstract class Function : IComparable<Function>
    {
        protected double a;

        protected Function() : this(1.0) { }
        protected Function(double a)
        {
            this.a = a;
        }


        // Сборщик мусора подчистит в main
        ~Function()
        {
            Console.WriteLine($"Function with a={a} is being finalized.");
        }

        public double A
        {
            get { return a; }
            set
            {
                if (value == 0 && this is Hyperbola)
                    throw new ArgumentException("Coefficient 'a' cannot be zero for hyperbola.");
                a = value;
            }
        }

        public static Function operator +(Function f1, Function f2)
        {
            if (f1 is LinearFunction l1 && f2 is LinearFunction l2)
            {
                return new LinearFunction(l1.A + l2.A, l1.B + l2.B);
            }
            else if (f1 is QuadraticFunction q1 && f2 is QuadraticFunction q2)
            {
                return new QuadraticFunction(q1.A + q2.A, q1.B + q2.B, q1.C + q2.C);
            }
            else if (f1 is Hyperbola h1 && f2 is Hyperbola h2)
            {
                if (h1.A + h2.A == 0)
                    throw new InvalidOperationException("Sum of coefficients 'a' cannot be zero for hyperbola.");
                return new Hyperbola(h1.A + h2.A);
            }
            else
            {
                throw new InvalidOperationException("Cannot add functions of different types.");
            }
        }

        public static bool operator ==(Function f1, Function f2)
        {
            // предварительная проверка, если ссылка на один и тот же объект
            if (ReferenceEquals(f1, f2)) return true;
            if (f1 is null || f2 is null) return false;

            // сверяем содержимое
            return f1.Equals(f2);
        }

        public static bool operator !=(Function f1, Function f2)
        {
            return !(f1 == f2);
        }
        
        public abstract double Calculate(double x);
        public abstract void Display();

        public int CompareTo(Function other)
        {
            if (other == null) return 1;
            return a.CompareTo(other.a);
        }


        public override bool Equals(object obj)
        {
            // 1. Проверка на null и тип объекта
            if (obj == null || GetType() != obj.GetType())
                return false;

            // 2. Приведение типа
            Function other = (Function)obj;
            // 3. Сравнение по значимым полям
            return a == other.a;
        }

        public override int GetHashCode()
        {
            return a.GetHashCode();
        }
    }
}
