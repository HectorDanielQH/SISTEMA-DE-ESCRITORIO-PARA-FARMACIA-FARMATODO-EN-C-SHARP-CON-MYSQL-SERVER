using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//DATOS SQL
using System.Data.SqlClient;
using System.Configuration;

namespace PROYECTO_BASE_II.ADMINISTRADOR.SUB_ELEMENTOS
{
    public partial class NUEVO_USUARIO : Form
    {
        String opcion = "";
        SqlConnection conexion;
        public NUEVO_USUARIO()
        {
            InitializeComponent();
        }

        private void NUEVO_USUARIO_Load(object sender, EventArgs e)
        {
            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                SqlCommand comando = new SqlCommand("select * from mostrar_empleado", conexion);
                comando.CommandType = CommandType.Text;
                DataSet datos = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(comando);
                adp.Fill(datos);
                bindingSource1.DataSource = datos.Tables[0];
                ci.DataBindings.Add("Text", bindingSource1, "CI");
                textBox1.DataBindings.Add("Text", bindingSource1, "NOMBRE");
                textBox2.DataBindings.Add("Text", bindingSource1, "APELLIDOS");
                numericUpDown1.DataBindings.Add("Text", bindingSource1, "EDAD");
                comboBox1.DataBindings.Add("Text", bindingSource1, "TIPO");
                comboBox2.DataBindings.Add("Text", bindingSource1, "NOMBRE FARMACIA");
                dataGridView1.DataSource = bindingSource1;
            }
            catch
            {
                MessageBox.Show("LA BASE DE DATOS NO ESTA DISPONIBLE","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            opcion = "editar";

            for (int i = 0; i < toolStrip1.Items.Count-1; i++)
                toolStrip1.Items[i].Enabled = false;
            toolStrip1.Items[3].Enabled = true;
            ci.ReadOnly = true;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            numericUpDown1.ReadOnly = false;
            toolStripTextBox1.ReadOnly = false;
            toolStripTextBox1.Enabled = true;

            try
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();

                SqlConnection conexionn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());

                SqlCommand comando1 = new SqlCommand("select * from V_TIPO", conexionn);
                comando1.CommandType = CommandType.Text;
                conexionn.Open();
                SqlDataReader le = comando1.ExecuteReader();
                while (le.Read())
                {
                    comboBox1.Items.Add(le[1].ToString());
                }
                conexionn.Close();


                conexionn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                SqlCommand comando11 = new SqlCommand("select f.NIT+'  -   NOMBRE: '+f.NOMBRE as [NOMBRE FARMACIA] from FARMACIA_N f", conexionn);
                comando11.CommandType = CommandType.Text;
                conexionn.Open();
                SqlDataReader le1 = comando11.ExecuteReader();
                while (le1.Read())
                {
                    comboBox2.Items.Add(le1[0].ToString());
                }
                conexionn.Close();
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch(Exception rr)
            {
                MessageBox.Show(rr.Message);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
                toolStrip1.Items[i].Enabled = false;
            toolStrip1.Items[0].Enabled = true;
            toolStrip1.Items[1].Enabled = true;
            toolStrip1.Items[2].Enabled = true;
            toolStrip1.Items[4].Enabled = true;
            toolStrip1.Items[5].Enabled = true;
            toolStrip1.Items[6].Enabled = true;
            toolStrip1.Items[7].Enabled = true;
            boton_busca.Enabled = true;
            try
            {
                SqlCommand comando;
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                if (opcion.Equals("editar"))
                {
                    comando = new SqlCommand("Editar_Usuario", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@ci", SqlDbType.VarChar, 10);
                    comando.Parameters.Add("@nombres", SqlDbType.VarChar, 100);
                    comando.Parameters.Add("@apellidos", SqlDbType.VarChar, 100);
                    comando.Parameters.Add("@Edad", SqlDbType.Int);
                    comando.Parameters.Add("@tipo", SqlDbType.Int);
                    comando.Parameters.Add("@Cod_far", SqlDbType.VarChar,15);
                    comando.Parameters[0].Value = ci.Text;
                    comando.Parameters[1].Value = textBox1.Text;
                    comando.Parameters[2].Value = textBox2.Text;
                    comando.Parameters[3].Value = numericUpDown1.Value.ToString();
                    comando.Parameters[4].Value = (comboBox1.SelectedIndex+1).ToString();
                    comando.Parameters[5].Value = conve(comboBox2.SelectedItem.ToString());
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("SE EDITO EL USUARIO CORRECTAMENTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (opcion.Equals("INSERTAR"))
                {

                    comando = new SqlCommand("insertar_vendedor", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@ci", SqlDbType.VarChar, 10);
                    comando.Parameters.Add("@nombres", SqlDbType.VarChar, 100);
                    comando.Parameters.Add("@apellidos", SqlDbType.VarChar, 100);
                    comando.Parameters.Add("@Edad", SqlDbType.Int);
                    comando.Parameters.Add("@tipo", SqlDbType.Int);
                    comando.Parameters.Add("@Cod_far", SqlDbType.VarChar,15);
                    comando.Parameters[0].Value = ci.Text;
                    comando.Parameters[1].Value = textBox1.Text;
                    comando.Parameters[2].Value = textBox2.Text;
                    comando.Parameters[3].Value = numericUpDown1.Value.ToString();
                    comando.Parameters[4].Value = (comboBox1.SelectedIndex + 1).ToString();
                    comando.Parameters[5].Value = conve(comboBox2.SelectedItem.ToString());
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("SE INSERTO EL USUARIO CORRECTAMENTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (opcion.Equals("eliminar"))
                {

                    comando = new SqlCommand("Eliminar_Usuario", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@ci", SqlDbType.VarChar, 10);
                    comando.Parameters[0].Value = ci.Text;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("SE ELIMINO EL USUARIO CORRECTAMENTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                actualizar();
                ci.ReadOnly = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                numericUpDown1.ReadOnly = true;
                comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox2.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }
        public String conve(String zz)
        {
            String dd = "";
            for (int i=0;i<zz.Length;i++)
            {
                if (zz[i] == ' ')
                    break;
                dd += zz[i];
            }
            return dd;
        }
        public void actualizar()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            DataSet datos = new DataSet();
            SqlDataAdapter ADP = new SqlDataAdapter("select * from mostrar_empleado", con);
            ADP.Fill(datos);
            bindingSource1.DataSource = datos.Tables[0];
            dataGridView1.DataSource = bindingSource1;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < toolStrip1.Items.Count-1; i++)
                toolStrip1.Items[i].Enabled = false;
            toolStrip1.Items[3].Enabled = true;
            ci.ReadOnly = false;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            numericUpDown1.ReadOnly = false;
            try
            {
                opcion = "INSERTAR";

                ci.Text = "";
                textBox2.Text = "";
                textBox1.Text = "";
                numericUpDown1.Value = numericUpDown1.Minimum;
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();

                SqlConnection conexionn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());

                SqlCommand comando1 = new SqlCommand("select * from V_TIPO", conexionn);
                comando1.CommandType = CommandType.Text;
                conexionn.Open();
                SqlDataReader le = comando1.ExecuteReader();
                while (le.Read())
                {
                    comboBox1.Items.Add(le[1].ToString());
                }
                conexionn.Close();


                conexionn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                SqlCommand comando11 = new SqlCommand("select f.NIT+'  -   NOMBRE: '+f.NOMBRE as [NOMBRE FARMACIA] from FARMACIA_N f", conexionn);
                comando11.CommandType = CommandType.Text;
                conexionn.Open();
                SqlDataReader le1 = comando11.ExecuteReader();
                while (le1.Read())
                {
                    comboBox2.Items.Add(le1[0].ToString());
                }
                conexionn.Close();
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
            catch(Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("POR FAVOR BUSQUE EL USUARIO QUE DESEE ELIMINAR","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Information);
            opcion = "eliminar";

            for (int i = 0; i < toolStrip1.Items.Count-1; i++)
                toolStrip1.Items[i].Enabled = false;
            toolStrip1.Items[3].Enabled = true;
            toolStrip1.Items[8].Enabled = true;
            toolStripTextBox1.Enabled = true;
            toolStripTextBox1.ReadOnly = false;
            ci.ReadOnly = false;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            numericUpDown1.ReadOnly = false;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
                toolStrip1.Items[i].Enabled = false;
            toolStrip1.Items[0].Enabled = true;
            toolStrip1.Items[1].Enabled = true;
            toolStrip1.Items[2].Enabled = true;
            toolStrip1.Items[4].Enabled = true;
            toolStrip1.Items[5].Enabled = true;
            toolStrip1.Items[6].Enabled = true;
            toolStrip1.Items[7].Enabled = true;
            boton_busca.Enabled = true;
            actualizar();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("POR FAVOR BUSQUE EL USUARIO", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            for (int i = 0; i < toolStrip1.Items.Count - 1; i++)
                toolStrip1.Items[i].Enabled = false;
            toolStripTextBox1.Enabled = true;
            toolStripTextBox1.ReadOnly = false;
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            actualizar_busqueda(toolStripTextBox1.Text);
        }
        public void actualizar_busqueda(String la_bus)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                DataSet datos3 = new DataSet();
                SqlCommand coman11 = new SqlCommand("buscar_empleado", con);
                coman11.CommandType = CommandType.StoredProcedure;
                coman11.Parameters.Add("@ci", SqlDbType.VarChar, 10);
                coman11.Parameters[0].Value = la_bus;
                SqlDataAdapter ADP = new SqlDataAdapter(coman11);
                ADP.Fill(datos3);
                bindingSource1.DataSource = datos3.Tables[0];
                dataGridView1.DataSource = bindingSource1;
            }
            catch(Exception r)
            {
                MessageBox.Show(r.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
