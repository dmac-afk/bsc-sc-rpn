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
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentException("Expression cannot be null or empty.");

            string[] tokens = expression.Split(' '); // split string into array on spaces

            foreach (string token in tokens)
            {
                if(string.IsNullOrWhiteSpace(token)) // skip empty tokens
                    continue;

                if (double.TryParse(token, out double value)) { stack.Push(value); } // add numbers to the stack

                else
                {
                    if (token != "+" && token != "-" && token != "*" && token != "/") // validate operator
                        throw new InvalidOperationException($"Invalid token: {token}");

                    double b = stack.Pop();
                    double a = stack.Pop();
                    double result = 0;

                    switch (token)
                    {
                        case "+":
                            result = a + b;
                            break;
                        case "-":
                            result = a - b;
                            break;
                        case "*":
                            result = a * b;
                            break;
                        case "/":   
                            if (b == 0)
                                throw new DivideByZeroException("Cannot divide by zero.");
                            result = a / b;
                            break;
                    }
                    stack.Push(result);
                }
            }
            return stack.Pop();
        }
    }
}
