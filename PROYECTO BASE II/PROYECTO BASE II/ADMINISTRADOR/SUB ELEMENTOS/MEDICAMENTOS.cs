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

namespace PROYECTO_BASE_II.ADMINISTRADOR.SUB_ELEMENTOS
{
    public partial class MEDICAMENTOS : Form
    {
        SqlConnection cone;
        String ubica = "";
        public MEDICAMENTOS()
        {
            InitializeComponent();
        }

        private void MEDICAMENTOS_Load(object sender, EventArgs e)
        {
            cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("select * from demostracion", cone);
            comando.CommandType = CommandType.Text;
            DataSet datos = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(comando);
            ad.Fill(datos);
            bindingSource1.DataSource = datos.Tables[0];
            COD_PRO.DataBindings.Add("Text", bindingSource1, "COD");
            DES_PRO.DataBindings.Add("Text", bindingSource1, "DESCRIPCION");
            PRECIO.DataBindings.Add("Text", bindingSource1, "PRECIO");
            PRECIO_VENTA.DataBindings.Add("Text", bindingSource1, "PRECIO VENTA");
            FECHA_ELAB.DataBindings.Add("Text", bindingSource1, "FECHA DE ELABORACION");
            FECHA_VEN.DataBindings.Add("Text", bindingSource1, "FECHA DE VENCIMIENTO");
            RUTA.DataBindings.Add("Text", bindingSource1, "RUTA");
            dataGridView1.DataSource = bindingSource1;
            try
            {
                pictureBox1.ImageLocation = RUTA.Text;
            }
            catch
            {
                pictureBox1.Image = Properties.Resources.abort_156539_960_720;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "IMAGENES EN JPG|*.jpg|IMAGENES EN PNG|*.png";
            openFileDialog1.InitialDirectory = @"D:\PROYECTOS C#\PROYECTO BASE II\IMAGENES DEL PROYECTO";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                RUTA.Text = openFileDialog1.FileName;
                pictureBox1.ImageLocation = RUTA.Text;
            }
        }
        public void actualizar()
        {
            cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("select * from demostracion", cone);
            comando.CommandType = CommandType.Text;
            DataSet datos = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(comando);
            ad.Fill(datos);
            bindingSource1.DataSource = datos.Tables[0];
            dataGridView1.DataSource = bindingSource1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.abort_156539_960_720;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if(ubica=="insertar")
                {
                    cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                    SqlCommand comando = new SqlCommand("insertar_medicamento", cone);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@cod_pro",SqlDbType.VarChar,100);
                    comando.Parameters.Add("@descrip", SqlDbType.VarChar, 500);
                    comando.Parameters.Add("@precio", SqlDbType.Money);
                    comando.Parameters.Add("@precio_venta", SqlDbType.Money);
                    comando.Parameters.Add("@fecha_elab", SqlDbType.Date);
                    comando.Parameters.Add("@fecha_ven", SqlDbType.Date);
                    comando.Parameters.Add("@ruta", SqlDbType.VarChar, 500);
                    comando.Parameters[0].Value = COD_PRO.Text;
                    comando.Parameters[1].Value = DES_PRO.Text;
                    comando.Parameters[2].Value = PRECIO.Value.ToString();
                    comando.Parameters[3].Value = PRECIO_VENTA.Value.ToString();
                    comando.Parameters[4].Value = FECHA_ELAB.Value.ToString();
                    comando.Parameters[5].Value = FECHA_VEN.Value.ToString();
                    comando.Parameters[6].Value = RUTA.Text;
                    cone.Open();
                    comando.ExecuteNonQuery();
                    cone.Close();
                    MessageBox.Show("SE INSERTO EL MEDICAMENTO CORRECTAMENTE", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if(ubica=="editar")
                {
                    cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                    SqlCommand comando = new SqlCommand("editar_medicamento", cone);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@cod_pro", SqlDbType.VarChar, 100);
                    comando.Parameters.Add("@descrip", SqlDbType.VarChar, 500);
                    comando.Parameters.Add("@precio", SqlDbType.Money);
                    comando.Parameters.Add("@precio_venta", SqlDbType.Money);
                    comando.Parameters.Add("@fecha_elab", SqlDbType.Date);
                    comando.Parameters.Add("@fecha_ven", SqlDbType.Date);
                    comando.Parameters.Add("@ruta", SqlDbType.VarChar, 500);
                    comando.Parameters[0].Value = COD_PRO.Text;
                    comando.Parameters[1].Value = DES_PRO.Text;
                    comando.Parameters[2].Value = PRECIO.Value.ToString();
                    comando.Parameters[3].Value = PRECIO_VENTA.Value.ToString();
                    comando.Parameters[4].Value = FECHA_ELAB.Value.ToString();
                    comando.Parameters[5].Value = FECHA_VEN.Value.ToString();
                    comando.Parameters[6].Value = RUTA.Text;
                    cone.Open();
                    comando.ExecuteNonQuery();
                    cone.Close();
                    MessageBox.Show("SE EDITO EL MEDICAMENTO CORRECTAMENTE", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if(ubica=="eliminar")
                {
                    cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                    SqlCommand comando = new SqlCommand("eliminar", cone);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@cod_pro", SqlDbType.VarChar, 100);
                    comando.Parameters[0].Value = COD_PRO.Text;
                    cone.Open();
                    comando.ExecuteNonQuery();
                    cone.Close();
                    MessageBox.Show("SE ELIMINO EL MEDICAMENTO CORRECTAMENTE", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(SqlException ee)
            {
                MessageBox.Show(ee.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
                {
                    toolStrip1.Items[i].Enabled = true;
                }
                toolStrip1.Items[3].Enabled = false;
                COD_PRO.ReadOnly = true;
                DES_PRO.ReadOnly = true;
                PRECIO.ReadOnly = true;
                PRECIO_VENTA.ReadOnly = true;
                actualizar();
            }
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

        private void RUTA_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = RUTA.Text;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            COD_PRO.ReadOnly = false;
            DES_PRO.ReadOnly = false;
            PRECIO.ReadOnly = false;
            PRECIO_VENTA.ReadOnly = false;
            ubica = "insertar";
            for(int i=0;i<toolStrip1.Items.Count-1;i++)
            {
                toolStrip1.Items[i].Enabled = false;
            }
            toolStrip1.Items[3].Enabled = true;
            COD_PRO.Text = "";
            RUTA.Text = "";
            DES_PRO.Text = "";
            PRECIO.Value = 0;
            PRECIO_VENTA.Value = 0;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            COD_PRO.ReadOnly = false;
            DES_PRO.ReadOnly = false;
            PRECIO.ReadOnly = false;
            PRECIO_VENTA.ReadOnly = false;
            ubica = "editar";
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
            {
                toolStrip1.Items[i].Enabled = false;
            }
            toolStrip1.Items[3].Enabled = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            COD_PRO.ReadOnly = false;
            DES_PRO.ReadOnly = false;
            PRECIO.ReadOnly = false;
            PRECIO_VENTA.ReadOnly = false;
            ubica = "eliminar";
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
            {
                toolStrip1.Items[i].Enabled = false;
            }
            toolStrip1.Items[3].Enabled = true;
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("buscar_produc", cone);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@cod_pro", SqlDbType.VarChar, 500);
            comando.Parameters[0].Value = toolStripTextBox1.Text;
            DataSet datos = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(comando);
            ad.Fill(datos);
            bindingSource1.DataSource = datos.Tables[0];
            dataGridView1.DataSource = bindingSource1;
        }

        private void boton_busca_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BUSQUE EL MEDICAMENTO POR FAVOR", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            toolStripTextBox1.Enabled = true;
        }
    }
}
