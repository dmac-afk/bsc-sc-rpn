using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bsc_sc_rpn
{
    public partial class RPN : Form
    {
        public RPN()
        {
            InitializeComponent();
        }

        private void Btn_Eval_Click(object sender, EventArgs e)
        {
            try
            {
                //IStack<double> newStack = new ArrayStack<double>(24); // Create a new stack for each evaluation
                IStack<double> newStack = new LinkedListStack<double>();
                PolishNotationCalculator newCalculator = new PolishNotationCalculator(newStack); // Create a new calculator instance with the new stack

                double result = newCalculator.Evaluate(Txt_Input.Text.Trim());
                Lbl_Output.Text = $"Result: {result}";
            }

            catch (DivideByZeroException ex) { ShowError(ex.Message); }

            catch (InvalidOperationException ex) { ShowError(ex.Message); }

            catch (ArgumentException ex) { ShowError(ex.Message); }
        }

        private void ShowError(string message)
        {
            Lbl_Output.Text = "Error: " + message;
        }
    }
}
