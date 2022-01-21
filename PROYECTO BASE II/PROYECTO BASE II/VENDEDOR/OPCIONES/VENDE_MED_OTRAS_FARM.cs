using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace PROYECTO_BASE_II.VENDEDOR.OPCIONES
{
    public partial class VENDE_MED_OTRAS_FARM : Form
    {
        String CI_VENDE = "";
        public VENDE_MED_OTRAS_FARM()
        {
            InitializeComponent();
        }

        public void toma(String v)
        {
            String f = "";
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] == ' ')
                    break;
                else
                    f += v[i];
            }
            CI_VENDE = f;
        }
        private void VENDE_MED_OTRAS_FARM_Load(object sender, EventArgs e)
        {
            SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("bus_por_far", cone);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@ci",SqlDbType.VarChar,15);
            comando.Parameters.Add("@descrip", SqlDbType.VarChar, 500);
            comando.Parameters[0].Value = CI_VENDE;
            comando.Parameters[1].Value = textBox1.Text;
            DataSet datos = new DataSet();
            SqlDataAdapter adpa = new SqlDataAdapter(comando);
            adpa.Fill(datos);
            bindingSource1.DataSource = datos.Tables[0];
            farma.DataBindings.Add("Text",bindingSource1,"NOMBRE");
            ubica.DataBindings.Add("Text", bindingSource1, "UBICACION");
            des_pro.DataBindings.Add("Text", bindingSource1, "DESCRIPCION");
            canti.DataBindings.Add("Text", bindingSource1, "CANTIDAD");
            ruta.DataBindings.Add("Text", bindingSource1, "RUTA");
            dataGridView1.DataSource = bindingSource1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveFirst();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveLast();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = ruta.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("bus_por_far", cone);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@ci", SqlDbType.VarChar, 15);
            comando.Parameters.Add("@descrip", SqlDbType.VarChar, 500);
            comando.Parameters[0].Value = CI_VENDE;
            comando.Parameters[1].Value = textBox1.Text;
            DataSet datos = new DataSet();
            SqlDataAdapter adpa = new SqlDataAdapter(comando);
            adpa.Fill(datos);
            bindingSource1.DataSource = datos.Tables[0];
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
