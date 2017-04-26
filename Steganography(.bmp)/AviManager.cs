using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganography_.bmp_
{
    public class AviManager
    {
        private int aviFile = 0;
        private ArrayList streams = new ArrayList();

        public AviManager(String fileName, bool open)
        {
            Avi.AVIFileInit();
            int result;

            if (open)
            {
                result = Avi.AVIFileOpen(ref aviFile, fileName, Avi.OF_READWRITE, 0);

            }
            else
            {
                result = Avi.AVIFileOpen(ref aviFile, fileName, Avi.OF_WRITE | Avi.OF_CREATE, 0);

            }

            if (result != 0)
            {
                MessageBox.Show("Неподходящий avi-файл!", "Ошибка");
                throw new Exception("");
            }
        }

        private AviManager(int aviFile)
        {
            this.aviFile = aviFile;
        }

    


     

        public void Close()
        {
            foreach (AviStream stream in streams)
            {
                stream.Close();
            }

            Avi.AVIFileRelease(aviFile);
            Avi.AVIFileExit();
        }

        public static void MakeFileFromStream(String fileName, AviStream stream)
        {
            IntPtr newFile = IntPtr.Zero;
            IntPtr streamPointer = stream.StreamPointer;

            Avi.AVICOMPRESSOPTIONS_CLASS opts = new Avi.AVICOMPRESSOPTIONS_CLASS();
            opts.fccType = (uint)Avi.streamtypeVIDEO;
            opts.lpParms = IntPtr.Zero;
            opts.lpFormat = IntPtr.Zero;
            Avi.AVISaveOptions(IntPtr.Zero, Avi.ICMF_CHOOSE_KEYFRAME | Avi.ICMF_CHOOSE_DATARATE, 1, ref streamPointer, ref opts);
            Avi.AVISaveOptionsFree(1, ref opts);

            Avi.AVISaveV(fileName, 0, 0, 1, ref streamPointer, ref opts);
        }
    }
}
