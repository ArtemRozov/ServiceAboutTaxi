namespace ServiceAboutTaxi
{
    partial class UserForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAddresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endAddresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startOrderTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endOrderTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carDeliveryTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfPassengersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serviceAboutTaxiDataSet = new ServiceAboutTaxi.ServiceAboutTaxiDataSet();
            this.ordersTableAdapter = new ServiceAboutTaxi.ServiceAboutTaxiDataSetTableAdapters.OrdersTableAdapter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceAboutTaxiDataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1007, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "Зробити замовлення";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIDDataGridViewTextBoxColumn,
            this.startAddresDataGridViewTextBoxColumn,
            this.endAddresDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.orderStateDataGridViewTextBoxColumn,
            this.orderTimeDataGridViewTextBoxColumn,
            this.startOrderTimeDataGridViewTextBoxColumn,
            this.endOrderTimeDataGridViewTextBoxColumn,
            this.carDeliveryTimeDataGridViewTextBoxColumn,
            this.numberOfPassengersDataGridViewTextBoxColumn,
            this.carIDDataGridViewTextBoxColumn,
            this.clientIDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.ordersBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(5, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1180, 228);
            this.dataGridView1.TabIndex = 1;
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            this.orderIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderIDDataGridViewTextBoxColumn.Visible = false;
            this.orderIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // startAddresDataGridViewTextBoxColumn
            // 
            this.startAddresDataGridViewTextBoxColumn.DataPropertyName = "StartAddres";
            this.startAddresDataGridViewTextBoxColumn.HeaderText = "Початкова адреса";
            this.startAddresDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.startAddresDataGridViewTextBoxColumn.Name = "startAddresDataGridViewTextBoxColumn";
            this.startAddresDataGridViewTextBoxColumn.ReadOnly = true;
            this.startAddresDataGridViewTextBoxColumn.Width = 125;
            // 
            // endAddresDataGridViewTextBoxColumn
            // 
            this.endAddresDataGridViewTextBoxColumn.DataPropertyName = "EndAddres";
            this.endAddresDataGridViewTextBoxColumn.HeaderText = "Кінцева адреса";
            this.endAddresDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.endAddresDataGridViewTextBoxColumn.Name = "endAddresDataGridViewTextBoxColumn";
            this.endAddresDataGridViewTextBoxColumn.ReadOnly = true;
            this.endAddresDataGridViewTextBoxColumn.Width = 125;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Ціна";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 125;
            // 
            // orderStateDataGridViewTextBoxColumn
            // 
            this.orderStateDataGridViewTextBoxColumn.DataPropertyName = "OrderState";
            this.orderStateDataGridViewTextBoxColumn.HeaderText = "Стан заказу";
            this.orderStateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderStateDataGridViewTextBoxColumn.Name = "orderStateDataGridViewTextBoxColumn";
            this.orderStateDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderStateDataGridViewTextBoxColumn.Width = 125;
            // 
            // orderTimeDataGridViewTextBoxColumn
            // 
            this.orderTimeDataGridViewTextBoxColumn.DataPropertyName = "OrderTime";
            this.orderTimeDataGridViewTextBoxColumn.HeaderText = "Час заказу";
            this.orderTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderTimeDataGridViewTextBoxColumn.Name = "orderTimeDataGridViewTextBoxColumn";
            this.orderTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // startOrderTimeDataGridViewTextBoxColumn
            // 
            this.startOrderTimeDataGridViewTextBoxColumn.DataPropertyName = "StartOrderTime";
            this.startOrderTimeDataGridViewTextBoxColumn.HeaderText = "Початковий час заказу";
            this.startOrderTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.startOrderTimeDataGridViewTextBoxColumn.Name = "startOrderTimeDataGridViewTextBoxColumn";
            this.startOrderTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.startOrderTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // endOrderTimeDataGridViewTextBoxColumn
            // 
            this.endOrderTimeDataGridViewTextBoxColumn.DataPropertyName = "EndOrderTime";
            this.endOrderTimeDataGridViewTextBoxColumn.HeaderText = "Кінцевий час заказу";
            this.endOrderTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.endOrderTimeDataGridViewTextBoxColumn.Name = "endOrderTimeDataGridViewTextBoxColumn";
            this.endOrderTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.endOrderTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // carDeliveryTimeDataGridViewTextBoxColumn
            // 
            this.carDeliveryTimeDataGridViewTextBoxColumn.DataPropertyName = "CarDeliveryTime";
            this.carDeliveryTimeDataGridViewTextBoxColumn.HeaderText = "Час подачі авто";
            this.carDeliveryTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.carDeliveryTimeDataGridViewTextBoxColumn.Name = "carDeliveryTimeDataGridViewTextBoxColumn";
            this.carDeliveryTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.carDeliveryTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // numberOfPassengersDataGridViewTextBoxColumn
            // 
            this.numberOfPassengersDataGridViewTextBoxColumn.DataPropertyName = "NumberOfPassengers";
            this.numberOfPassengersDataGridViewTextBoxColumn.HeaderText = "Кількість пасажирів";
            this.numberOfPassengersDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numberOfPassengersDataGridViewTextBoxColumn.Name = "numberOfPassengersDataGridViewTextBoxColumn";
            this.numberOfPassengersDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberOfPassengersDataGridViewTextBoxColumn.Width = 125;
            // 
            // carIDDataGridViewTextBoxColumn
            // 
            this.carIDDataGridViewTextBoxColumn.DataPropertyName = "CarID";
            this.carIDDataGridViewTextBoxColumn.HeaderText = "CarID";
            this.carIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.carIDDataGridViewTextBoxColumn.Name = "carIDDataGridViewTextBoxColumn";
            this.carIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.carIDDataGridViewTextBoxColumn.Visible = false;
            this.carIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // clientIDDataGridViewTextBoxColumn
            // 
            this.clientIDDataGridViewTextBoxColumn.DataPropertyName = "ClientID";
            this.clientIDDataGridViewTextBoxColumn.HeaderText = "ClientID";
            this.clientIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.clientIDDataGridViewTextBoxColumn.Name = "clientIDDataGridViewTextBoxColumn";
            this.clientIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.clientIDDataGridViewTextBoxColumn.Visible = false;
            this.clientIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataMember = "Orders";
            this.ordersBindingSource.DataSource = this.serviceAboutTaxiDataSet;
            // 
            // serviceAboutTaxiDataSet
            // 
            this.serviceAboutTaxiDataSet.DataSetName = "ServiceAboutTaxiDataSet";
            this.serviceAboutTaxiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ordersTableAdapter
            // 
            this.ordersTableAdapter.ClearBeforeFill = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.profileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1183, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.profileToolStripMenuItem.Text = "Profile";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(832, 379);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 59);
            this.button2.TabIndex = 3;
            this.button2.Text = "Відмовитися від замовлення";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ваші закази";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(5, 389);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 49);
            this.button3.TabIndex = 5;
            this.button3.Text = "Поточний заказ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.Activated += new System.EventHandler(this.UserForm_Activated);
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceAboutTaxiDataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ServiceAboutTaxiDataSet serviceAboutTaxiDataSet;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private ServiceAboutTaxiDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAddresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endAddresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startOrderTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endOrderTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn carDeliveryTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfPassengersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn carIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
    }
}