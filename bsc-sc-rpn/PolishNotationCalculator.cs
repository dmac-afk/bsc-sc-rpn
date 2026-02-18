namespace bsc_sc_rpn
{
    public class PolishNotationCalculator
    {
        /* Use the IStack<double> interface type to allow the flexibility of using different stack implementations 
         * (e.g., ArrayStack or LinkedListStack). */
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

                    stack.Push(result);
                }
            }

            /*
             * 1. Split the expression into individual tokens using a space as the delimiter.
             * 2. Iterate over each token:
             *      - If the token is a number, push it onto the stack.
             *      - If the token is an operator (+, -, *, /):
             *          a. Pop two numbers from the stack (b first, then a).
             *          b. Perform the operation (a + b, a - b, etc.).
             *          c. Push the result back onto the stack.
             * 3. After processing all tokens, the result of the calculation will be the single number remaining on the stack.
             *    Pop and return it as the final result.
             */

            return stack.Pop();
        }
    }
}
