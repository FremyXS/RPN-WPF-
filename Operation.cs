using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCalculate.Logic
{
    public enum Operators
    {
        Plus,
        Minus,
        Division,
        Multiplication,
        Degree
    }
    public abstract class Operation
    {
        public abstract Operators Name { get; }
        public abstract int Priority { get; }
        public abstract double Evaluate(double numberOne, double numberTwo);

    }
    public class Plus : Operation
    {
        public override Operators Name => Operators.Plus;
        public override int Priority => 1;

        public override double Evaluate(double numberOne, double numberTwo)
            => Math.Round(numberOne + numberTwo, 2);

    }
    public class Minus : Operation
    {
        public override Operators Name => Operators.Plus;
        public override int Priority => 1;
        public override double Evaluate(double numberOne, double numberTwo)
            => Math.Round(numberOne - numberTwo, 2);
    }
    public class Multiplication : Operation
    {
        public override Operators Name => Operators.Plus;
        public override int Priority => 2;
        public override double Evaluate(double numberOne, double numberTwo)
            => Math.Round(numberOne * numberTwo, 2);
    }
    public class Division : Operation
    {
        public override Operators Name => Operators.Plus;
        public override int Priority => 2;
        public override double Evaluate(double numberOne, double numberTwo)
            => Math.Round(numberOne / numberTwo, 2);
    }
    public class Degree : Operation
    {
        public override Operators Name => Operators.Plus;
        public override int Priority => 3;
        public override double Evaluate(double numberOne, double numberTwo)
            => Math.Round(Math.Pow(numberOne, numberTwo), 2);
    }


}
