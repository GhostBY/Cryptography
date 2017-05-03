using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        char[] str;
        readonly string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        string Hash(string t)
        {
            str = t.ToCharArray();
            t = "";
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (str[i] == alphabet[j])
                    {
                        t += (j + 1);
                    }
                }
            }
            str = t.ToCharArray(); //переход от символов к числовым значениям
            //++
            const double p = 17, q = 23;
            double n = p * q;// 391
            double h, h0 = 150;
            for (int i = 0; i < str.Length; i++)
            {
                t = Convert.ToString(str[i]);
                h = h0 + Convert.ToDouble(t);
                h0 = (Math.Pow(h, 2)) % n;
            }
            return Convert.ToString(h0);
        }  

        double g = 0;

        string Key(string t, TextBox text1, TextBox text2, TextBox text3, TextBox text4) {

            string h0 = Hash(t);
            //ключи
            double p2 = 367, q2 = 61, g, x = rnd.Next(0, (int)q2) /*закрытый*/, y, h = rnd.Next(1, (int)p2-1);
            g = Step((int)h,(int)((p2-1)/ q2),  (int)p2);
            y = Step((int)g, (int)x, (int) p2);//открытый

            //подпись
            this.g = g;
            //this.y = y;
            text1.Text = Convert.ToString(p2);
            text2.Text = Convert.ToString(q2);
            text3.Text = Convert.ToString(y);
            text4.Text = h0;
            return Podpis(Convert.ToDouble(text1.Text), Convert.ToDouble(text2.Text), Convert.ToDouble(text4.Text),x,g);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Proverka(Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox12.Text), Convert.ToDouble(textBox11.Text));
        }

        string Podpis(double p2, double q2, double h0, double x, double g)
        {
            double r, s, k0 = 0,
                k = rnd.Next(0, (int)q2);
            r = Step((int)g, (int)k, (int)p2) % q2;
            for (int i = 0; ; i++)
                if ((i * k % q2) == 1)
                {
                    k0 = i;
                    break;
                };
            s = (k0 * (h0 + x * r)) % q2;
            if (r == 0 || s == 0)
            {
                Podpis(q2, p2, h0, x, g);
                return "";
            }
            else
            {
                textBox3.Text = Convert.ToString(s);
                textBox4.Text = Convert.ToString(r);
                textBox11.Text = textBox7.Text;
                textBox12.Text = Convert.ToString(g);
                return " " + Convert.ToString(r) + ", " + Convert.ToString(s);

            }
        }

        string Proverka(double s, double r, double g, double y)
        {
            string h00 = Hash(textBox9.Text);
            textBox10.Text = h00;
            double k0 = 0, p = 367, q = 61, w, u1, u2;
            for (int i = 0; ; i++)
                if ((i * s % q) == 1)
                {
                    k0 = i;
                    break;
                };
            w = k0 % q;
            u1 = (Convert.ToDouble(h00) * w) % q;
            u2 = (r * w) % q;
            BigInteger g2 = BigInteger.Parse(Convert.ToString(g));
            //BigInteger u12 = BigInteger.Parse(Convert.ToString(u1));
            BigInteger y2 = BigInteger.Parse(Convert.ToString(y));
            //BigInteger u22 = BigInteger.Parse(Convert.ToString(u2));
            BigInteger num1 = BigInteger.Parse(Convert.ToString(BigInteger.Pow(g2, (int)u1)));
            BigInteger num2 = BigInteger.Parse(Convert.ToString(BigInteger.Pow(y2, (int)u2)));
            BigInteger num3 = BigInteger.Parse(Convert.ToString(q));
            BigInteger num4 = BigInteger.Parse(Convert.ToString(p));
            BigInteger mumO = num1 * num2;
            BigInteger v;
            BigInteger r2 = BigInteger.Parse(Convert.ToString(r));
            v = BigInteger.Parse(Convert.ToString(((num1* num2) % num4) % num3));
            if (r2 == v)
            {
                return "Подпись подлинная";
            }
            else return "Подпись не является подлинной";
        }

        double Step(int a, int z, int n)
        {
            int x = 1;
            while (z != 0)
            {
                while ((z % 2) == 0)
                {
                    z = z / 2;
                    a = (a * a) % n;
                }
                z = z - 1;
                x = (x * a) % n;
            }
            return x;     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label1.Text = textBox1.Text +"("+Key(textBox1.Text, textBox5, textBox6, textBox7, textBox8)+")";
            textBox9.Text = textBox1.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
