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
            this.btnRemoveRow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.txtRowToRemove.Location = new System.Drawing.Point(6, 41);
            this.txtRowToRemove.Name = "txtRowToRemove";
            this.txtRowToRemove.Size = new System.Drawing.Size(100, 29);
            this.txtRowToRemove.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveRow);
            this.groupBox1.Controls.Add(this.txtRowToRemove);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 293);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 91);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deleting of string";
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Location = new System.Drawing.Point(126, 41);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(125, 29);
            this.btnRemoveRow.TabIndex = 3;
            this.btnRemoveRow.Text = "Remove";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 396);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.carInventoryGridView);
            this.Name = "Form1";
            this.Text = "SQL Server";
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView carInventoryGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRowToRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveRow;
    }
}

