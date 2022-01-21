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
    public partial class CONTROL_INGRESOS : Form
    {
        public CONTROL_INGRESOS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                SqlCommand comando = new SqlCommand("arqueo", con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@da", SqlDbType.Date);
                comando.Parameters[0].Value = dateTimePicker1.Value.ToShortDateString();
                SqlDataAdapter adp = new SqlDataAdapter(comando);
                DataSet dap = new DataSet();
                adp.Fill(dap);
                dataGridView1.DataSource = dap.Tables[0];

                SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ToString());
                SqlCommand coman = new SqlCommand("arqueo_solo", cone);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.Add("@da", SqlDbType.Date);
                coman.Parameters[0].Value = dateTimePicker1.Value.ToShortDateString();
                cone.Open();
                SqlDataReader ad = coman.ExecuteReader();
                while(ad.Read())
                {
                    textBox1.Text = ad[0].ToString();
                }
                cone.Close();
            }
            catch(SqlException s)
            {
                MessageBox.Show(s.Message);
            }
        }
    }
}
