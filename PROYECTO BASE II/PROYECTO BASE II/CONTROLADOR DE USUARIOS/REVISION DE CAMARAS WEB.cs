using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;

namespace PROYECTO_BASE_II.CONTROLADOR_DE_USUARIOS
{
    public partial class REVISION_DE_CAMARAS_WEB : Form
    {
        private FilterInfoCollection Captura_dispositivos_de_video;
        private VideoCaptureDevice FinalVideo;
        int wee = 0;
        public REVISION_DE_CAMARAS_WEB()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FinalVideo.IsRunning == true)
                FinalVideo.Stop();
            FinalVideo = new VideoCaptureDevice(Captura_dispositivos_de_video[comboBox1.SelectedIndex].MonikerString);
            FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
            FinalVideo.Start();
        }
        void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap video = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = video;
        }
        public void salir()
        {
            FinalVideo.Stop();
        }
        private void REVISION_DE_CAMARAS_WEB_Load(object sender, EventArgs e)
        {
            Captura_dispositivos_de_video = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Captura_dispositio in Captura_dispositivos_de_video)
            {
                comboBox1.Items.Add(Captura_dispositio.Name);
            }
            comboBox1.SelectedIndex = 0;
            FinalVideo = new VideoCaptureDevice();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            Captura_dispositivos_de_video = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Captura_dispositio in Captura_dispositivos_de_video)
            {
                comboBox1.Items.Add(Captura_dispositio.Name);
            }
            comboBox1.SelectedIndex = 0;
            FinalVideo = new VideoCaptureDevice();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void REVISION_DE_CAMARAS_WEB_ControlRemoved(object sender, ControlEventArgs e)
        {

        }
        private void REVISION_DE_CAMARAS_WEB_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void REVISION_DE_CAMARAS_WEB_Activated(object sender, EventArgs e)
        {
        }

        private void REVISION_DE_CAMARAS_WEB_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void REVISION_DE_CAMARAS_WEB_MouseLeave(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FinalVideo.Stop();
        }
    }
}
