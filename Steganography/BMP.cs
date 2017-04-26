using System;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NET
{
    public partial class FormMain : Form
    {
        private void BmpWrite()
        {
            Color pixel; int x = 0;

            byte[] B = Encoding.GetEncoding(1251).GetBytes(TextBoxMsg.Text + '/');

            bool f = false;

            for (int i = 0; i < image.Width; i++)
            {
                if (f) break;

                for (int j = 0; j < image.Height; j++)
                {
                    pixel = image.GetPixel(i, j);

                    if (x == B.Length) { f = true; break; }

                    Bits m = new Bits(B[x++]);

                    while (m.Length != 8) m.Insert(0, 0);

                    Bits r = new Bits(pixel.R); while (r.Length != 8) r.Insert(0, 0);
                    Bits g = new Bits(pixel.G); while (g.Length != 8) g.Insert(0, 0);
                    Bits b = new Bits(pixel.B); while (b.Length != 8) b.Insert(0, 0);

                    r[6] = m[0];
                    r[7] = m[1];

                    g[5] = m[2];
                    g[6] = m[3];
                    g[7] = m[4];

                    b[5] = m[5];
                    b[6] = m[6];
                    b[7] = m[7];

                    image.SetPixel(i, j, Color.FromArgb(r.Number, g.Number, b.Number));
                }
            }

            if (!avi) image.Save(out_file);
        }

        private void BmpRead()
        {
            Color pixel;

            ArrayList array = new ArrayList();

            bool f = false;

            for (int i = 0; i < image.Width; i++)
            {
                if (f) break;

                for (int j = 0; j < image.Height; j++)
                {
                    pixel = image.GetPixel(i, j);

                    Bits m = new Bits(255);

                    Bits r = new Bits(pixel.R); while (r.Length != 8) r.Insert(0, 0);
                    Bits g = new Bits(pixel.G); while (g.Length != 8) g.Insert(0, 0);
                    Bits b = new Bits(pixel.B); while (b.Length != 8) b.Insert(0, 0);

                    m[0] = r[6];
                    m[1] = r[7];

                    m[2] = g[5];
                    m[3] = g[6];
                    m[4] = g[7];

                    m[5] = b[5];
                    m[6] = b[6];
                    m[7] = b[7];

                    if (m.Char == '/') { f = true; break; }

                    array.Add(m.Number);
                }
            }

            byte[] msg = new byte[array.Count];

            for (int i = 0; i < array.Count; i++)
                msg[i] = Convert.ToByte(array[i]);

            TextBoxMsg.Clear(); TextBoxMsg.Text = Encoding.GetEncoding(1251).GetString(msg);
        }
    }
}