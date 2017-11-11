namespace FluentGenerator
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
            this.GWTables = new System.Windows.Forms.DataGridView();
            this.Sec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TABLE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OWNER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtListele = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.LBPath = new System.Windows.Forms.Label();
            this.BTKlasor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BTOlustur = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TBNameSpace = new System.Windows.Forms.TextBox();
            this.GWView = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TBTableName = new System.Windows.Forms.TextBox();
            this.TBViewName = new System.Windows.Forms.TextBox();
            this.BTTableNameAra = new System.Windows.Forms.Button();
            this.BTViewNameAra = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TBConString = new System.Windows.Forms.TextBox();
            this.BtConStrDegistir = new System.Windows.Forms.Button();
            this.GWSelectedView = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTAddTable = new System.Windows.Forms.Button();
            this.BtRemoveTable = new System.Windows.Forms.Button();
            this.BTRemoveView = new System.Windows.Forms.Button();
            this.BTAddView = new System.Windows.Forms.Button();
            this.GWSelectedTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RbPascal = new System.Windows.Forms.RadioButton();
            this.RbCamel = new System.Windows.Forms.RadioButton();
            this.RbUpper = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.GWTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GWView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GWSelectedView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GWSelectedTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GWTables
            // 
            this.GWTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GWTables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sec,
            this.TABLE_NAME,
            this.OWNER});
            this.GWTables.Location = new System.Drawing.Point(12, 72);
            this.GWTables.Name = "GWTables";
            this.GWTables.RowTemplate.Height = 24;
            this.GWTables.Size = new System.Drawing.Size(656, 310);
            this.GWTables.TabIndex = 0;
            // 
            // Sec
            // 
            this.Sec.HeaderText = "CH";
            this.Sec.Name = "Sec";
            // 
            // TABLE_NAME
            // 
            this.TABLE_NAME.DataPropertyName = "TABLE_NAME";
            this.TABLE_NAME.HeaderText = "TABLE_NAME";
            this.TABLE_NAME.Name = "TABLE_NAME";
            this.TABLE_NAME.Width = 300;
            // 
            // OWNER
            // 
            this.OWNER.DataPropertyName = "OWNER";
            this.OWNER.HeaderText = "OWNER";
            this.OWNER.Name = "OWNER";
            // 
            // BtListele
            // 
            this.BtListele.Location = new System.Drawing.Point(964, 786);
            this.BtListele.Name = "BtListele";
            this.BtListele.Size = new System.Drawing.Size(102, 23);
            this.BtListele.TabIndex = 1;
            this.BtListele.Text = "LIST";
            this.BtListele.UseVisualStyleBackColor = true;
            this.BtListele.Click += new System.EventHandler(this.BtListele_Click);
            // 
            // LBPath
            // 
            this.LBPath.AutoSize = true;
            this.LBPath.Location = new System.Drawing.Point(100, 850);
            this.LBPath.Name = "LBPath";
            this.LBPath.Size = new System.Drawing.Size(12, 17);
            this.LBPath.TabIndex = 2;
            this.LBPath.Text = ".";
            // 
            // BTKlasor
            // 
            this.BTKlasor.Location = new System.Drawing.Point(833, 816);
            this.BTKlasor.Name = "BTKlasor";
            this.BTKlasor.Size = new System.Drawing.Size(102, 23);
            this.BTKlasor.TabIndex = 3;
            this.BTKlasor.Text = "DIR";
            this.BTKlasor.UseVisualStyleBackColor = true;
            this.BTKlasor.Click += new System.EventHandler(this.BTKlasor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 850);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dir:";
            // 
            // BTOlustur
            // 
            this.BTOlustur.Location = new System.Drawing.Point(833, 848);
            this.BTOlustur.Name = "BTOlustur";
            this.BTOlustur.Size = new System.Drawing.Size(102, 23);
            this.BTOlustur.TabIndex = 5;
            this.BTOlustur.Text = "CREATE";
            this.BTOlustur.UseVisualStyleBackColor = true;
            this.BTOlustur.Click += new System.EventHandler(this.BTOlustur_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 819);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name Space:";
            // 
            // TBNameSpace
            // 
            this.TBNameSpace.Location = new System.Drawing.Point(103, 816);
            this.TBNameSpace.Name = "TBNameSpace";
            this.TBNameSpace.Size = new System.Drawing.Size(724, 22);
            this.TBNameSpace.TabIndex = 7;
            // 
            // GWView
            // 
            this.GWView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GWView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.Column1});
            this.GWView.Location = new System.Drawing.Point(12, 448);
            this.GWView.Name = "GWView";
            this.GWView.RowTemplate.Height = 24;
            this.GWView.Size = new System.Drawing.Size(656, 309);
            this.GWView.TabIndex = 8;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "CH";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "VIEW_NAME";
            this.dataGridViewTextBoxColumn1.HeaderText = "VIEW_NAME";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 300;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "OWNER";
            this.Column1.HeaderText = "OWNER";
            this.Column1.Name = "Column1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 412);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "VIEW_NAME:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "TABLE_NAME:";
            // 
            // TBTableName
            // 
            this.TBTableName.Location = new System.Drawing.Point(121, 25);
            this.TBTableName.Name = "TBTableName";
            this.TBTableName.Size = new System.Drawing.Size(706, 22);
            this.TBTableName.TabIndex = 13;
            // 
            // TBViewName
            // 
            this.TBViewName.Location = new System.Drawing.Point(121, 409);
            this.TBViewName.Name = "TBViewName";
            this.TBViewName.Size = new System.Drawing.Size(706, 22);
            this.TBViewName.TabIndex = 14;
            // 
            // BTTableNameAra
            // 
            this.BTTableNameAra.Location = new System.Drawing.Point(833, 25);
            this.BTTableNameAra.Name = "BTTableNameAra";
            this.BTTableNameAra.Size = new System.Drawing.Size(95, 23);
            this.BTTableNameAra.TabIndex = 15;
            this.BTTableNameAra.Text = "SRC";
            this.BTTableNameAra.UseVisualStyleBackColor = true;
            this.BTTableNameAra.Click += new System.EventHandler(this.BTTableNameAra_Click);
            // 
            // BTViewNameAra
            // 
            this.BTViewNameAra.Location = new System.Drawing.Point(833, 409);
            this.BTViewNameAra.Name = "BTViewNameAra";
            this.BTViewNameAra.Size = new System.Drawing.Size(95, 23);
            this.BTViewNameAra.TabIndex = 16;
            this.BTViewNameAra.Text = "SRC";
            this.BTViewNameAra.UseVisualStyleBackColor = true;
            this.BTViewNameAra.Click += new System.EventHandler(this.BTViewNameAra_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 790);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Con. String:";
            // 
            // TBConString
            // 
            this.TBConString.Location = new System.Drawing.Point(103, 787);
            this.TBConString.Name = "TBConString";
            this.TBConString.Size = new System.Drawing.Size(724, 22);
            this.TBConString.TabIndex = 18;
            // 
            // BtConStrDegistir
            // 
            this.BtConStrDegistir.Location = new System.Drawing.Point(833, 787);
            this.BtConStrDegistir.Name = "BtConStrDegistir";
            this.BtConStrDegistir.Size = new System.Drawing.Size(102, 23);
            this.BtConStrDegistir.TabIndex = 19;
            this.BtConStrDegistir.Text = "CHANGE";
            this.BtConStrDegistir.UseVisualStyleBackColor = true;
            this.BtConStrDegistir.Click += new System.EventHandler(this.BtConStrDegistir_Click);
            // 
            // GWSelectedView
            // 
            this.GWSelectedView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GWSelectedView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn3,
            this.dataGridViewTextBoxColumn3,
            this.Column2});
            this.GWSelectedView.Location = new System.Drawing.Point(754, 448);
            this.GWSelectedView.Name = "GWSelectedView";
            this.GWSelectedView.RowTemplate.Height = 24;
            this.GWSelectedView.Size = new System.Drawing.Size(656, 309);
            this.GWSelectedView.TabIndex = 23;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.HeaderText = "CH";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "VIEW_NAME";
            this.dataGridViewTextBoxColumn3.HeaderText = "VIEW_NAME";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "OWNER";
            this.Column2.HeaderText = "OWNER";
            this.Column2.Name = "Column2";
            // 
            // BTAddTable
            // 
            this.BTAddTable.Location = new System.Drawing.Point(673, 182);
            this.BTAddTable.Name = "BTAddTable";
            this.BTAddTable.Size = new System.Drawing.Size(75, 23);
            this.BTAddTable.TabIndex = 24;
            this.BTAddTable.Text = ">";
            this.BTAddTable.UseVisualStyleBackColor = true;
            this.BTAddTable.Click += new System.EventHandler(this.BTAddTable_Click);
            // 
            // BtRemoveTable
            // 
            this.BtRemoveTable.Location = new System.Drawing.Point(673, 244);
            this.BtRemoveTable.Name = "BtRemoveTable";
            this.BtRemoveTable.Size = new System.Drawing.Size(75, 23);
            this.BtRemoveTable.TabIndex = 25;
            this.BtRemoveTable.Text = "<";
            this.BtRemoveTable.UseVisualStyleBackColor = true;
            this.BtRemoveTable.Click += new System.EventHandler(this.BtRemoveTable_Click);
            // 
            // BTRemoveView
            // 
            this.BTRemoveView.Location = new System.Drawing.Point(674, 630);
            this.BTRemoveView.Name = "BTRemoveView";
            this.BTRemoveView.Size = new System.Drawing.Size(75, 23);
            this.BTRemoveView.TabIndex = 27;
            this.BTRemoveView.Text = "<";
            this.BTRemoveView.UseVisualStyleBackColor = true;
            this.BTRemoveView.Click += new System.EventHandler(this.BTRemoveView_Click);
            // 
            // BTAddView
            // 
            this.BTAddView.Location = new System.Drawing.Point(674, 568);
            this.BTAddView.Name = "BTAddView";
            this.BTAddView.Size = new System.Drawing.Size(75, 23);
            this.BTAddView.TabIndex = 26;
            this.BTAddView.Text = ">";
            this.BTAddView.UseVisualStyleBackColor = true;
            this.BTAddView.Click += new System.EventHandler(this.BTAddView_Click);
            // 
            // GWSelectedTable
            // 
            this.GWSelectedTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GWSelectedTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4});
            this.GWSelectedTable.Location = new System.Drawing.Point(759, 72);
            this.GWSelectedTable.Name = "GWSelectedTable";
            this.GWSelectedTable.RowTemplate.Height = 24;
            this.GWSelectedTable.Size = new System.Drawing.Size(656, 310);
            this.GWSelectedTable.TabIndex = 28;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "CH";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TABLE_NAME";
            this.dataGridViewTextBoxColumn2.HeaderText = "TABLE_NAME";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "OWNER";
            this.dataGridViewTextBoxColumn4.HeaderText = "OWNER";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // RbPascal
            // 
            this.RbPascal.AutoSize = true;
            this.RbPascal.Checked = true;
            this.RbPascal.Location = new System.Drawing.Point(6, 21);
            this.RbPascal.Name = "RbPascal";
            this.RbPascal.Size = new System.Drawing.Size(71, 21);
            this.RbPascal.TabIndex = 29;
            this.RbPascal.TabStop = true;
            this.RbPascal.Text = "Pascal";
            this.RbPascal.UseVisualStyleBackColor = true;
            // 
            // RbCamel
            // 
            this.RbCamel.AutoSize = true;
            this.RbCamel.Location = new System.Drawing.Point(6, 48);
            this.RbCamel.Name = "RbCamel";
            this.RbCamel.Size = new System.Drawing.Size(68, 21);
            this.RbCamel.TabIndex = 31;
            this.RbCamel.Text = "Camel";
            this.RbCamel.UseVisualStyleBackColor = true;
            // 
            // RbUpper
            // 
            this.RbUpper.AutoSize = true;
            this.RbUpper.Location = new System.Drawing.Point(6, 75);
            this.RbUpper.Name = "RbUpper";
            this.RbUpper.Size = new System.Drawing.Size(68, 21);
            this.RbUpper.TabIndex = 32;
            this.RbUpper.Text = "Upper";
            this.RbUpper.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RbPascal);
            this.groupBox1.Controls.Add(this.RbUpper);
            this.groupBox1.Controls.Add(this.RbCamel);
            this.groupBox1.Location = new System.Drawing.Point(1087, 771);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Capitalization";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1427, 947);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GWSelectedTable);
            this.Controls.Add(this.BTRemoveView);
            this.Controls.Add(this.BTAddView);
            this.Controls.Add(this.BtRemoveTable);
            this.Controls.Add(this.BTAddTable);
            this.Controls.Add(this.GWSelectedView);
            this.Controls.Add(this.BtConStrDegistir);
            this.Controls.Add(this.TBConString);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BTViewNameAra);
            this.Controls.Add(this.BTTableNameAra);
            this.Controls.Add(this.TBViewName);
            this.Controls.Add(this.TBTableName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GWView);
            this.Controls.Add(this.TBNameSpace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTOlustur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTKlasor);
            this.Controls.Add(this.LBPath);
            this.Controls.Add(this.BtListele);
            this.Controls.Add(this.GWTables);
            this.Name = "Form1";
            this.Text = "EF FluentGenerator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GWTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GWView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GWSelectedView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GWSelectedTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GWTables;
        private System.Windows.Forms.Button BtListele;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label LBPath;
        private System.Windows.Forms.Button BTKlasor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTOlustur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBNameSpace;
        private System.Windows.Forms.DataGridView GWView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBTableName;
        private System.Windows.Forms.TextBox TBViewName;
        private System.Windows.Forms.Button BTTableNameAra;
        private System.Windows.Forms.Button BTViewNameAra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBConString;
        private System.Windows.Forms.Button BtConStrDegistir;
        private System.Windows.Forms.DataGridView GWSelectedView;
        private System.Windows.Forms.Button BTAddTable;
        private System.Windows.Forms.Button BtRemoveTable;
        private System.Windows.Forms.Button BTRemoveView;
        private System.Windows.Forms.Button BTAddView;
        private System.Windows.Forms.DataGridView GWSelectedTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sec;
        private System.Windows.Forms.DataGridViewTextBoxColumn TABLE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn OWNER;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.RadioButton RbPascal;
        private System.Windows.Forms.RadioButton RbCamel;
        private System.Windows.Forms.RadioButton RbUpper;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

