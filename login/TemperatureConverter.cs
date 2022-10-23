using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class TemperatureConverter : Form
    {
        public TemperatureConverter()
        {
            InitializeComponent();
        }

        private double Farenheit;
        private double Celsius;
        private double Kelvin;

        private double FarenheitToCelsius
        {
            get { return (Farenheit - 32) * 5 / 9; }
            set { Farenheit = value; }
        }

        private double FarenheitToKelvin
        {
            get { return (Farenheit - 32) * 5 / 9 + 273.15; }
            set { Farenheit = value; }
        }

        private double CelsiusToKelvin
        {
            get { return Celsius + 273.15; }
            set { Celsius = value; }
        }

        private double CelsiusToFarenheit
        {
            get { return (Celsius * 9 / 5) + 32; }
            set { Celsius = value; }
        }

        private double KelvinToCelsius
        {
            get { return Kelvin - 273.15; }
            set { Kelvin = value; }
        }

        private double KelvinToFarenheit
        {
            get { return (Kelvin - 273.15) * 9 / 5 + 32; }
            set { Kelvin = value; }
        }

        private void Converter()
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text == "-")
                {
                    textBox2.Text = "";
                }
                else if (comboBox1.Text == "Celsius to Farenheit")
                {
                    CelsiusToFarenheit = Convert.ToDouble(textBox1.Text);
                    textBox2.Text = CelsiusToFarenheit.ToString();
                }
                else if (comboBox1.Text == "Celsius to Kelvin")
                {
                    CelsiusToKelvin = Convert.ToDouble(textBox1.Text);
                    textBox2.Text = CelsiusToKelvin.ToString();
                }
                else if (comboBox1.Text == "Farenheit to Celsius")
                {
                    FarenheitToCelsius = Convert.ToDouble(textBox1.Text);
                    textBox2.Text = FarenheitToCelsius.ToString();
                }
                else if (comboBox1.Text == "Farenheit to Kelvin")
                {
                    FarenheitToKelvin = Convert.ToDouble(textBox1.Text);
                    textBox2.Text = FarenheitToKelvin.ToString();
                }

                else if (comboBox1.Text == "Kelvin to Celsius")
                {
                    KelvinToCelsius = Convert.ToDouble(textBox1.Text);
                    textBox2.Text = KelvinToCelsius.ToString();
                }
                else if (comboBox1.Text == "Kelvin to Farenheit")
                {
                    KelvinToFarenheit = Convert.ToDouble(textBox1.Text);
                    textBox2.Text = KelvinToFarenheit.ToString();
                }
            }
            catch { }
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Converter();
            ChangeLabel();
        }

        private void TemperatureConverter_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if ((ch == 46 && textBox1.Text.IndexOf(".") != -1) ||
                (ch == 45 && textBox1.Text.IndexOf("-") != -1) ||
                (ch == 45 && textBox1.Text.IndexOf(".") != -1) ||
                (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 45))
            {
                e.Handled = true;
                return;
            }
        }
        private void ChangeLabel()
        {
            switch (comboBox1.Text)
            {
                case "Farenheit to Celsius":
                    label1.Text = "Farenheit";
                    label2.Text = "Celsius";
                    break;
                case "Farenheit to Kelvin":
                    label1.Text = "Farenheit";
                    label2.Text = "Kelvin";
                    break;
                case "Celsius to Farenheit":
                    label1.Text = "Celsius";
                    label2.Text = "Farenheit";
                    break;
                case "Celsius to Kelvin":
                    label1.Text = "Celsius";
                    label2.Text = "Kelvin";
                    break;
                case "Kelvin to Farenheit":
                    label1.Text = "Kelvin";
                    label2.Text = "Farenheit";
                    break;
                case "Kelvin to Celsius":
                    label1.Text = "Kelvin";
                    label2.Text = "Celsius";
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Converter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 back = new Form1();
            back.Show();
        }
    }
}
