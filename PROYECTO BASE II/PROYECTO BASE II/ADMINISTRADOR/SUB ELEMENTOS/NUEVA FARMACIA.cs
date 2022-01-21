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


namespace PROYECTO_BASE_II.ADMINISTRADOR.SUB_ELEMENTOS
{
    public partial class NUEVA_FARMACIA : Form
    {
        SqlConnection cone;
        String elecc="";
        public NUEVA_FARMACIA()
        {
            InitializeComponent();
        }
        public void DUEN_INSER()
        {
            try
            {
                cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                SqlCommand coman = new SqlCommand("select * from combo", cone);
                coman.CommandType = CommandType.Text;
                cone.Open();
                SqlDataReader lee = coman.ExecuteReader();
                DUENIO.Items.Clear();
               
                while(lee.Read())
                {
                    DUENIO.Items.Add(lee[0].ToString());
                }
                cone.Close();
            }
            catch(Exception R)
            {
                MessageBox.Show("OCURRIO UN ERROR DE CARGA" + R.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
                toolStrip1.Items[i].Enabled = false;
            toolStrip1.Items[3].Enabled = true;
            elecc = "insertar";
            COD_FAR.Text = datito();
            NOMBRE_FAR.Text = "";
            NOMBRE_FAR.ReadOnly = false;
            NIT.ReadOnly = false;
            NIT.Text = "";
            DUEN_INSER();
            UBICACION.Text = "";
            UBICACION.ReadOnly = false;
        }
        public String datito()
        {
            String fri = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("select MAX(COD_FAR) from FARMACIA_N",con);
            con.Open();
            SqlDataReader le = comando.ExecuteReader();
            while(le.Read())
            {
                fri = le[0].ToString();
            }
            con.Close();
            long num = long.Parse(fri);
            num++;
            fri = num.ToString();
            return fri;
        }
        private void NUEVA_FARMACIA_Load(object sender, EventArgs e)
        {
            cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            DataSet datos = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("select * from visualizar_farmacia", cone);
            adp.Fill(datos);
            bindingSource1.DataSource = datos.Tables[0];
            NIT.DataBindings.Add("Text",bindingSource1,"NIT");
            NOMBRE_FAR.DataBindings.Add("Text", bindingSource1, "NOMBRE");
            UBICACION.DataBindings.Add("Text", bindingSource1, "UBICACION");
            DUENIO.DataBindings.Add("Text", bindingSource1, "NOMBRE DEL DUEÑO");
            dataGridView1.DataSource = bindingSource1;
        }
        public String codigo_d()
        {
            String toma = "", al=DUENIO.Text.ToString();
            for(int i=0;i<al.Length;i++)
            {
                if (al[i] == ' ')
                    break;
                else
                    toma += al[i];
            }
            return toma;
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (elecc.Equals("insertar"))
                {
                    cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                    SqlCommand comando = new SqlCommand("insertar_farmacia", cone);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@cod_far", SqlDbType.Int);
                    comando.Parameters.Add("@nombre", SqlDbType.VarChar, 100);
                    comando.Parameters.Add("@NIT", SqlDbType.VarChar, 100);
                    comando.Parameters.Add("@COD_DUE", SqlDbType.VarChar, 10);
                    comando.Parameters.Add("@UBICACION", SqlDbType.VarChar, 200);
                    comando.Parameters[0].Value = COD_FAR.Text;
                    comando.Parameters[1].Value = NOMBRE_FAR.Text;
                    comando.Parameters[2].Value = NIT.Text;
                    comando.Parameters[3].Value = codigo_d();
                    comando.Parameters[4].Value = UBICACION.Text;
                    cone.Open();
                    comando.ExecuteNonQuery();
                    cone.Close();
                    MessageBox.Show("EL USUARIO SE INSERTO CORRECTAMENTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (elecc.Equals("editar"))
                {
                    cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                    SqlCommand comando = new SqlCommand("editar_farmacia", cone);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@cod_far", SqlDbType.Int);
                    comando.Parameters.Add("@nombre", SqlDbType.VarChar, 100);
                    comando.Parameters.Add("@NIT", SqlDbType.VarChar, 100);
                    comando.Parameters.Add("@COD_DUE", SqlDbType.VarChar, 10);
                    comando.Parameters.Add("@UBICACION", SqlDbType.VarChar, 200);
                    comando.Parameters[0].Value = COD_FAR.Text;
                    comando.Parameters[1].Value = NOMBRE_FAR.Text;
                    comando.Parameters[2].Value = NIT.Text;
                    comando.Parameters[3].Value = codigo_d();
                    comando.Parameters[4].Value = UBICACION.Text;
                    cone.Open();
                    comando.ExecuteNonQuery();
                    cone.Close();
                    MessageBox.Show("EL USUARIO SE EDITO CORRECTAMENTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (elecc.Equals("eliminar"))
                {
                    if(MessageBox.Show("ESTAS SEGURO DE ELIMINAR LA FARMACIA?","PREGUNTA",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                    {
                        cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                        SqlCommand comando = new SqlCommand("eliminar_farmacia", cone);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@cod_far", SqlDbType.Int);
                        comando.Parameters[0].Value = COD_FAR.Text;
                        cone.Open();
                        comando.ExecuteNonQuery();
                        cone.Close();
                        MessageBox.Show("LA FARMACIA SE ELIMINO CORRECTAMENTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(SqlException rrr)
            {
                MessageBox.Show(rrr.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                actualizar();
                for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
                    toolStrip1.Items[i].Enabled = true;
                toolStrip1.Items[3].Enabled = false;
            }
        }
        public void actualizar()
        {
            try
            {
                cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                DataSet datos = new DataSet();
                COD_FAR.Text = "";
                SqlDataAdapter adp = new SqlDataAdapter("select * from visualizar_farmacia", cone);
                adp.Fill(datos);
                bindingSource1.DataSource = datos.Tables[0];
                dataGridView1.DataSource = bindingSource1;

            }
            catch
            {
                MessageBox.Show("OCURRIO UN ERROR EN LA CARGA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
                toolStrip1.Items[i].Enabled = false;
            toolStrip1.Items[3].Enabled = true;
            elecc = "editar";
            NOMBRE_FAR.ReadOnly = false;
            NIT.ReadOnly = false;
            DUEN_INSER();
            UBICACION.ReadOnly = false;
            try
            {
                SqlConnection co = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                SqlCommand comando = new SqlCommand("select * from FARMACIA_N where NIT='"+NIT.Text+"'", co);
                comando.CommandType = CommandType.Text;
                co.Open();
                SqlDataReader lector = comando.ExecuteReader();
                while(lector.Read())
                {
                    COD_FAR.Text = lector[0].ToString();
                }
                co.Close();
            }
            catch(Exception qw)
            {
                MessageBox.Show(qw.Message);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
                toolStrip1.Items[i].Enabled = false;
            toolStrip1.Items[3].Enabled = true;
            elecc = "eliminar";
            try
            {
                SqlConnection co = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                SqlCommand comando = new SqlCommand("select * from FARMACIA_N where NIT='" + NIT.Text + "'", co);
                comando.CommandType = CommandType.Text;
                co.Open();
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    COD_FAR.Text = lector[0].ToString();
                }
                co.Close();
            }
            catch (Exception qw)
            {
                MessageBox.Show(qw.Message);
            }
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

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            actualizar();
            COD_FAR.Text = "";
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
                toolStrip1.Items[i].Enabled = true;
            toolStrip1.Items[3].Enabled = false;
        }

        private void boton_busca_Click(object sender, EventArgs e)
        {
            MessageBox.Show("porfavor busca con el NIT");
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando = new SqlCommand("buca",cons);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@nit",SqlDbType.VarChar,20);
            comando.Parameters[0].Value = toolStripTextBox1.Text;
            DataSet dato = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(comando);
            adp.Fill(dato);
            bindingSource1.DataSource = dato.Tables[0];
        }

        private void DUENIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            DUENIO.Text = "";
            MessageBox.Show("ESTA PROHIBIDO HACER CAMBIOS");
        }
    }
}
