namespace FormBinding
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.carInventoryGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRowToRemove = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtChangeMake = new System.Windows.Forms.TextBox();
            this.btnChangeMake = new System.Windows.Forms.Button();
            this.btnDisplayMakes = new System.Windows.Forms.Button();
            this.txtMakeToView = new System.Windows.Forms.TextBox();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.dataGridYugo = new System.Windows.Forms.DataGridView();
            this.Yugos = new System.Windows.Forms.Label();
            this.edtShowSubFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edtShowSubTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnShowSub = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYugo)).BeginInit();
            this.SuspendLayout();
            // 
            // carInventoryGridView
            // 
            this.carInventoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carInventoryGridView.Location = new System.Drawing.Point(12, 37);
            this.carInventoryGridView.Name = "carInventoryGridView";
            this.carInventoryGridView.Size = new System.Drawing.Size(452, 250);
            this.carInventoryGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your text";
            // 
            // txtRowToRemove
            // 
            this.txtRowToRemove.Location = new System.Drawing.Point(6, 28);
            this.txtRowToRemove.Name = "txtRowToRemove";
            this.txtRowToRemove.Size = new System.Drawing.Size(91, 29);
            this.txtRowToRemove.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShowSub);
            this.groupBox1.Controls.Add(this.edtChangeMake);
            this.groupBox1.Controls.Add(this.btnChangeMake);
            this.groupBox1.Controls.Add(this.btnDisplayMakes);
            this.groupBox1.Controls.Add(this.txtMakeToView);
            this.groupBox1.Controls.Add(this.btnRemoveRow);
            this.groupBox1.Controls.Add(this.txtRowToRemove);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 293);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 103);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deleting of string";
            // 
            // edtChangeMake
            // 
            this.edtChangeMake.Location = new System.Drawing.Point(201, 28);
            this.edtChangeMake.Name = "edtChangeMake";
            this.edtChangeMake.Size = new System.Drawing.Size(91, 29);
            this.edtChangeMake.TabIndex = 7;
            this.edtChangeMake.TextChanged += new System.EventHandler(this.edtChangeMake_TextChanged);
            // 
            // btnChangeMake
            // 
            this.btnChangeMake.Location = new System.Drawing.Point(298, 19);
            this.btnChangeMake.Name = "btnChangeMake";
            this.btnChangeMake.Size = new System.Drawing.Size(92, 38);
            this.btnChangeMake.TabIndex = 6;
            this.btnChangeMake.Text = "Change";
            this.btnChangeMake.UseVisualStyleBackColor = true;
            this.btnChangeMake.Click += new System.EventHandler(this.btnChangeMake_Click);
            // 
            // btnDisplayMakes
            // 
            this.btnDisplayMakes.Location = new System.Drawing.Point(103, 63);
            this.btnDisplayMakes.Name = "btnDisplayMakes";
            this.btnDisplayMakes.Size = new System.Drawing.Size(92, 29);
            this.btnDisplayMakes.TabIndex = 5;
            this.btnDisplayMakes.Text = "View";
            this.btnDisplayMakes.UseVisualStyleBackColor = true;
            this.btnDisplayMakes.Click += new System.EventHandler(this.btnDisplayMakes_Click);
            // 
            // txtMakeToView
            // 
            this.txtMakeToView.Location = new System.Drawing.Point(6, 63);
            this.txtMakeToView.Name = "txtMakeToView";
            this.txtMakeToView.Size = new System.Drawing.Size(91, 29);
            this.txtMakeToView.TabIndex = 4;
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Location = new System.Drawing.Point(103, 28);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(92, 29);
            this.btnRemoveRow.TabIndex = 3;
            this.btnRemoveRow.Text = "Remove";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // dataGridYugo
            // 
            this.dataGridYugo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridYugo.Location = new System.Drawing.Point(12, 433);
            this.dataGridYugo.Name = "dataGridYugo";
            this.dataGridYugo.Size = new System.Drawing.Size(448, 162);
            this.dataGridYugo.TabIndex = 4;
            // 
            // Yugos
            // 
            this.Yugos.AutoSize = true;
            this.Yugos.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Yugos.Location = new System.Drawing.Point(12, 399);
            this.Yugos.Name = "Yugos";
            this.Yugos.Size = new System.Drawing.Size(96, 22);
            this.Yugos.TabIndex = 5;
            this.Yugos.Text = "Yugos only";
            // 
            // edtShowSubFrom
            // 
            this.edtShowSubFrom.Location = new System.Drawing.Point(115, 407);
            this.edtShowSubFrom.Name = "edtShowSubFrom";
            this.edtShowSubFrom.Size = new System.Drawing.Size(100, 20);
            this.edtShowSubFrom.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(221, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "From";
            // 
            // edtShowSubTo
            // 
            this.edtShowSubTo.Location = new System.Drawing.Point(278, 408);
            this.edtShowSubTo.Name = "edtShowSubTo";
            this.edtShowSubTo.Size = new System.Drawing.Size(100, 20);
            this.edtShowSubTo.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(384, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "To";
            // 
            // btnShowSub
            // 
            this.btnShowSub.Location = new System.Drawing.Point(201, 63);
            this.btnShowSub.Name = "btnShowSub";
            this.btnShowSub.Size = new System.Drawing.Size(92, 29);
            this.btnShowSub.TabIndex = 8;
            this.btnShowSub.Text = "Show";
            this.btnShowSub.UseVisualStyleBackColor = true;
            this.btnShowSub.Click += new System.EventHandler(this.btnShowSub_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 607);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtShowSubTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtShowSubFrom);
            this.Controls.Add(this.Yugos);
            this.Controls.Add(this.dataGridYugo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.carInventoryGridView);
            this.Name = "Form1";
            this.Text = "SQL Server";
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYugo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView carInventoryGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRowToRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.Button btnDisplayMakes;
        private System.Windows.Forms.TextBox txtMakeToView;
        private System.Windows.Forms.TextBox edtChangeMake;
        private System.Windows.Forms.Button btnChangeMake;
        private System.Windows.Forms.DataGridView dataGridYugo;
        private System.Windows.Forms.Label Yugos;
        private System.Windows.Forms.Button btnShowSub;
        private System.Windows.Forms.TextBox edtShowSubFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtShowSubTo;
        private System.Windows.Forms.Label label3;
    }
}

