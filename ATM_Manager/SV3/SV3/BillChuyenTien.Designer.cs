﻿namespace SV3
{
    partial class BillChuyenTien
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ATMManagerDataSet = new SV3.ATMManagerDataSet();
            this.tblAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblAccountTableAdapter = new SV3.ATMManagerDataSetTableAdapters.tblAccountTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ATMManagerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tblAccountBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SV3.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(513, 589);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // ATMManagerDataSet
            // 
            this.ATMManagerDataSet.DataSetName = "ATMManagerDataSet";
            this.ATMManagerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblAccountBindingSource
            // 
            this.tblAccountBindingSource.DataMember = "tblAccount";
            this.tblAccountBindingSource.DataSource = this.ATMManagerDataSet;
            // 
            // tblAccountTableAdapter
            // 
            this.tblAccountTableAdapter.ClearBeforeFill = true;
            // 
            // BillChuyenTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 591);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BillChuyenTien";
            this.Text = "BillChuyenTien";
            this.Load += new System.EventHandler(this.BillChuyenTien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ATMManagerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tblAccountBindingSource;
        private ATMManagerDataSet ATMManagerDataSet;
        private ATMManagerDataSetTableAdapters.tblAccountTableAdapter tblAccountTableAdapter;
    }
}