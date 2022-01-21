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
    public partial class VENTA_DE_MEDICAMENTOS : Form
    {
        String CI_VENDE="";
        public VENTA_DE_MEDICAMENTOS()
        {
            InitializeComponent();
        }
        public void toma(String v)
        {
            String f = "";
            for(int i=0;i<v.Length;i++)
            {
                if (v[i] == ' ')
                    break;
                else
                    f += v[i];
            }
            CI_VENDE = f;
        }
        private void VENTA_DE_MEDICAMENTOS_Load(object sender, EventArgs e)
        {
            dataGridView3.ColumnCount= 4;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando1 = new SqlCommand("bus_por_far_ven", con);
            comando1.CommandType = CommandType.StoredProcedure;
            comando1.Parameters.Add("@ci",SqlDbType.VarChar,15);
            comando1.Parameters.Add("@descrip", SqlDbType.VarChar, 500);
            comando1.Parameters[0].Value =CI_VENDE;
            comando1.Parameters[1].Value ="";
            DataSet dato = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(comando1);
            adp.Fill(dato);
            PA_PRODUCTO.DataSource = dato.Tables[0];
            COD_PRO.DataBindings.Add("Text",PA_PRODUCTO,"COD");
            DES_PRO.DataBindings.Add("Text", PA_PRODUCTO, "DESCRIPCION");
            CAN_PRO.DataBindings.Add("Text", PA_PRODUCTO, "CANTIDAD");
            prec.DataBindings.Add("Text", PA_PRODUCTO, "PRECIO VENTA");
            RUTA.DataBindings.Add("Text", PA_PRODUCTO, "RUTA");
            dataGridView2.DataSource = PA_PRODUCTO;

            SqlCommand comando2 = new SqlCommand("buscar_cliente_ven", con);
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.Parameters.Add("@ci", SqlDbType.VarChar, 15);
            comando2.Parameters[0].Value = "";
            DataSet dato1 = new DataSet();
            SqlDataAdapter adp1 = new SqlDataAdapter(comando2);
            adp1.Fill(dato1);
            PA_USUARIO.DataSource = dato1.Tables[0];
            CI_CLI.DataBindings.Add("Text", PA_USUARIO, "CI");
            NOMBRE.DataBindings.Add("Text", PA_USUARIO, "NOMBRE");
            APELLIDOS.DataBindings.Add("Text", PA_USUARIO, "APELLIDOS");
            dataGridView1.DataSource = PA_USUARIO;
        }

        private void bus_des_por_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando1 = new SqlCommand("bus_por_far_ven", con);
            comando1.CommandType = CommandType.StoredProcedure;
            comando1.Parameters.Add("@ci", SqlDbType.VarChar, 15);
            comando1.Parameters.Add("@descrip", SqlDbType.VarChar, 500);
            comando1.Parameters[0].Value = CI_VENDE;
            comando1.Parameters[1].Value = bus_des_por.Text;
            DataSet dato = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(comando1);
            adp.Fill(dato);
            PA_PRODUCTO.DataSource = dato.Tables[0];
            dataGridView2.DataSource = PA_PRODUCTO;
        }

        private void bus_ci_por_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando2 = new SqlCommand("buscar_cliente_ven", con);
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.Parameters.Add("@ci", SqlDbType.VarChar, 15);
            comando2.Parameters[0].Value = bus_ci_por.Text;
            DataSet dato1 = new DataSet();
            SqlDataAdapter adp1 = new SqlDataAdapter(comando2);
            adp1.Fill(dato1);
            PA_USUARIO.DataSource = dato1.Tables[0];
            dataGridView1.DataSource = PA_USUARIO;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PA_PRODUCTO.MovePrevious();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PA_PRODUCTO.MoveNext();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PA_PRODUCTO.MoveFirst();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PA_PRODUCTO.MoveLast();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PA_USUARIO.MovePrevious();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PA_USUARIO.MoveNext();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PA_USUARIO.MoveFirst();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PA_USUARIO.MoveLast();
        }
        public void actualizar()
        {
            dataGridView3.Rows.Clear();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando1 = new SqlCommand("bus_por_far_ven", con);
            comando1.CommandType = CommandType.StoredProcedure;
            comando1.Parameters.Add("@ci", SqlDbType.VarChar, 15);
            comando1.Parameters.Add("@descrip", SqlDbType.VarChar, 500);
            comando1.Parameters[0].Value = CI_VENDE;
            comando1.Parameters[1].Value = "";
            DataSet dato = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(comando1);
            adp.Fill(dato);
            PA_PRODUCTO.DataSource = dato.Tables[0];
            dataGridView2.DataSource = PA_PRODUCTO;

            SqlCommand comando2 = new SqlCommand("buscar_cliente_ven", con);
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.Parameters.Add("@ci", SqlDbType.VarChar, 15);
            comando2.Parameters[0].Value = "";
            DataSet dato1 = new DataSet();
            SqlDataAdapter adp1 = new SqlDataAdapter(comando2);
            adp1.Fill(dato1);
            PA_USUARIO.DataSource = dato1.Tables[0];
            dataGridView1.DataSource = PA_USUARIO;
            dataGridView3.ColumnCount = 4;
            textBox1.Text = "0";
            numericUpDown1.Value = numericUpDown1.Minimum;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            
            if(dataGridView3.Rows.Count!=0)
            {
                if(CI_CLI.Text!="")
                {
                    try
                    {
                        for (int i = 0; i < dataGridView3.Rows.Count; i++)
                        {
                            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                            SqlCommand comando2 = new SqlCommand("insertar_venta_compra", con);
                            comando2.CommandType = CommandType.StoredProcedure;
                            comando2.Parameters.Add("@ci_cli", SqlDbType.VarChar, 15);
                            comando2.Parameters.Add("@cod_ven", SqlDbType.VarChar, 10);
                            comando2.Parameters.Add("@cod_pro", SqlDbType.VarChar, 100);
                            comando2.Parameters.Add("@canti", SqlDbType.Int);
                            comando2.Parameters[0].Value = CI_CLI.Text;
                            comando2.Parameters[1].Value = CI_VENDE;
                            comando2.Parameters[2].Value = dataGridView3.Rows[i].Cells[0].Value.ToString();
                            comando2.Parameters[3].Value = dataGridView3.Rows[i].Cells[2].Value.ToString();
                            con.Open();
                            comando2.ExecuteNonQuery();
                            con.Close();
                        }
                        SqlConnection conin = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                        SqlCommand comandoin2 = new SqlCommand("toma", conin);
                        comandoin2.CommandType = CommandType.StoredProcedure;
                        conin.Open();
                        comandoin2.ExecuteNonQuery();
                        conin.Close();
                        MessageBox.Show("LA VENTA SE REALIZO CORRECTAMENTE POR FAVOR GENERE LA FACTURA", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button12.Enabled = true;
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("NO ELIGIO AL CLIENTE AL CUAL SE VENDERA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("NO EXISTE ELEMENTOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(COD_PRO.Text=="")
            {
                MessageBox.Show("POR FAVOR SELECCIONES UN PRODUCTO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if ((int.Parse(numericUpDown1.Value.ToString())<=int.Parse(CAN_PRO.Text)) && (int.Parse(numericUpDown1.Value.ToString())>0))
                {
                    dataGridView3.Rows.Add(COD_PRO.Text, DES_PRO.Text, numericUpDown1.Value.ToString(), prec.Text);
                    float nuevo = float.Parse(textBox1.Text);
                    nuevo += (float.Parse(numericUpDown1.Value.ToString()) * float.Parse(prec.Text.ToString()));
                    textBox1.Text = nuevo.ToString();
                }
                else
                {
                    MessageBox.Show("SOBREPASA LA CANTIDAD ESTABLESIDA DEL PRODUCTO","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                for(int i=0;i<dataGridView3.Rows.Count;i++)
                {
                    if (dataGridView3.Rows[i].Selected)
                    {
                        float nue = float.Parse(textBox1.Text);
                        nue -= ((float.Parse(dataGridView3.Rows[i].Cells[2].Value.ToString()))*(float.Parse(dataGridView3.Rows[i].Cells[3].Value.ToString())));
                        textBox1.Text = nue.ToString();
                        dataGridView3.Rows.RemoveAt(i);
                    }
                }
            }
            catch
            {
                MessageBox.Show("POR FAVOR SELECCIONE UNA FILA PARA ELIMINAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RUTA_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = RUTA.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            REPORT C = new REPORT();
            C.obten(CI_CLI.Text,CI_VENDE);
            C.ShowDialog();
            actualizar();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
            SqlCommand comando2 = new SqlCommand("delete COMPRA", con);
            comando2.CommandType = CommandType.Text;
            con.Open();
            comando2.ExecuteNonQuery();
            con.Close();
        }
    }
}
