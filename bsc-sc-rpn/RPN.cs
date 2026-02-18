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
        private IStack<double> stack;
        private PolishNotationCalculator calculator;

        public RPN()
        {
            InitializeComponent();

            stack = new ArrayStack<double>(100); // Initialize stack with a capacity of 100
            calculator = new PolishNotationCalculator(stack); // Create calculator instance with the stack
        }

        private void Btn_Eval_Click(object sender, EventArgs e)
        {
            string expression = Txt_Input.Text.Trim();

            if (string.IsNullOrEmpty(expression))
            {
                MessageBox.Show("Please enter a valid expression.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                double result = calculator.Evaluate(expression);
                Lbl_Output.Text = $"Result: {result}";
            }
            catch (Exception ex)
            {
                Lbl_Output.Text = "Error: " + ex.Message;
            }
          
        }
    }
}
