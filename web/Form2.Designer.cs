namespace web
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.тТипДоговораBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._ldb___копия_beDataSet = new web._ldb___копия_beDataSet();
            this.CitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formsDemoDataSet = new web.FormsDemoDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.тТипДоговораTableAdapter = new web._ldb___копия_beDataSetTableAdapters.тТипДоговораTableAdapter();
            this.formsDemoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CitiesTableAdapter = new web.FormsDemoDataSetTableAdapters.CitiesTableAdapter();
            this.visitsTableAdapter = new web.FormsDemoDataSetTableAdapters.VisitsTableAdapter();
            this.visitsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.тТипДоговораBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ldb___копия_beDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CitiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formsDemoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formsDemoDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // тТипДоговораBindingSource
            // 
            this.тТипДоговораBindingSource.DataMember = "тТипДоговора";
            this.тТипДоговораBindingSource.DataSource = this._ldb___копия_beDataSet;
            // 
            // _ldb___копия_beDataSet
            // 
            this._ldb___копия_beDataSet.DataSetName = "_ldb___копия_beDataSet";
            this._ldb___копия_beDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CitiesBindingSource
            // 
            this.CitiesBindingSource.DataMember = "Cities";
            this.CitiesBindingSource.DataSource = this.formsDemoDataSet;
            // 
            // formsDemoDataSet
            // 
            this.formsDemoDataSet.DataSetName = "FormsDemoDataSet";
            this.formsDemoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.тТипДоговораBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.CitiesBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.visitsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "web.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(977, 239);
            this.reportViewer1.TabIndex = 0;
            // 
            // тТипДоговораTableAdapter
            // 
            this.тТипДоговораTableAdapter.ClearBeforeFill = true;
            // 
            // formsDemoDataSetBindingSource
            // 
            this.formsDemoDataSetBindingSource.DataSource = this.formsDemoDataSet;
            this.formsDemoDataSetBindingSource.Position = 0;
            // 
            // CitiesTableAdapter
            // 
            this.CitiesTableAdapter.ClearBeforeFill = true;
            // 
            // visitsTableAdapter
            // 
            this.visitsTableAdapter.ClearBeforeFill = true;
            // 
            // visitsBindingSource
            // 
            this.visitsBindingSource.DataMember = "Visits";
            this.visitsBindingSource.DataSource = this.formsDemoDataSet;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 253);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.тТипДоговораBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ldb___копия_beDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CitiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formsDemoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formsDemoDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource тТипДоговораBindingSource;
        private _ldb___копия_beDataSet _ldb___копия_beDataSet;
        private _ldb___копия_beDataSetTableAdapters.тТипДоговораTableAdapter тТипДоговораTableAdapter;
        private System.Windows.Forms.BindingSource CitiesBindingSource;
        private FormsDemoDataSet formsDemoDataSet;
        private System.Windows.Forms.BindingSource formsDemoDataSetBindingSource;
        private FormsDemoDataSetTableAdapters.CitiesTableAdapter CitiesTableAdapter;
        private FormsDemoDataSetTableAdapters.VisitsTableAdapter visitsTableAdapter;
        private System.Windows.Forms.BindingSource visitsBindingSource;
    }
}