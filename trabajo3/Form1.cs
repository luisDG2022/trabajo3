using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabajo3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        ErrorProvider errorProvider1 = new ErrorProvider();

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

                var textBox = sender as TextBox;
            try
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Tag = "No puede ser vacio";

                    errorProvider1.SetError(textBox, (string)textBox.Tag);
                    e.Cancel = true;
                }
                else
                {
                    if (textBox.Text == "0")
                    {
                        errorProvider1.SetError(textBox, "NO puedes iniciar con 0");
                        e.Cancel = true;
                    }
                    double.TryParse(textBox.Text, out double value);
                    Debug.Print(value.ToString());

                    if (value < 1)
                    {
                        errorProvider1.SetError(textBox, "NO puedes iniciar con menos a 1");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception a)
            {
                if (a.TargetSite.Name== "StringToNumber")
                {
                    
                    errorProvider1.SetError(textBox, "no se aceptan numeros con punto");
                    e.Cancel=true;
                }
            }
      
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {


            Regex exp = new Regex(@"^[0-9,]*$");
            if (exp.IsMatch(e.KeyChar.ToString()) || e.KeyChar == (char)Keys.Back

                || e.KeyChar == (char)Keys.Delete)
            {
            }
            else
            {
                textBox1.Tag = "Solo se aceptan numeros";
                // errorProvider1.SetError(textBox1, "solo numeros");
                e.Handled = true;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num1;
            double num2;
            double cambio;
            num1 =double.Parse( textBox1.Text);
            num2 =double.Parse( textBox2.Text);
            if (radioButton1.Checked)
            {
            cambio=num1 / num2;

            }
            else
            {
                cambio = num2* num1;
            }
            label3.Text = cambio.ToString();
           // cambio = double.Parse(label3.Text);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
