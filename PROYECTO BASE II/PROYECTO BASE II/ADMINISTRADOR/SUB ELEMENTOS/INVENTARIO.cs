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
    public partial class INVENTARIO : Form
    {
        SqlConnection cone;
        String reco = "";
        public INVENTARIO()
        {
            InitializeComponent();
        }

        private void INVENTARIO_Load(object sender, EventArgs e)
        {
            cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("select * from tiene_vista_tabla", cone);
            comando.CommandType = CommandType.Text;
            DataSet dato = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(comando);
            adp.Fill(dato);
            bindingSource1.DataSource = dato.Tables[0];
            FARMACIA.DataBindings.Add("Text",bindingSource1,"FARMACIA");
            UBICACION.DataBindings.Add("Text", bindingSource1, "UBICACION");
            DESCRIP_PRO.DataBindings.Add("Text", bindingSource1, "DESCRIPCION DEL PRODUCTO");
            CANTIDAD.DataBindings.Add("Text", bindingSource1, "CANTIDAD");
            FECHA_ELAB.DataBindings.Add("Text", bindingSource1, "FECHA DE ELABORACION");
            FECHA_VEN.DataBindings.Add("Text", bindingSource1, "FECHA DE VENCIMIENTO");
            RUTA.DataBindings.Add("Text", bindingSource1, "RUTA");
            dataGridView1.DataSource = bindingSource1;
        }
        public String solo_valor(String d)
        {
            String toma = "";
            for(int i=0;i<d.Length;i++)
            {
                if (d[i] == ' ')
                    break;
                else
                    toma += d[i];
            }
            return toma;
        }
        public void cargarcombo()
        {
            try
            { 
                SqlConnection coneR = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                SqlCommand coman = new SqlCommand("select * from box_farmacia", coneR);
                coneR.Open();
                SqlDataReader lee = coman.ExecuteReader();
                while (lee.Read())
                {
                    FARMACIA.Items.Add(lee[0].ToString());
                }
                coneR.Close();
                coneR = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                SqlCommand coman1 = new SqlCommand("select * from box_medicamento", coneR);
                coneR.Open();
                SqlDataReader lee1 = coman1.ExecuteReader();
                while (lee1.Read())
                {
                    DESCRIP_PRO.Items.Add(lee1[0].ToString());
                }
                coneR.Close();
            }
            catch
            {
                MessageBox.Show("OCURRIO UN ERROR DE CARGA");
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.abort_156539_960_720;
            reco = "insertar";
            UBICACION.Text = "";
            CANTIDAD.Value = 0;
            for(int i=0;i<toolStrip1.Items.Count-1;i++)
            {
                toolStrip1.Items[i].Enabled = false;
            }
            toolStrip1.Items[3].Enabled = true;
            FARMACIA.Items.Clear();
            DESCRIP_PRO.Items.Clear();
            cargarcombo();
            FARMACIA.SelectedIndex = 0;
            DESCRIP_PRO.SelectedIndex = 0;
        }

        private void RUTA_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = RUTA.Text;
        }

        private void FARMACIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void DESCRIP_PRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FARMACIA_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                SqlConnection tt = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                String valor = solo_valor(FARMACIA.Text);
                valor = "select f.UBICACION from FARMACIA_N f where f.NIT='" + valor + "'";
                SqlCommand comando = new SqlCommand(valor, tt);
                comando.CommandType = CommandType.Text;
                tt.Open();
                SqlDataReader lee = comando.ExecuteReader();
                while (lee.Read())
                {
                    UBICACION.Text = lee[0].ToString();
                }
                tt.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void DESCRIP_PRO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                SqlConnection tt = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                String valor = solo_valor(DESCRIP_PRO.Text), un;
                un = valor;
                valor = "select p.DESCRIPCION from PRODUCTO p where p.COD='" + valor + "'";
                String F_VEN = "select p.[FECHA DE VENCIMIENTO] from PRODUCTO p where p.COD='" + un + "'", F_ELA = "select p.[FECHA DE ELABORACION] from PRODUCTO p where p.COD='" + un + "'";
                String Ruta = "select i.RUTA from PRODUCTO p,IMAGEN i where p.IMAGEN=i.COD_IM and p.COD='" + un + "'";
                SqlCommand comando = new SqlCommand(valor, tt);
                comando.CommandType = CommandType.Text;
                tt.Open();
                SqlDataReader lee_com = comando.ExecuteReader();
                while (lee_com.Read())
                {
                    DESCRIP_PRO.Text = lee_com[0].ToString();
                }
                tt.Close();
                tt = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                tt.Open();
                SqlCommand com_ven = new SqlCommand(F_VEN, tt);
                com_ven.CommandType = CommandType.Text;
                SqlDataReader lee_ven = com_ven.ExecuteReader();
                while (lee_ven.Read())
                {
                    FECHA_VEN.Value = DateTime.Parse(lee_ven[0].ToString());
                }
                tt.Close();
                tt = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                tt.Open();
                SqlCommand com_ela = new SqlCommand(F_ELA, tt);
                com_ela.CommandType = CommandType.Text;
                SqlDataReader lee_ela = com_ela.ExecuteReader();
                while (lee_ela.Read())
                {
                    FECHA_ELAB.Value = DateTime.Parse(lee_ela[0].ToString());
                }
                tt.Close();
                tt = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                tt.Open();
                SqlCommand rut = new SqlCommand(Ruta, tt);
                rut.CommandType = CommandType.Text;
                SqlDataReader lee_rut = rut.ExecuteReader();
                while (lee_rut.Read())
                {
                    RUTA.Text = lee_rut[0].ToString();
                }
                tt.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        public void actualizar() 
        {
            FARMACIA.Items.Clear();
            DESCRIP_PRO.Items.Clear();
            cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("select * from tiene_vista_tabla", cone);
            comando.CommandType = CommandType.Text;
            DataSet dato = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(comando);
            adp.Fill(dato);
            bindingSource1.DataSource = dato.Tables[0];
            dataGridView1.DataSource = bindingSource1;
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if(reco=="insertar")
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                    SqlCommand comando = new SqlCommand("insertar_tiene", con);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@nit",SqlDbType.VarChar,100);
                    comando.Parameters.Add("@cod_pro", SqlDbType.VarChar, 100);
                    comando.Parameters.Add("@canti", SqlDbType.Int);
                    comando.Parameters[0].Value = solo_valor(FARMACIA.Text);
                    comando.Parameters[1].Value = solo_valor(DESCRIP_PRO.Text);
                    comando.Parameters[2].Value = CANTIDAD.Value.ToString();
                    con.Open();
                    comando.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("LA TAREA FUE REALIZADA EXITOSAMENTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (reco == "editar")
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                    SqlCommand comando = new SqlCommand("actualizar_tiene", con);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@nit", SqlDbType.VarChar, 100);
                    comando.Parameters.Add("@cod_pro", SqlDbType.VarChar, 100);
                    comando.Parameters.Add("@canti", SqlDbType.Int);
                    comando.Parameters[0].Value = solo_valor(FARMACIA.Text);
                    comando.Parameters[1].Value = solo_valor(DESCRIP_PRO.Text);
                    comando.Parameters[2].Value = CANTIDAD.Value.ToString();
                    con.Open();
                    comando.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("LA TAREA FUE REALIZADA EXITOSAMENTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FARMACIA.Items.Clear();
                    DESCRIP_PRO.Items.Clear();
                }
                if (reco == "eliminar")
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                    SqlCommand comando = new SqlCommand("eliminar_tiene", con);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@nit", SqlDbType.VarChar, 100);
                    comando.Parameters.Add("@cod_pro", SqlDbType.VarChar, 100);
                    comando.Parameters[0].Value = solo_valor(FARMACIA.Text);
                    comando.Parameters[1].Value = solo_valor(DESCRIP_PRO.Text);
                    con.Open();
                    comando.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("LA TAREA FUE REALIZADA EXITOSAMENTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FARMACIA.Items.Clear();
                    DESCRIP_PRO.Items.Clear();
                }
            }
            catch (SqlException ee)
            {
                MessageBox.Show(ee.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                actualizar();
                for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
                    toolStrip1.Items[i].Enabled = true;
                toolStrip1.Items[3].Enabled = false;
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            actualizar();
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
                toolStrip1.Items[i].Enabled = true;
            toolStrip1.Items[3].Enabled = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            reco = "editar";
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
            {
                toolStrip1.Items[i].Enabled = false;
            }
            toolStrip1.Items[3].Enabled = true;
            cargarcombo();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            reco = "eliminar";
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
            {
                toolStrip1.Items[i].Enabled = false;
            }
            toolStrip1.Items[3].Enabled = true;
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

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                SqlCommand comando = new SqlCommand("buscar_tiene", con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar, 500);
                comando.Parameters[0].Value = toolStripTextBox1.Text;
                con.Open();
                DataSet datos = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(comando);
                adp.Fill(datos);
                bindingSource1.DataSource = datos.Tables[0];
                dataGridView1.DataSource = bindingSource1;
                con.Close();
            }
            catch
            {
                MessageBox.Show("OCURRIO UN ERROR INESPERADO");
            }
        }
    }
}
