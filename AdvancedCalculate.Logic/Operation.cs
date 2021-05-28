using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCalculate.Logic
{
    public abstract class Operation
    {
        public abstract string Name { get; }
        public abstract int Priority { get; }
        public abstract double Evaluate(List<double> nums);

    }
    public class Plus : Operation
    {
        public override string Name => "+";
        public override int Priority => 1;

        public override double Evaluate(List<double> nums)
            => Math.Round(nums[1] + nums[0], 2);

    }
    public class Minus : Operation
    {
        public override string Name => "-";
        public override int Priority => 1;
        public override double Evaluate(List<double> nums)
            => Math.Round(nums[1] - nums[0], 2);
    }
    public class Multiplication : Operation
    {
        public override string Name => "*";
        public override int Priority => 2;
        public override double Evaluate(List<double> nums)
            => Math.Round(nums[1] * nums[0], 2);
    }
    public class Division : Operation
    {
        public override string Name => "/";
        public override int Priority => 2;
        public override double Evaluate(List<double> nums)
            => Math.Round(nums[1] / nums[0], 2);
    }
    public class Degree : Operation
    {
        public override string Name => "^";
        public override int Priority => 3;
        public override double Evaluate(List<double> nums)
            => Math.Round(Math.Pow(nums[1], nums[0]), 2);
    }
    

}
