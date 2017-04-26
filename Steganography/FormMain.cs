using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace NET
{
    public partial class FormMain : Form
    {
        private Bitmap image = null;
        private string out_file = "";
        private bool avi = false;
        private string avifile = "";
        EditableVideoStream editableStream;

        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "Растровые изображения (*.bmp)|*.bmp|Видео-файлы(*.avi)|*.avi|Все файлы(*.*)|*.*";
            OpenFileDialog.FileName = "";

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (OpenFileDialog.FileName == "") return;

                string filetype = OpenFileDialog.FileName.Substring(OpenFileDialog.FileName.Length - 3);

                if (filetype.Equals("bmp"))
                {
                    avi = false;

                    image = (Bitmap)Image.FromFile(OpenFileDialog.FileName);

                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("Неподходящий bmp-файл!", "Ошибка");
                        image = null; return;
                    }

                    

                    out_file = OpenFileDialog.FileName.Insert(OpenFileDialog.FileName.Length - 4, "1");
                }
                else if (filetype.Equals("avi"))
                {
                    avi = true;

                    AviManager mainFile = new AviManager(OpenFileDialog.FileName, true);
                    VideoStream stream = mainFile.GetVideoStream();

                    stream.GetFrameOpen();
                    image = stream.GetBitmap(0);
                    stream.GetFrameClose();

                    editableStream = new EditableVideoStream(stream);
                    mainFile.Close();

                    if (image == null)
                    {
                        MessageBox.Show("Ошибка получения битмапа из avi", "Ошибка"); return;
                    }

                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("Неподходящий bmp-файл!", "Ошибка"); return;
                    }

                  
                    avifile = OpenFileDialog.FileName;
                }   
            }
        }

        private void RadioButtonEncode_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonEncode.Checked == true)
            {
                
                GroupBoxText.Text         = "Текст для шифрования";
                ButtonProcess.Text        = "Зашифровать";
            }
            else
            {
               
                GroupBoxText.Text         = "Расшифрованный текст";
                ButtonProcess.Text        = "Расшифровать";
            }

            TextBoxMsg.Clear();
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            FormAbout about = new FormAbout();
            about.ShowDialog();
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonProcess_Click(object sender, EventArgs e)
        {
            if (image == null) return;

            if (!avi)
            {
                if (RadioButtonEncode.Checked) BmpWrite();
                else BmpRead();
            }
            else
            {
                if (RadioButtonEncode.Checked)
                {
                    BmpWrite();

                    AviManager tempFile = new AviManager("C:\\temp.avi", false);
                    tempFile.AddVideoStream(false, 1, image);
                    VideoStream stream = tempFile.GetVideoStream();

                    editableStream.Paste(stream, 0, 0, stream.CountFrames);

                    tempFile.Close();

                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.Filter = "Видео-файлы (*.avi)|*.avi;";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        AviManager.MakeFileFromStream(dlg.FileName, editableStream);
                        editableStream.Close();
                        editableStream = null;
                    }

                    try { File.Delete("C:\\temp.avi"); }
                    catch (IOException) { }
                }
                else
                {
                    if (image == null)
                    {
                        MessageBox.Show("Ошибка доступа к avi-файлу!", "Ошибка"); return;
                    }

                    BmpRead();
                }
            }
        }

        private void ButtonOpenTxtFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            OpenFileDialog.FileName = "";

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (OpenFileDialog.FileName == "") return;

                StreamReader sr = new StreamReader(OpenFileDialog.FileName, Encoding.GetEncoding(1251));

                TextBoxMsg.Clear();
                TextBoxMsg.Text = sr.ReadToEnd();

                sr.Close();
            }
        }

        private void ButtonSaveAs_Click(object sender, EventArgs e)
        {

        }
    }
}