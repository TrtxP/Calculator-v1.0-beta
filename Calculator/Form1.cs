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

        bool isClearing = false;
        bool suppressError = false;

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

        private void button1_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += ".";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "+";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "-";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += ":";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "*";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out num) && num != 0)
                txtDisplay.Text = (Math.Sqrt(num)).ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "%";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out num))
            {
                num = -num;
                txtDisplay.Text = num.ToString();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out num) && num != 0)
            {
                txtDisplay.Text = (1 / num).ToString();
            }
            else
            {
                txtDisplay.Text = "Cannot divided by zero";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            CalculateExpression(txtDisplay.Text);
        }

        private void button21_Click(object sender, EventArgs e)
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

        private void button19_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
        }

        private void Sqrt()
        {
            if (double.TryParse(txtDisplay.Text, out num) && num != 0)
                txtDisplay.Text = (Math.Sqrt(num)).ToString();
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
                    txtDisplay.Text = "Cannot divide by zero";
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
            //try
            //{
            //    if (Regex.IsMatch(expression, @"/\s*0+(\.0+)?\s*(?!\d)"))
            //    {
            //        txtDisplay.Text = "Cannot divide by zero";
            //        return;
            //    }
            //    var result = new DataTable().Compute(expression, null);
            //    txtDisplay.Text = result.ToString();
            //}
            //catch (Exception)
            //{
            //    txtDisplay.Text = "Error";
            //}
            var result = new DataTable().Compute(expression, null);
            txtDisplay.Text = result.ToString();
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {
            if (isClearing || suppressError) return;

            if (Regex.IsMatch(txtDisplay.Text, @"\p{L}"))
            {
                suppressError = true;
                txtDisplay.Text = "";
                MessageBox.Show("Enter the correct number value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                suppressError = false;
            }
        }
    }
}
