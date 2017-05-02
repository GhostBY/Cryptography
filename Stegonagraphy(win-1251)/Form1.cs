using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.IO;

namespace Word5
{
    public partial class Form1 : Form
    {
        public string ParthToWord { get; set; }
        public Form1()
        {
            InitializeComponent();
            ParthToWord = @"variant.rtf";
            richTextBox1.LoadFile(ParthToWord);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mystring = textBox1.Text;
            int k = 0;
            var encoding = new CodeBodo();
            encoding.GetList();
            for (int i = 0; i < mystring.Length; i++)//идем по тексту
            {
              
                for (int j = 0; j < encoding.myList.Count; j++)//ищем совпадения
                {
                    if (mystring[i].ToString() == encoding.myList[j].Simbol)//если найдены
                    {
                        for (int index = 0; index < encoding.myList[j].binaryCode.Length; index++)
                        {
                            if (encoding.myList[j].binaryCode[index].ToString() == '1'.ToString())
                            {
                                richTextBox1.SelectionStart = k;
                                richTextBox1.SelectionLength = 1;
                                richTextBox1.SelectionFont = new System.Drawing.Font("Segoe Print", 20,FontStyle.Bold);
                            }
                            ++k;
                        }
                    }
                }
            }
            MessageBox.Show("OK","Success!");
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string rezult = string.Empty;
            for (int i = 0; i < richTextBox1.Text.Length; i++)
            {
                richTextBox1.SelectionStart = i;
                richTextBox1.SelectionLength = 1;
                if (richTextBox1.SelectionColor != Color.Black)
                {
                    rezult += richTextBox1.Text[i];
                }
               
            }
            if(!string.IsNullOrWhiteSpace(rezult))
              MessageBox.Show(rezult,"Encryption result");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < richTextBox1.Text.Length; i++)
            {
                richTextBox1.SelectionStart = i;
                richTextBox1.SelectionLength = 1;
                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.SelectionFont = new System.Drawing.Font("Segoe Print", 12);
            }
            MessageBox.Show("Cleared!");
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.SaveFile(ParthToWord);
            MessageBox.Show("File saved!");
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
