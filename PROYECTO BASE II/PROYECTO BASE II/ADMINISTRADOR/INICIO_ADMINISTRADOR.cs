using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace PROYECTO_BASE_II.ADMINISTRADOR
{
    public partial class INICIO_ADMINISTRADOR : Form
    {
        CONTROLADOR_DE_USUARIOS.REVISION_DE_CAMARAS_WEB mas1;
        private VideoCaptureDevice FinalVideo;
        public INICIO_ADMINISTRADOR()
        {
            InitializeComponent();
        }

        public static class util
        {
            public enum Effect {Roll,Slide,Center,Blend}
            public static void Animate(Control ctl, Effect effect, int msec, int angle)
            {
                int flags = effmap[(int)effect];
                if(ctl.Visible)
                {
                    flags |= 0x10000;
                    angle += 180;
                }
                else
                {
                    if (ctl.TopLevelControl == ctl)
                        flags |= 0x20000;
                    else
                        if (effect == Effect.Blend)
                        throw new ArgumentException();
                }
                flags |= dirmap[angle % 360 / 180];
                bool ok = AnimateWindow(ctl.Handle, msec, flags);
                if (!ok)
                    throw new Exception("ANIMACION FALLIDA");
                ctl.Visible = !ctl.Visible;
            }
        }
        private static int[] dirmap = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };

        [DllImport("user32.dll")]

        private static extern bool AnimateWindow(IntPtr handle, int msec, int flags);

        private void INICIO_ADMINISTRADOR_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("ESTAS SEGURO DE QUERER SALIR DE LA APLICACION?","SALIR",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void INICIO_ADMINISTRADOR_Load(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(0);
            MASCARA_PRINCIPAL mas = new MASCARA_PRINCIPAL();
            mas.TopLevel = false;
            mas.FormBorderStyle = FormBorderStyle.None;
            mas.Dock = DockStyle.Fill;
            panel1.Controls.Add(mas);
            panel1.Tag=mas;
            mas.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            util.Animate(MENU,util.Effect.Center,100,180);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(0);
            ADMINISTRADOR.SUB_ELEMENTOS.NUEVO_USUARIO mas = new ADMINISTRADOR.SUB_ELEMENTOS.NUEVO_USUARIO();
            mas.TopLevel = false;
            mas.FormBorderStyle = FormBorderStyle.None;
            mas.Dock = DockStyle.Fill;
            panel1.Controls.Add(mas);
            panel1.Tag = mas;
            mas.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FinalVideo = new VideoCaptureDevice();
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.Clear();
            }
            if (FinalVideo.IsRunning == true)
                FinalVideo.Stop();
            MASCARA_PRINCIPAL mas = new MASCARA_PRINCIPAL();
            mas.TopLevel = false;
            mas.FormBorderStyle = FormBorderStyle.None;
            mas.Dock = DockStyle.Fill;
            panel1.Controls.Add(mas);
            panel1.Tag = mas;
            mas.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Process.Start("https://sfv.impuestos.gob.bo/");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FinalVideo = new VideoCaptureDevice();
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.Clear();
            }
            if (FinalVideo.IsRunning == true)
                FinalVideo.Stop();
            mas1 = new CONTROLADOR_DE_USUARIOS.REVISION_DE_CAMARAS_WEB();
            mas1.TopLevel = false;
            mas1.FormBorderStyle = FormBorderStyle.None;
            mas1.Dock = DockStyle.Fill;
            panel1.Controls.Add(mas1);
            panel1.Tag = mas1;
            mas1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(0);
            ADMINISTRADOR.SUB_ELEMENTOS.NUEVA_FARMACIA mas = new ADMINISTRADOR.SUB_ELEMENTOS.NUEVA_FARMACIA();
            mas.TopLevel = false;
            mas.FormBorderStyle = FormBorderStyle.None;
            mas.Dock = DockStyle.Fill;
            panel1.Controls.Add(mas);
            panel1.Tag = mas;
            mas.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(0);
            ADMINISTRADOR.SUB_ELEMENTOS.MEDICAMENTOS mas = new ADMINISTRADOR.SUB_ELEMENTOS.MEDICAMENTOS();
            mas.TopLevel = false;
            mas.FormBorderStyle = FormBorderStyle.None;
            mas.Dock = DockStyle.Fill;
            panel1.Controls.Add(mas);
            panel1.Tag = mas;
            mas.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(0);
            ADMINISTRADOR.SUB_ELEMENTOS.INVENTARIO mas = new ADMINISTRADOR.SUB_ELEMENTOS.INVENTARIO();
            mas.TopLevel = false;
            mas.FormBorderStyle = FormBorderStyle.None;
            mas.Dock = DockStyle.Fill;
            panel1.Controls.Add(mas);
            panel1.Tag = mas;
            mas.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(0);
            ADMINISTRADOR.SUB_ELEMENTOS.ELEMENTO_ELIMINADO mas = new ADMINISTRADOR.SUB_ELEMENTOS.ELEMENTO_ELIMINADO();
            mas.TopLevel = false;
            mas.FormBorderStyle = FormBorderStyle.None;
            mas.Dock = DockStyle.Fill;
            panel1.Controls.Add(mas);
            panel1.Tag = mas;
            mas.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(0);
            ADMINISTRADOR.SUB_ELEMENTOS.CONTROL_INGRESOS mas = new ADMINISTRADOR.SUB_ELEMENTOS.CONTROL_INGRESOS();
            mas.TopLevel = false;
            mas.FormBorderStyle = FormBorderStyle.None;
            mas.Dock = DockStyle.Fill;
            panel1.Controls.Add(mas);
            panel1.Tag = mas;
            mas.Show();
        }
    }
}
