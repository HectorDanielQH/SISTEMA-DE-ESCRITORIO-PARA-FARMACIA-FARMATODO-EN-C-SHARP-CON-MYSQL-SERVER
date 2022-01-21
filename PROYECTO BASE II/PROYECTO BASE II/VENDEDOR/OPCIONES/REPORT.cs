using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_BASE_II.VENDEDOR.OPCIONES
{
    public partial class REPORT : Form
    {
        String ci_cli, ci_ven;
        public REPORT()
        {
            InitializeComponent();
        }
        public void obten(String cli,String vende)
        {
            ci_cli = cli;
            ci_ven = vende;
        }

        private void CrystalReport11_InitReport(object sender, EventArgs e)
        {

        }

        private void REPORT_Load(object sender, EventArgs e)
        {
            CrystalReport1 nue = new CrystalReport1();
            nue.SetParameterValue("@ci_cli", ci_cli);
            nue.SetParameterValue("@ci_vende", ci_ven);
            crystalReportViewer2.ReportSource = nue;
        }
    }
}
