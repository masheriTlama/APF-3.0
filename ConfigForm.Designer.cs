namespace APF_3._0
{
    partial class ConfigForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.ulozitConfigButton = new System.Windows.Forms.Button();
            this.configDataGrid = new System.Windows.Forms.DataGridView();
            this.Klíč = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hodnota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.configDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ulozitConfigButton
            // 
            this.ulozitConfigButton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ulozitConfigButton.Location = new System.Drawing.Point(8, 256);
            this.ulozitConfigButton.Name = "ulozitConfigButton";
            this.ulozitConfigButton.Size = new System.Drawing.Size(75, 26);
            this.ulozitConfigButton.TabIndex = 1;
            this.ulozitConfigButton.Text = "Uložit";
            this.ulozitConfigButton.UseVisualStyleBackColor = true;
            this.ulozitConfigButton.Click += new System.EventHandler(this.ulozitConfigButton_Click);
            // 
            // configDataGrid
            // 
            this.configDataGrid.AllowUserToAddRows = false;
            this.configDataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.configDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.configDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.configDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Klíč,
            this.Hodnota});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.configDataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.configDataGrid.Location = new System.Drawing.Point(8, 12);
            this.configDataGrid.Name = "configDataGrid";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.configDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.configDataGrid.RowHeadersVisible = false;
            this.configDataGrid.RowTemplate.Height = 30;
            this.configDataGrid.Size = new System.Drawing.Size(894, 238);
            this.configDataGrid.TabIndex = 2;
            this.configDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.configDataGrid_CellDoubleClick);
            // 
            // Klíč
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Klíč.DefaultCellStyle = dataGridViewCellStyle2;
            this.Klíč.HeaderText = "Klíč";
            this.Klíč.Name = "Klíč";
            this.Klíč.Width = 250;
            // 
            // Hodnota
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Hodnota.DefaultCellStyle = dataGridViewCellStyle3;
            this.Hodnota.HeaderText = "Hodnota";
            this.Hodnota.Name = "Hodnota";
            this.Hodnota.Width = 641;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 288);
            this.Controls.Add(this.configDataGrid);
            this.Controls.Add(this.ulozitConfigButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.Text = "Konfigurace";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.configDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ulozitConfigButton;
        private System.Windows.Forms.DataGridView configDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klíč;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hodnota;
    }
}