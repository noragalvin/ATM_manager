namespace GUIs
{
    partial class BillSaoKe
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
            this.tblLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ATMManagerDataSet = new GUIs.ATMManagerDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tblLogTableAdapter = new GUIs.ATMManagerDataSetTableAdapters.tblLogTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tblLogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ATMManagerDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tblLogBindingSource
            // 
            this.tblLogBindingSource.DataMember = "tblLog";
            this.tblLogBindingSource.DataSource = this.ATMManagerDataSet;
            // 
            // ATMManagerDataSet
            // 
            this.ATMManagerDataSet.DataSetName = "ATMManagerDataSet";
            this.ATMManagerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "LogData";
            reportDataSource1.Value = this.tblLogBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GUIs.ReportSaoKe.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, -1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(496, 552);
            this.reportViewer1.TabIndex = 0;
            // 
            // tblLogTableAdapter
            // 
            this.tblLogTableAdapter.ClearBeforeFill = true;
            // 
            // BillSaoKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 551);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BillSaoKe";
            this.Text = "BillSaoKe";
            this.Load += new System.EventHandler(this.BillSaoKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblLogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ATMManagerDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tblLogBindingSource;
        private ATMManagerDataSet ATMManagerDataSet;
        private ATMManagerDataSetTableAdapters.tblLogTableAdapter tblLogTableAdapter;
    }
}