namespace APF_3._0
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.filmyDataGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spotyDataGrid = new System.Windows.Forms.DataGridView();
            this.Odebrat = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Film = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Začátek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Konec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ulozitButton = new System.Windows.Forms.Button();
            this.databazeButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.posunCasuTextBox = new System.Windows.Forms.TextBox();
            this.tridaDBTextBox = new System.Windows.Forms.TextBox();
            this.denDBTextBox = new System.Windows.Forms.TextBox();
            this.configButton = new System.Windows.Forms.Button();
            this.komunikacniLabel = new System.Windows.Forms.Label();
            this.testFilmuButton = new System.Windows.Forms.Button();
            this.databazeGroupBox = new System.Windows.Forms.GroupBox();
            this.dbTridaLabel = new System.Windows.Forms.Label();
            this.dbDenLabel = new System.Windows.Forms.Label();
            this.posunCasuLabel = new System.Windows.Forms.Label();
            this.nastaveniGroupBox = new System.Windows.Forms.GroupBox();
            this.konecButton = new System.Windows.Forms.Button();
            this.cisteniKomunikacnihoLabeluButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.filmyDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spotyDataGrid)).BeginInit();
            this.databazeGroupBox.SuspendLayout();
            this.nastaveniGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // filmyDataGrid
            // 
            this.filmyDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.filmyDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.filmyDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filmyDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.filmyDataGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.filmyDataGrid.Location = new System.Drawing.Point(12, 289);
            this.filmyDataGrid.Name = "filmyDataGrid";
            this.filmyDataGrid.RowHeadersVisible = false;
            this.filmyDataGrid.RowTemplate.Height = 30;
            this.filmyDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.filmyDataGrid.ShowRowErrors = false;
            this.filmyDataGrid.Size = new System.Drawing.Size(618, 208);
            this.filmyDataGrid.TabIndex = 1;
            this.filmyDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.filmyDataGrid_CellContentClick);
            this.filmyDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.filmyDataGrid_CellEndEdit);
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewButtonColumn1.HeaderText = "Odebrat";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ToolTipText = "Odebere film z programu";
            this.dataGridViewButtonColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "Film";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Klikněte pro výběr filmu";
            this.dataGridViewTextBoxColumn1.Width = 340;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "Začátek";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ToolTipText = "h/m/s";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.HeaderText = "Konec";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // spotyDataGrid
            // 
            this.spotyDataGrid.AllowUserToDeleteRows = false;
            this.spotyDataGrid.AllowUserToResizeRows = false;
            this.spotyDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.spotyDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.spotyDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spotyDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Odebrat,
            this.Film,
            this.Začátek,
            this.Konec});
            this.spotyDataGrid.Location = new System.Drawing.Point(12, 165);
            this.spotyDataGrid.Name = "spotyDataGrid";
            this.spotyDataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.spotyDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.spotyDataGrid.RowTemplate.Height = 30;
            this.spotyDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.spotyDataGrid.ShowRowErrors = false;
            this.spotyDataGrid.Size = new System.Drawing.Size(618, 118);
            this.spotyDataGrid.TabIndex = 0;
            this.spotyDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.spotyDataGrid_CellContentClick);
            this.spotyDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.spotyDataGrid_CellEndEdit);
            // 
            // Odebrat
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Odebrat.DefaultCellStyle = dataGridViewCellStyle8;
            this.Odebrat.HeaderText = "Odebrat";
            this.Odebrat.Name = "Odebrat";
            this.Odebrat.ToolTipText = "Odebere spot z programu";
            this.Odebrat.Width = 75;
            // 
            // Film
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Film.DefaultCellStyle = dataGridViewCellStyle9;
            this.Film.HeaderText = "Film";
            this.Film.Name = "Film";
            this.Film.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Film.ToolTipText = "Klikni pro výběr filmu";
            this.Film.Width = 340;
            // 
            // Začátek
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Začátek.DefaultCellStyle = dataGridViewCellStyle10;
            this.Začátek.HeaderText = "Začátek";
            this.Začátek.Name = "Začátek";
            this.Začátek.ToolTipText = "h/m/s";
            // 
            // Konec
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Konec.DefaultCellStyle = dataGridViewCellStyle11;
            this.Konec.HeaderText = "Konec";
            this.Konec.Name = "Konec";
            this.Konec.ReadOnly = true;
            // 
            // ulozitButton
            // 
            this.ulozitButton.Location = new System.Drawing.Point(468, 43);
            this.ulozitButton.Name = "ulozitButton";
            this.ulozitButton.Size = new System.Drawing.Size(150, 28);
            this.ulozitButton.TabIndex = 2;
            this.ulozitButton.Text = "Uložit";
            this.ulozitButton.UseVisualStyleBackColor = true;
            this.ulozitButton.Click += new System.EventHandler(this.ulozitButton_Click);
            // 
            // databazeButton
            // 
            this.databazeButton.Location = new System.Drawing.Point(418, 43);
            this.databazeButton.Name = "databazeButton";
            this.databazeButton.Size = new System.Drawing.Size(200, 28);
            this.databazeButton.TabIndex = 62;
            this.databazeButton.Text = "Fetch";
            this.databazeButton.UseVisualStyleBackColor = true;
            this.databazeButton.Click += new System.EventHandler(this.databazeButton_Click);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startButton.Location = new System.Drawing.Point(636, 10);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 150);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start přehrávání";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // posunCasuTextBox
            // 
            this.posunCasuTextBox.Location = new System.Drawing.Point(6, 44);
            this.posunCasuTextBox.Name = "posunCasuTextBox";
            this.posunCasuTextBox.Size = new System.Drawing.Size(148, 26);
            this.posunCasuTextBox.TabIndex = 5;
            this.posunCasuTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.posunCasuTextBox_KeyDown);
            // 
            // tridaDBTextBox
            // 
            this.tridaDBTextBox.Location = new System.Drawing.Point(212, 44);
            this.tridaDBTextBox.Name = "tridaDBTextBox";
            this.tridaDBTextBox.Size = new System.Drawing.Size(200, 26);
            this.tridaDBTextBox.TabIndex = 61;
            // 
            // denDBTextBox
            // 
            this.denDBTextBox.Location = new System.Drawing.Point(6, 44);
            this.denDBTextBox.Name = "denDBTextBox";
            this.denDBTextBox.Size = new System.Drawing.Size(200, 26);
            this.denDBTextBox.TabIndex = 60;
            // 
            // configButton
            // 
            this.configButton.Location = new System.Drawing.Point(160, 43);
            this.configButton.Name = "configButton";
            this.configButton.Size = new System.Drawing.Size(148, 28);
            this.configButton.TabIndex = 8;
            this.configButton.Text = "Config";
            this.configButton.UseVisualStyleBackColor = true;
            this.configButton.Click += new System.EventHandler(this.configButton_Click);
            // 
            // komunikacniLabel
            // 
            this.komunikacniLabel.AutoSize = true;
            this.komunikacniLabel.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.komunikacniLabel.Location = new System.Drawing.Point(636, 197);
            this.komunikacniLabel.MaximumSize = new System.Drawing.Size(450, 0);
            this.komunikacniLabel.Name = "komunikacniLabel";
            this.komunikacniLabel.Size = new System.Drawing.Size(42, 18);
            this.komunikacniLabel.TabIndex = 63;
            this.komunikacniLabel.Text = "Info:";
            // 
            // testFilmuButton
            // 
            this.testFilmuButton.Location = new System.Drawing.Point(314, 43);
            this.testFilmuButton.Name = "testFilmuButton";
            this.testFilmuButton.Size = new System.Drawing.Size(148, 28);
            this.testFilmuButton.TabIndex = 64;
            this.testFilmuButton.Text = "Test filmů";
            this.testFilmuButton.UseVisualStyleBackColor = true;
            this.testFilmuButton.Click += new System.EventHandler(this.testFilmuButton_Click);
            // 
            // databazeGroupBox
            // 
            this.databazeGroupBox.Controls.Add(this.dbTridaLabel);
            this.databazeGroupBox.Controls.Add(this.dbDenLabel);
            this.databazeGroupBox.Controls.Add(this.denDBTextBox);
            this.databazeGroupBox.Controls.Add(this.tridaDBTextBox);
            this.databazeGroupBox.Controls.Add(this.databazeButton);
            this.databazeGroupBox.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.databazeGroupBox.Location = new System.Drawing.Point(12, 10);
            this.databazeGroupBox.Name = "databazeGroupBox";
            this.databazeGroupBox.Size = new System.Drawing.Size(618, 72);
            this.databazeGroupBox.TabIndex = 65;
            this.databazeGroupBox.TabStop = false;
            this.databazeGroupBox.Text = "Databáze";
            // 
            // dbTridaLabel
            // 
            this.dbTridaLabel.AutoSize = true;
            this.dbTridaLabel.Location = new System.Drawing.Point(212, 23);
            this.dbTridaLabel.Name = "dbTridaLabel";
            this.dbTridaLabel.Size = new System.Drawing.Size(52, 18);
            this.dbTridaLabel.TabIndex = 64;
            this.dbTridaLabel.Text = "Třída:";
            // 
            // dbDenLabel
            // 
            this.dbDenLabel.AutoSize = true;
            this.dbDenLabel.Location = new System.Drawing.Point(6, 23);
            this.dbDenLabel.Name = "dbDenLabel";
            this.dbDenLabel.Size = new System.Drawing.Size(41, 18);
            this.dbDenLabel.TabIndex = 63;
            this.dbDenLabel.Text = "Den:";
            // 
            // posunCasuLabel
            // 
            this.posunCasuLabel.AutoSize = true;
            this.posunCasuLabel.Location = new System.Drawing.Point(6, 22);
            this.posunCasuLabel.Name = "posunCasuLabel";
            this.posunCasuLabel.Size = new System.Drawing.Size(91, 18);
            this.posunCasuLabel.TabIndex = 66;
            this.posunCasuLabel.Text = "Posun časů:";
            // 
            // nastaveniGroupBox
            // 
            this.nastaveniGroupBox.Controls.Add(this.posunCasuLabel);
            this.nastaveniGroupBox.Controls.Add(this.posunCasuTextBox);
            this.nastaveniGroupBox.Controls.Add(this.testFilmuButton);
            this.nastaveniGroupBox.Controls.Add(this.configButton);
            this.nastaveniGroupBox.Controls.Add(this.ulozitButton);
            this.nastaveniGroupBox.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nastaveniGroupBox.Location = new System.Drawing.Point(12, 86);
            this.nastaveniGroupBox.Name = "nastaveniGroupBox";
            this.nastaveniGroupBox.Size = new System.Drawing.Size(618, 72);
            this.nastaveniGroupBox.TabIndex = 67;
            this.nastaveniGroupBox.TabStop = false;
            this.nastaveniGroupBox.Text = "Nastavení";
            // 
            // konecButton
            // 
            this.konecButton.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.konecButton.Location = new System.Drawing.Point(792, 10);
            this.konecButton.Name = "konecButton";
            this.konecButton.Size = new System.Drawing.Size(150, 150);
            this.konecButton.TabIndex = 68;
            this.konecButton.Text = "Konec přehrávání";
            this.konecButton.UseVisualStyleBackColor = true;
            this.konecButton.Click += new System.EventHandler(this.konecButton_Click);
            // 
            // cisteniKomunikacnihoLabeluButton
            // 
            this.cisteniKomunikacnihoLabeluButton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cisteniKomunikacnihoLabeluButton.Location = new System.Drawing.Point(636, 166);
            this.cisteniKomunikacnihoLabeluButton.Name = "cisteniKomunikacnihoLabeluButton";
            this.cisteniKomunikacnihoLabeluButton.Size = new System.Drawing.Size(150, 28);
            this.cisteniKomunikacnihoLabeluButton.TabIndex = 69;
            this.cisteniKomunikacnihoLabeluButton.Text = "Vyčistit info";
            this.cisteniKomunikacnihoLabeluButton.UseVisualStyleBackColor = true;
            this.cisteniKomunikacnihoLabeluButton.Click += new System.EventHandler(this.cisteniKomunikacnihoLabeluButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 506);
            this.Controls.Add(this.cisteniKomunikacnihoLabeluButton);
            this.Controls.Add(this.konecButton);
            this.Controls.Add(this.nastaveniGroupBox);
            this.Controls.Add(this.databazeGroupBox);
            this.Controls.Add(this.komunikacniLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.filmyDataGrid);
            this.Controls.Add(this.spotyDataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Automatické přehrávání filmů";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.filmyDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spotyDataGrid)).EndInit();
            this.databazeGroupBox.ResumeLayout(false);
            this.databazeGroupBox.PerformLayout();
            this.nastaveniGroupBox.ResumeLayout(false);
            this.nastaveniGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView filmyDataGrid;
        private System.Windows.Forms.DataGridView spotyDataGrid;
        private System.Windows.Forms.Button ulozitButton;
        private System.Windows.Forms.Button databazeButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox posunCasuTextBox;
        private System.Windows.Forms.TextBox tridaDBTextBox;
        private System.Windows.Forms.TextBox denDBTextBox;
        private System.Windows.Forms.Button configButton;
        private System.Windows.Forms.Label komunikacniLabel;
        private System.Windows.Forms.Button testFilmuButton;
        private System.Windows.Forms.GroupBox databazeGroupBox;
        private System.Windows.Forms.Label dbTridaLabel;
        private System.Windows.Forms.Label dbDenLabel;
        private System.Windows.Forms.Label posunCasuLabel;
        private System.Windows.Forms.GroupBox nastaveniGroupBox;
        private System.Windows.Forms.Button konecButton;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewButtonColumn Odebrat;
        private System.Windows.Forms.DataGridViewButtonColumn Film;
        private System.Windows.Forms.DataGridViewTextBoxColumn Začátek;
        private System.Windows.Forms.DataGridViewTextBoxColumn Konec;
        private System.Windows.Forms.Button cisteniKomunikacnihoLabeluButton;
    }
}

