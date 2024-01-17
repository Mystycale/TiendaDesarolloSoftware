using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCaja
{
    public partial class FormReporte : Form
    {
        public FormReporte()
        {
            InitializeComponent();
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {

            SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);

            sql.Open();

            SqlCommand command = new SqlCommand("ObtenerUltimaFactura", sql);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter reportDBTableAdapter = new SqlDataAdapter(command);

            DataTable polinaDBDataSet = new DataTable();
            reportDBTableAdapter.Fill(polinaDBDataSet);
            sql.Close();

            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.ReportPath = @"C:\Users\SnowyFox\Source\Repos\Mystycale\TiendaDesarolloSoftware\ProyectoCaja\Informe.rdlc";
            ReportDataSource rds = new ReportDataSource("DataSetFactura", polinaDBDataSet);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
