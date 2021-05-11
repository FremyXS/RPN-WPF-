using NUnit.Framework;
using System.Collections.Generic;
using AdvancedCalculate.Logic;
using System.Diagnostics;
using System.Linq;
using System;

namespace AdvancedCalculate.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("1+2", ExpectedResult = new string[] { "1", "+", "2" })]
        [TestCase("150^4*-100+(456-8)", ExpectedResult = new string[] { "150", "^", "4", "*", "-100", "+", "(", "456", "-", "8", ")" })]
        public string[] GetFunctionList_WithoutArgument(string expression)
        {
            return Info.GetFunctionList(expression).ToArray();
        }

        [TestCaseSource(nameof(TestCasesWithoutArgument))]
        public void RPN_WithoutArgument(List<string> expression, object[] rpnTokens)
        {
            Assert.That(rpnTokens, Is.EquivalentTo(new RPN(expression).PostFix.ToArray()));
        }
        [TestCaseSource(nameof(TestCasesWithArgument))]
        public void GetRezultes_WithArgument(object[] expression, double start, double end, double step, Dictionary<double, double> resulte)
        {
            new Calculate(expression, start, end, step);
            Assert.That(resulte, Is.EquivalentTo(Calculate.AllResultes));
        }
        public static IEnumerable<TestCaseData> TestCasesWithoutArgument
        {
            get
            {
                yield return new TestCaseData(new string[] { "1", "+", "2" }.ToList(), new object[] { 1.0, 2.0, "+" });
                yield return new TestCaseData(new string[] { "1", "+", "2", "/", "1" }.ToList(), new object[] { 1.0, 2.0, 1.0, "/", "+" });
            }
        }
        public static IEnumerable<TestCaseData> TestCasesWithArgument
        {
            get
            {
                yield return new TestCaseData(new object[] { 1,"x", "+" }, 0, 4, 1, new Dictionary<double, double>
                {
                    { 0.0, 1.0 },
                    { 1.0, 2.0 },
                    { 2.0, 3.0 },
                    { 3.0, 4.0 },
                    { 4.0, 5.0 }
                });
            }
        }
    }
}