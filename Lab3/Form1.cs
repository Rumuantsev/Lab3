using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Differentiation;
using System.Net;
using MathNet.Numerics.Differentiation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MathNet.Numerics.Optimization;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab3
{
    public partial class Form1 : Form
    {
        double Fun(double x)
        {
            try
            {          
            org.matheval.Expression expression = new org.matheval.Expression(InputFunc.Text.ToLower());
            expression.Bind("x", x);
            decimal value = expression.Eval<decimal>();
            return (double)value;
            }
            catch
            {
                MessageBox.Show("Заполните все поля ввода!");
                return 0;
            }
        }

        double DerivativeFun(double x)
        {
            double h = 0.01;
            return (Fun(x + h) - Fun(x - h)) / (2 * h);
        }


        private double Newton(double a, double b, double accuracy)
        {

            double x0;

            x0 = (a + b) / 2;

            double x1 = x0;

            do
            {
                x0 = x1;
                x1 = x0 - (Fun(x0) / DerivativeFun(x0));
            } while (Math.Abs(Fun(x0) / DerivativeFun(x0)) >= accuracy);

            return x1;

        }
        public void GoldenSectionSearchMin(double a, double b, double accuracy)
        {


            double phi = (1 + Math.Sqrt(5)) / 2;
            double h = b - a;
            double c = b - h / phi;
            double d = a + h / phi;
            double fc = Fun(c);
            double fd = Fun(d);

            while (Math.Abs(fc - fd) > accuracy)
            {
                if (fc < fd)
                {
                    b = d;
                    d = c;
                    c = b - (b - a) / phi;
                    fd = fc;
                    fc = Fun(c);
                }
                else
                {
                    a = c;
                    c = d;
                    d = a + (b - a) / phi;
                    fc = fd;
                    fd = Fun(d);
                }
            }

            double result = (a + b) / 2;
            if ((Fun(result + 1) > Fun(result)) & ((Fun(result - 1) > Fun(result))))
            {
                GoldenMin.Text = Convert.ToString(result);
            }
            else
            {
                GoldenMin.Text = "Нет экстремума";
            }
        }
        public void GoldenSectionSearchMax(double a, double b, double accuracy)
        {


            double phi = (1 + Math.Sqrt(5)) / 2;
            double h = b - a;
            double c = b - h / phi;
            double d = a + h / phi;
            double fc = -Fun(c);
            double fd = -Fun(d);

            while (Math.Abs(fc - fd) > accuracy)
            {
                if (fc < fd)
                {
                    b = d;
                    d = c;
                    c = b - (b - a) / phi;
                    fd = fc;
                    fc = -Fun(c);
                }
                else
                {
                    a = c;
                    c = d;
                    d = a + (b - a) / phi;
                    fc = fd;
                    fd = -Fun(d);
                }
            }

            double result = (a + b) / 2;
            if ((Fun(result + 2) < Fun(result)) & ((Fun(result - 2) < Fun(result))))
            {
                GoldenMax.Text = Convert.ToString(result);
            }
            else
            {
                GoldenMax.Text = "Нет экстремума";
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        
        private void clearButton_Click(object sender, EventArgs e)
        {
            textBoxA.Clear();
            textBoxB.Clear();
            textBoxE.Clear();
            GoldenMax.Clear();
            //ResultY.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputFunc.Text = "(27 - 18 * x + 2 * x ^ 2) * e ^ -(x / 3)";
        }
        private void calculateButton_Click(object sender, EventArgs e)
        {
            double startChart = double.Parse(textBoxA.Text);
            double finishChart = double.Parse(textBoxB.Text);
            double step = 0.1, x, y;
            this.chart1.Series[0].Points.Clear();
            x = startChart;
            while (x <= finishChart)
            {
                y = Fun(x);
                this.chart1.Series[0].Points.AddXY(x, y);
                x += step;
            }

            try
            {
                if ((textBoxA.Text == String.Empty) | (textBoxB.Text == String.Empty) | (textBoxE.Text == String.Empty))
                {
                    MessageBox.Show("Заполните все поля ввода!");
                }
                else
                {
                    double A = double.Parse(textBoxA.Text);
                    double B = double.Parse(textBoxB.Text);
                    double E = double.Parse(textBoxE.Text);
                    double NX = Newton(A, B, E);
                    double NY = Fun(NX);
                    NewtonX.Text = Convert.ToString(NX);
                    GoldenSectionSearchMin(A, B, E);
                    GoldenSectionSearchMax(A, B, E);
                    //NewtonY.Text = Convert.ToString(NY);
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Можно вводить только цифры!");
            }          
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
