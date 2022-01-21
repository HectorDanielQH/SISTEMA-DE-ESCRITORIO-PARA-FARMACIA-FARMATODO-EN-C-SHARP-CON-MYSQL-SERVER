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
    public partial class PRINCIPAL_BIENVENIDA : Form
    {
        public String ID = "", tipo = "";
        int que = 0;
        public PRINCIPAL_BIENVENIDA()
        {
            InitializeComponent();
        }
        public void id(String x)
        {
            ID = x;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value==100)
            {
                timer1.Stop();
                timer1.Enabled = false;
                if (que == 1)
                {
                    ADMINISTRADOR.INICIO_ADMINISTRADOR admi = new ADMINISTRADOR.INICIO_ADMINISTRADOR();
                    this.Visible = false;
                    admi.ShowDialog();
                }
                else
                {
                    if(que==2)
                    {
                        VENDEDOR.PANTALLA_INICIAL_DE_ADMINISTRADOR inicial_administracion = new VENDEDOR.PANTALLA_INICIAL_DE_ADMINISTRADOR();
                        this.Visible = false;
                        inicial_administracion.nombre(label2.Text);
                        inicial_administracion.ShowDialog();
                    }
                }
            }
            else
            {
                progressBar1.Value += 1;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PRINCIPAL_BIENVENIDA_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                int identi = 3;
                SqlCommand com = new SqlCommand("select dbo.detecta_admi_o_vende_ventana('" + ID + "')", con);
                com.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader re = com.ExecuteReader();
                while (re.Read())
                {
                    identi = int.Parse(re[0].ToString());
                }
                con.Close();
                if (identi == 0)
                {
                    //ADMINISTRADOR
                    SqlCommand com1 = new SqlCommand("select dbo.detecta_admi_o_vende('" + ID + "')", con);
                    com1.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader re1 = com1.ExecuteReader();
                    while (re1.Read())
                    {
                        tipo = re1[0].ToString();
                    }
                    con.Close();
                    tipo += "\n ADMINISTRADOR";
                    label2.Text = tipo;
                    que = 1;
                }
                else
                {
                    //VENDEDOR
                    SqlCommand com2 = new SqlCommand("select dbo.detecta_admi_o_vende('" + ID + "')", con);
                    com2.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader re1 = com2.ExecuteReader();
                    while (re1.Read())
                    {
                        tipo = re1[0].ToString();
                    }
                    con.Close();
                    tipo += "\n USUARIO";
                    label2.Text = tipo;
                    que = 2;
                }
            }
            catch(Exception RR)
            {
                MessageBox.Show("OCURRIO UN ERROR: " + RR.Message);
            }
        }
    }
}
