using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Калькулятор_2
{
    public partial class Form1 : Form
    {

        Calc C;

        int k;
 

        const string name = "Калькулятор";

public bool SetAutorunValue(bool autorun)
{
    string ExePath = System.Windows.Forms.Application.ExecutablePath;
    RegistryKey reg;
    reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
    try
    {
        if (autorun)
            reg.SetValue(name, ExePath);
        else
            reg.DeleteValue(name);
 
        reg.Close();
    }
    catch
    {
        return false;
    }
    return true;
}

        public Form1()
        {
            InitializeComponent();

            C = new Calc();

            textBox1.Text = "0";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";

            C.Clear_A();


            k = 0;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[0] == '-')
                textBox1.Text = textBox1.Text.Remove(0, 1);
            else
                textBox1.Text = "-" + textBox1.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.IndexOf(",") == -1) && (textBox1.Text.IndexOf("∞") == -1))
                textBox1.Text += ",";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";

            CorrectNumber();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";

            CorrectNumber();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";

            CorrectNumber();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";

            CorrectNumber();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";

            CorrectNumber();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";

            CorrectNumber();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";

            CorrectNumber();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";

            CorrectNumber();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";

            CorrectNumber();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";

            CorrectNumber();
        }
        private void CorrectNumber()
        {
            if (textBox1.Text.IndexOf("Грубая ошибка неуч !!! Число должно быть >= 0 и целым!") != -1)
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
           


           
            
            if (textBox1.Text.IndexOf("∞") != -1)
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
           
           
            if (textBox1.Text[0] == '0' && (textBox1.Text.IndexOf(",") != 1))
                textBox1.Text = textBox1.Text.Remove(0, 1);

            
            if (textBox1.Text[0] == '-')
                if (textBox1.Text[1] == '0' && (textBox1.Text.IndexOf(",") != 2))
                    textBox1.Text = textBox1.Text.Remove(1, 1);
        }

        private void button18_Click(object sender, EventArgs e)
        {
           
            if (!button14.Enabled)
                textBox1.Text = C.Multiplication(Convert.ToDouble(textBox1.Text)).ToString();

            if (!button15.Enabled)
                textBox1.Text = C.Division(Convert.ToDouble(textBox1.Text)).ToString();

            if (!button17.Enabled)
                textBox1.Text = C.Sum(Convert.ToDouble(textBox1.Text)).ToString();

            if (!button16.Enabled)
                textBox1.Text = C.Subtraction(Convert.ToDouble(textBox1.Text)).ToString();

            if (!button23.Enabled)
                textBox1.Text = C.Integerdivision(Convert.ToDouble(textBox1.Text)).ToString();

           

                  


            C.Clear_A();
            FreeButtons();

            k = 0;


        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(textBox1.Text));

                button14.Enabled = false;

                textBox1.Text = "0";
            }


        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(textBox1.Text));

                button15.Enabled = false;

                textBox1.Text = "0";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(textBox1.Text));

                button17.Enabled = false;

                textBox1.Text = "0";
            }
        }


        private void button16_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(textBox1.Text));

                button16.Enabled = false;

                textBox1.Text = "0";
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {

            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(textBox1.Text));

                textBox1.Text = C.Sqrt().ToString();

                C.Clear_A();
                FreeButtons();
            }
        }



    
        private void button19_Click(object sender, EventArgs e)
        {

            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(textBox1.Text));

                textBox1.Text = C.Square().ToString();

                C.Clear_A();
                FreeButtons();



            }


        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                if ((Convert.ToDouble(textBox1.Text) == (int)(Convert.ToDouble(textBox1.Text))) &&
                    ((Convert.ToDouble(textBox1.Text) >= 0.0)))
                {
                    C.Put_A(Convert.ToDouble(textBox1.Text));

                    textBox1.Text = C.Factorial().ToString();

                    C.Clear_A();
                    FreeButtons();
                }
                else
                    textBox1.Text = "Грубая ошибка неуч !!! Число должно быть >= 0 и целым!";

            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            C.M_Sum(Convert.ToDouble(textBox1.Text));
        }

        private void button28_Click(object sender, EventArgs e)
        {
            C.M_Subtraction(Convert.ToDouble(textBox1.Text));
        }

        private void button30_Click(object sender, EventArgs e)
        {
            C.M_Multiplication(Convert.ToDouble(textBox1.Text));
        }

        private void button33_Click(object sender, EventArgs e)
        {
            C.M_Division(Convert.ToDouble(textBox1.Text));
        }

      


        private void button34_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                k++;

                if (k == 1)
                    textBox1.Text = C.MemoryShow().ToString();

                if (k == 2)
                {
                    C.Memory_Clear();
                    textBox1.Text = "0";

                    k = 0;
                }
            }
        }

        private bool CanPress()
        {
            if (!button14.Enabled)
                return false;

            if (!button15.Enabled)
                return false;

            if (!button17.Enabled)
                return false;

            if (!button16.Enabled)
                return false;


            if (!button23.Enabled)
                return false;



            return true;
        }

        private void FreeButtons()
        {
            button14.Enabled = true;
            button15.Enabled = true;
            button17.Enabled = true;
            button16.Enabled = true;
            
            button23.Enabled = true;
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
            {
                textBox1.Text = textBox1.Text + text[i];
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(textBox1.Text));

                button23.Enabled = false;

                textBox1.Text = "0";
            }
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 AB = new AboutBox1();
            AB.Show();

        }


        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SetAutorunValue(true);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            SetAutorunValue(false);
        }

       

       
        }
    }

