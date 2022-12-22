namespace ServiceAboutTaxi
{
    partial class AdminPriceForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.serviceAboutTaxiDataSet = new ServiceAboutTaxi.ServiceAboutTaxiDataSet();
            this.pricesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pricesTableAdapter = new ServiceAboutTaxi.ServiceAboutTaxiDataSetTableAdapters.PricesTableAdapter();
            this.priceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carClassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricePerKiloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceForRideDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceAboutTaxiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pricesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(74, 26);
            this.logOutToolStripMenuItem.Text = "Log out";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.priceIDDataGridViewTextBoxColumn,
            this.carClassDataGridViewTextBoxColumn,
            this.pricePerKiloDataGridViewTextBoxColumn,
            this.priceForRideDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.pricesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(802, 137);
            this.dataGridView1.TabIndex = 2;
            // 
            // serviceAboutTaxiDataSet
            // 
            this.serviceAboutTaxiDataSet.DataSetName = "ServiceAboutTaxiDataSet";
            this.serviceAboutTaxiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pricesBindingSource
            // 
            this.pricesBindingSource.DataMember = "Prices";
            this.pricesBindingSource.DataSource = this.serviceAboutTaxiDataSet;
            // 
            // pricesTableAdapter
            // 
            this.pricesTableAdapter.ClearBeforeFill = true;
            // 
            // priceIDDataGridViewTextBoxColumn
            // 
            this.priceIDDataGridViewTextBoxColumn.DataPropertyName = "PriceID";
            this.priceIDDataGridViewTextBoxColumn.HeaderText = "PriceID";
            this.priceIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.priceIDDataGridViewTextBoxColumn.Name = "priceIDDataGridViewTextBoxColumn";
            this.priceIDDataGridViewTextBoxColumn.Visible = false;
            this.priceIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // carClassDataGridViewTextBoxColumn
            // 
            this.carClassDataGridViewTextBoxColumn.DataPropertyName = "CarClass";
            this.carClassDataGridViewTextBoxColumn.HeaderText = "Клас авто";
            this.carClassDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.carClassDataGridViewTextBoxColumn.Name = "carClassDataGridViewTextBoxColumn";
            this.carClassDataGridViewTextBoxColumn.Width = 125;
            // 
            // pricePerKiloDataGridViewTextBoxColumn
            // 
            this.pricePerKiloDataGridViewTextBoxColumn.DataPropertyName = "PricePerKilo";
            this.pricePerKiloDataGridViewTextBoxColumn.HeaderText = "Ціна за кілометр";
            this.pricePerKiloDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pricePerKiloDataGridViewTextBoxColumn.Name = "pricePerKiloDataGridViewTextBoxColumn";
            this.pricePerKiloDataGridViewTextBoxColumn.Width = 125;
            // 
            // priceForRideDataGridViewTextBoxColumn
            // 
            this.priceForRideDataGridViewTextBoxColumn.DataPropertyName = "PriceForRide";
            this.priceForRideDataGridViewTextBoxColumn.HeaderText = "Ціна за заказ";
            this.priceForRideDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.priceForRideDataGridViewTextBoxColumn.Name = "priceForRideDataGridViewTextBoxColumn";
            this.priceForRideDataGridViewTextBoxColumn.Width = 125;
            // 
            // AdminPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminPriceForm";
            this.Text = "AdminPriceForm";
            this.Load += new System.EventHandler(this.AdminPriceForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceAboutTaxiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pricesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ServiceAboutTaxiDataSet serviceAboutTaxiDataSet;
        private System.Windows.Forms.BindingSource pricesBindingSource;
        private ServiceAboutTaxiDataSetTableAdapters.PricesTableAdapter pricesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn carClassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricePerKiloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceForRideDataGridViewTextBoxColumn;
    }
}