using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace PROYECTO_BASE_II.VENDEDOR
{
    public partial class PANTALLA_INICIAL_DE_ADMINISTRADOR : Form
    {
        String nombrecom = "";
        public PANTALLA_INICIAL_DE_ADMINISTRADOR()
        {
            InitializeComponent();
        }
        public static class util
        {
            public enum Effect { Roll, Slide, Center, Blend }
            public static void Animate(Control ctl, Effect effect, int msec, int angle)
            {
                int flags = effmap[(int)effect];
                if (ctl.Visible)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ESTAS SEGURO DE QUERER SALIR DE LA APLICACION?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        public void nombre(String f)
        {
            String no = "";
            for(int i=0;i<f.Length;i++)
            {
                if (f[i] == '\n')
                    break;
                else
                    no += f[i];
            }
            nombrecom = no;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            util.Animate(MENU, util.Effect.Center, 100, 180);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(0);
            OPCIONES.BUSQUEDA_DE_MEDICAMENTO mas = new OPCIONES.BUSQUEDA_DE_MEDICAMENTO();
            mas.toma(label1.Text);
            mas.TopLevel = false;
            mas.FormBorderStyle = FormBorderStyle.None;
            mas.Dock = DockStyle.Fill;
            panel1.Controls.Add(mas);
            panel1.Tag = mas;
            mas.Show();
        }

        private void PANTALLA_INICIAL_DE_ADMINISTRADOR_Load(object sender, EventArgs e)
        {
            SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("select o.CI,o.TIPO from todooooo o where o.NOM = '" + nombrecom+"'", conex);
            conex.Open();
            String tusa = "", TU = "";

            SqlDataReader lee = comando.ExecuteReader();
            while(lee.Read())
            {
                tusa = lee[0].ToString();
                TU = lee[1].ToString();
            }
            conex.Close();
            label1.Text = tusa +" - "+nombrecom+" - "+TU;
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(0);
            VENDEDOR.PRINCIPAL_VENDEDOR mas = new VENDEDOR.PRINCIPAL_VENDEDOR();
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

        private void button9_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(0);
            VENDEDOR.PRINCIPAL_VENDEDOR mas = new VENDEDOR.PRINCIPAL_VENDEDOR();
            mas.TopLevel = false;
            mas.FormBorderStyle = FormBorderStyle.None;
            mas.Dock = DockStyle.Fill;
            panel1.Controls.Add(mas);
            panel1.Tag = mas;
            mas.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(0);
            OPCIONES.REGISTTRO_DE_CLIENTES mas = new OPCIONES.REGISTTRO_DE_CLIENTES();
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
            OPCIONES.VENTA_DE_MEDICAMENTOS mas = new OPCIONES.VENTA_DE_MEDICAMENTOS();
            mas.toma(label1.Text);
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
            OPCIONES.VENDE_MED_OTRAS_FARM mas = new OPCIONES.VENDE_MED_OTRAS_FARM();
            mas.toma(label1.Text);
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
            OPCIONES.REVISION_VENTAS mas = new OPCIONES.REVISION_VENTAS();
            mas.toma(label1.Text);
            mas.TopLevel = false;
            mas.FormBorderStyle = FormBorderStyle.None;
            mas.Dock = DockStyle.Fill;
            panel1.Controls.Add(mas);
            panel1.Tag = mas;
            mas.Show();
        }
    }
}
