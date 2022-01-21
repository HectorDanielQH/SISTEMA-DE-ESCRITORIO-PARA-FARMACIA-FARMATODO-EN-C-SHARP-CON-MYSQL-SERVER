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
using System.Data.SqlClient;

namespace PROYECTO_BASE_II.CONTROLADOR_DE_USUARIOS
{
    public partial class PRINCIPAL : Form
    {
        String el_principal = ConfigurationManager.ConnectionStrings["CONEXION"].ToString();
        public PRINCIPAL()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if(!textBox2.UseSystemPasswordChar)
            {
                button3.ImageIndex = 41;
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                button3.ImageIndex = 40;
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ESTAS SEGURO DE QUERER SALIR DE LA APLICACION?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                System.Console.WriteLine(config.ConnectionStrings.ConnectionStrings["CONEXION"].ConnectionString);
                config.ConnectionStrings.ConnectionStrings["CONEXION"].ConnectionString = el_principal;
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");
                Properties.Settings.Default.Reload();
                Application.Exit();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Configuration configg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Console.WriteLine(configg.ConnectionStrings.ConnectionStrings["CONEXION"].ConnectionString);
            configg.ConnectionStrings.ConnectionStrings["CONEXION"].ConnectionString = el_principal;
            configg.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Reload();
            String conexion = ConfigurationManager.ConnectionStrings["CONEXION"].ToString();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Console.WriteLine(config.ConnectionStrings.ConnectionStrings["CONEXION"].ConnectionString);
            config.ConnectionStrings.ConnectionStrings["CONEXION"].ConnectionString = conexion.Replace("*",textBox1.Text);
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Reload();
            conexion = ConfigurationManager.ConnectionStrings["CONEXION"].ToString();
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Console.WriteLine(config1.ConnectionStrings.ConnectionStrings["CONEXION"].ConnectionString);
            config1.ConnectionStrings.ConnectionStrings["CONEXION"].ConnectionString = conexion.Replace("#", textBox2.Text);
            config1.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Reload();
            conexion = ConfigurationManager.ConnectionStrings["CONEXION"].ToString();
            SqlConnection con = new SqlConnection(conexion);
            try
            { 
                con.Open();
                CONTROLADOR_DE_USUARIOS.PRINCIPAL_BIENVENIDA nuev = new CONTROLADOR_DE_USUARIOS.PRINCIPAL_BIENVENIDA();
                nuev.id(textBox2.Text);
                this.Visible = false;
                nuev.ShowDialog();
            }
            catch
            {
                con.Close();
                MessageBox.Show("LA CONTRASEÑA O EL ID ESTA MAL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void PRINCIPAL_Load(object sender, EventArgs e)
        {

        }
    }
}
