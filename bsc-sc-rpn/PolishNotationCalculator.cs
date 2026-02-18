using System;

namespace bsc_sc_rpn
{
    public class PolishNotationCalculator
    {
        private IStack<double> stack;

        public PolishNotationCalculator(IStack<double> stackImplementation)
        {
            stack = stackImplementation;
        }

        public double Evaluate(string expression)
        {
            string[] tokens = expression.Split(' ');

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double value)) { stack.Push(value); }

                else
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    double result;

                    if (token == "+")
                        result = a + b;
                    else if (token == "-")
                        result = a - b;
                    else if (token == "*")
                        result = a * b;
                    else if (token == "/")
                        result = a / b;
                    else 
                        throw new InvalidOperationException($"Unsupported operator: {token}");

                    stack.Push(result);
                }
            }
            return stack.Pop();
        }
    }
}
