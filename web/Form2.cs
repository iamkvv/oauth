using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace web
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "formsDemoDataSet.Visits". При необходимости она может быть перемещена или удалена.
            this.visitsTableAdapter.Fill(this.formsDemoDataSet.Visits);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "formsDemoDataSet.Cities". При необходимости она может быть перемещена или удалена.
            this.CitiesTableAdapter.Fill(this.formsDemoDataSet.Cities);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_ldb___копия_beDataSet.тТипДоговора". При необходимости она может быть перемещена или удалена.
            this.тТипДоговораTableAdapter.Fill(this._ldb___копия_beDataSet.тТипДоговора);

            this.reportViewer1.LocalReport.EnableHyperlinks = true;

            this.reportViewer1.RefreshReport();
        }
    }
}
