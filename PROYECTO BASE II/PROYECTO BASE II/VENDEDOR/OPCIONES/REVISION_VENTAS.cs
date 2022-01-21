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
    public partial class REVISION_VENTAS : Form
    {
        String CI_VENDE;
        public REVISION_VENTAS()
        {
            InitializeComponent();
        }
        public void toma(String x)
        {
            String d = "";
            for(int i=0;i<x.Length;i++)
            {
                if (x[i] == ' ')
                    break;
                else
                {
                    d += x[i];
                }
            }
            CI_VENDE = d;
        }
        public void actualizar()
        {
            SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("vista_tuyo", cone);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@ci_ve", SqlDbType.VarChar, 10);
            comando.Parameters[0].Value = CI_VENDE;
            DataSet dato = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(comando);
            adp.Fill(dato);
            bindingSource1.DataSource = dato.Tables[0];
            dataGridView1.DataSource = bindingSource1;
            siempre();
        }
        private void REVISION_VENTAS_Load(object sender, EventArgs e)
        {
            SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("vista_tuyo",cone);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@ci_ve",SqlDbType.VarChar,10);
            comando.Parameters[0].Value = CI_VENDE;
            DataSet dato = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(comando);
            adp.Fill(dato);
            bindingSource1.DataSource = dato.Tables[0];
            textBox2.DataBindings.Add("Text",bindingSource1, "COD_VEN");
            dataGridView1.DataSource = bindingSource1;
            siempre();
        }
        public void siempre()
        {
            SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("vista_tuyo_suma", cone);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@ci_ve", SqlDbType.VarChar, 10);
            comando.Parameters[0].Value = CI_VENDE;
            cone.Open();
            SqlDataReader lee = comando.ExecuteReader();
            while(lee.Read())
            {
                textBox1.Text = lee[0].ToString();
            }
            cone.Close();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveFirst();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveLast();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("ESTAS SEGURO DE BORRAR VENTA?","MENSAJE",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                try
                {
                    SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                    SqlCommand comando = new SqlCommand("ve_vis", cone);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@co", SqlDbType.Int);
                    comando.Parameters[0].Value = textBox2.Text;
                    cone.Open();
                    comando.ExecuteNonQuery();
                    cone.Close();
                    actualizar();
                }
                catch
                {
                    MessageBox.Show("OCURRIO UN ERROR");
                }
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {

        }
    }
}
