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
    public partial class BUSQUEDA_DE_MEDICAMENTO : Form
    {
        String ci_vend = "";
        public BUSQUEDA_DE_MEDICAMENTO()
        {
            InitializeComponent();
        }

        private void RUTA_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = RUTA.Text;
        }
        public void toma(String x)
        {
            String conte = "";
            for(int i=0;i<x.Length;i++)
            {
                if (x[i] == ' ')
                    break;
                else
                    conte += x[i];
            }
            ci_vend = conte;
        }
        private void BUSQUEDA_DE_MEDICAMENTO_Load(object sender, EventArgs e)
        {
            SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("todo_busqueda_medi_pro", cone);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@ci",SqlDbType.VarChar,10);
            comando.Parameters[0].Value = ci_vend;
            DataSet datos = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(comando);
            adp.Fill(datos);
            bindingSource1.DataSource = datos.Tables[0];
            cod_pro.DataBindings.Add("Text",bindingSource1,"COD");
            des_pro.DataBindings.Add("Text", bindingSource1, "DESCRIPCION");
            FECHA_VEN.DataBindings.Add("Text", bindingSource1, "FECHA DE VENCIMIENTO");
            FECHA_ELA.DataBindings.Add("Text", bindingSource1, "FECHA DE ELABORACION");
            cantu.DataBindings.Add("Text", bindingSource1, "CANTIDAD");
            PRECIO.DataBindings.Add("Text", bindingSource1, "PRECIO VENTA");
            RUTA.DataBindings.Add("Text", bindingSource1, "RUTA");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("bus_por_des", cone);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@ci", SqlDbType.VarChar, 10);
            comando.Parameters.Add("@to", SqlDbType.VarChar, 500);
            comando.Parameters[0].Value = ci_vend;
            comando.Parameters[1].Value = bus.Text;
            DataSet datos = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(comando);
            adp.Fill(datos);
            bindingSource1.DataSource = datos.Tables[0];
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
