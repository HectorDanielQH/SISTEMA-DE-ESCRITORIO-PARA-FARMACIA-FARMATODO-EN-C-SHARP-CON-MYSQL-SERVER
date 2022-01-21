using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace PROYECTO_BASE_II
{
    public partial class Form1 : Form
    {
        String el_principal = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.02;
            if(this.Opacity==100.0)
            {
                timer1.Enabled = false;
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value==100)
            {
                timer2.Stop();
                this.Visible = false;
                CONTROLADOR_DE_USUARIOS.PRINCIPAL nuevo = new CONTROLADOR_DE_USUARIOS.PRINCIPAL();
                nuevo.ShowDialog();
            }
            else
            {
                label1.Text = "cargando..." + progressBar1.Value + "%";
                progressBar1.Value += 1;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Console.WriteLine(config.ConnectionStrings.ConnectionStrings["CONEXION"].ConnectionString);
            config.ConnectionStrings.ConnectionStrings["CONEXION"].ConnectionString = el_principal;
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Reload();
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            el_principal = ConfigurationManager.ConnectionStrings["CONEXION"].ToString();
        }
    }
}
