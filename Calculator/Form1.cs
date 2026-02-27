using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double num;
        double result;

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                string text = btn.Text;

                switch (text)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "0":
                    case ".":
                    case "+":
                    case "-":
                    case "/":
                    case "*":
                    case "%":
                        txtDisplay.Text += text;
                        break;
                    case "√":
                        Sqrt();
                        break;
                    case "±":
                        ToPlusOrMinusNum();
                        break;
                    case "1/x":
                        DivideByOne();
                        break;
                    case "←":
                        Backspace();
                        break;
                    case "C":
                        Clear();
                        break;
                    case "=":
                        CalculateExpression(txtDisplay.Text);
                        break;
                }
            }
        }

        private void Sqrt()
        {
            if (double.TryParse(txtDisplay.Text, out num) && num != 0)
            {
                txtDisplay.Text = (Math.Sqrt(num)).ToString();
            }
        }

        private void ToPlusOrMinusNum()
        {
            if (double.TryParse(txtDisplay.Text, out num))
            {
                num = -num;
                txtDisplay.Text = num.ToString();
            }
        }

        private void DivideByOne()
        {
            double result = 1 / num;

            if (double.TryParse(txtDisplay.Text, out num))
            {
                if (num == 0)
                {
                    txtDisplay.Text = "";
                    return;
                }

                txtDisplay.Text = result.ToString();
            }
        }

        private void Backspace()
        {
            if (txtDisplay.Text == result.ToString())
            {
                return;
            }

            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
                if (txtDisplay.Text.Length == 0)
                {
                    txtDisplay.Clear();
                }
            }
        }

        private void Clear()
        {
            txtDisplay.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
            System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

        private void txtDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateExpression(txtDisplay.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void CalculateExpression(string expression)
        {
            var result = new DataTable().Compute(expression, null);
            txtDisplay.Text = result.ToString();
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {

            if (Regex.IsMatch(txtDisplay.Text, @"\p{L}"))
            {
                txtDisplay.Text = "";
                return;
            }
        }
    }
}
