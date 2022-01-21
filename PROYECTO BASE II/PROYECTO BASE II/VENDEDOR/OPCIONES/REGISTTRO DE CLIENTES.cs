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
    public partial class REGISTTRO_DE_CLIENTES : Form
    {

        public REGISTTRO_DE_CLIENTES()
        {
            InitializeComponent();
        }
        String bande = "";
        public void actualizar()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("select * from CLIENTE", con);
            DataSet datos = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(comando);
            adp.Fill(datos);
            bindingSource1.DataSource = datos.Tables[0];
            dataGridView1.DataSource = bindingSource1;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            numericUpDown1.ReadOnly = true;
        }

        private void REGISTTRO_DE_CLIENTES_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("select * from CLIENTE", con);
            DataSet datos = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(comando);
            adp.Fill(datos);
            bindingSource1.DataSource = datos.Tables[0];
            numericUpDown1.DataBindings.Add("Text", bindingSource1, "CI");
            textBox1.DataBindings.Add("Text", bindingSource1, "NOMBRE");
            textBox2.DataBindings.Add("Text", bindingSource1, "APELLIDOS");
            dataGridView1.DataSource = bindingSource1;
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            for(int i=0;i<toolStrip1.Items.Count-1;i++)
            {
                toolStrip1.Items[i].Enabled = false;
            }
            toolStrip1.Items[3].Enabled = true;
            bande = "insertar";
            numericUpDown1.Value = numericUpDown1.Minimum;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            numericUpDown1.ReadOnly = false;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
            {
                toolStrip1.Items[i].Enabled = true;
            }
            toolStrip1.Items[3].Enabled = false;
            actualizar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
            {
                toolStrip1.Items[i].Enabled = false;
            }
            toolStrip1.Items[3].Enabled = true;
            bande = "editar";
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
            {
                toolStrip1.Items[i].Enabled = false;
            }
            toolStrip1.Items[3].Enabled = true;
            bande = "eliminar";
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if(bande=="insertar")
                {
                    SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                    SqlCommand comando = new SqlCommand("insertar_cliente", conex);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@ci",SqlDbType.VarChar,15);
                    comando.Parameters.Add("@nombre", SqlDbType.VarChar, 150);
                    comando.Parameters.Add("@apellido", SqlDbType.VarChar, 150);
                    comando.Parameters[0].Value =numericUpDown1.Value.ToString();
                    comando.Parameters[1].Value = textBox1.Text;
                    comando.Parameters[2].Value = textBox2.Text;
                    conex.Open();
                    comando.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("EL USUARIO SE INSERTO CORRECTAMENTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if(bande=="editar")
                {
                    SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                    SqlCommand comando = new SqlCommand("actualizar_cliente", conex);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@ci", SqlDbType.VarChar, 15);
                    comando.Parameters.Add("@nombre", SqlDbType.VarChar, 150);
                    comando.Parameters.Add("@apellido", SqlDbType.VarChar, 150);
                    comando.Parameters[0].Value = numericUpDown1.Value.ToString();
                    comando.Parameters[1].Value = textBox1.Text;
                    comando.Parameters[2].Value = textBox2.Text;
                    conex.Open();
                    comando.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("EL USUARIO SE EDITO CORRECTAMENTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if(bande=="eliminar")
                {
                    SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                    SqlCommand comando = new SqlCommand("eliminar_cliente", conex);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@ci", SqlDbType.VarChar, 15);
                    comando.Parameters[0].Value = numericUpDown1.Value.ToString();
                    conex.Open();
                    comando.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("EL USUARIO SE ELIMINO CORRECTAMENTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(SqlException men)
            {
                MessageBox.Show(men.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                for(int i=0;i<toolStrip1.Items.Count-1;i++)
                {
                    toolStrip1.Items[i].Enabled = true;
                }
                toolStrip1.Items[3].Enabled = false;
                actualizar();
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                SqlCommand comando = new SqlCommand("buscar_cliente", conex);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ci", SqlDbType.VarChar, 15);
                comando.Parameters[0].Value = toolStripTextBox1.Text;
                DataSet datos = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(comando);
                adp.Fill(datos);
                bindingSource1.DataSource = datos.Tables[0];
                dataGridView1.DataSource = bindingSource1;
            }
            catch
            {
                MessageBox.Show("OCURRIO UN ERROR DE CARGA");
            }
        }
    }
}
