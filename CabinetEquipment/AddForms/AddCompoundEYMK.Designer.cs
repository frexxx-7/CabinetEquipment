namespace CabinetEquipment.AddForms
{
    partial class AddCompoundEYMK
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
            this.label1 = new System.Windows.Forms.Label();
            this.ChapterСomboBox = new System.Windows.Forms.ComboBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EYMKDataGridView = new System.Windows.Forms.DataGridView();
            this.idEYMKColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeacherColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisciplineColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.EYMKDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(23, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 37;
            this.label1.Text = "Раздел:";
            // 
            // ChapterСomboBox
            // 
            this.ChapterСomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ChapterСomboBox.FormattingEnabled = true;
            this.ChapterСomboBox.Items.AddRange(new object[] {
            "Теоритический",
            "Практический"});
            this.ChapterСomboBox.Location = new System.Drawing.Point(178, 90);
            this.ChapterСomboBox.Name = "ChapterСomboBox";
            this.ChapterСomboBox.Size = new System.Drawing.Size(468, 24);
            this.ChapterСomboBox.TabIndex = 36;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Location = new System.Drawing.Point(12, 564);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(122, 32);
            this.AddButton.TabIndex = 40;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(665, 564);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(122, 32);
            this.CancelButton.TabIndex = 41;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(270, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 25);
            this.label3.TabIndex = 42;
            this.label3.Text = "Добавить состав ЭУМК";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(23, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Выберите ЭУМК:";
            // 
            // EYMKDataGridView
            // 
            this.EYMKDataGridView.AllowUserToAddRows = false;
            this.EYMKDataGridView.AllowUserToDeleteRows = false;
            this.EYMKDataGridView.AllowUserToResizeColumns = false;
            this.EYMKDataGridView.AllowUserToResizeRows = false;
            this.EYMKDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EYMKDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EYMKDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EYMKDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEYMKColumn,
            this.TeacherColumn,
            this.DisciplineColumn});
            this.EYMKDataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.EYMKDataGridView.Location = new System.Drawing.Point(28, 192);
            this.EYMKDataGridView.Name = "EYMKDataGridView";
            this.EYMKDataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EYMKDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.EYMKDataGridView.RowTemplate.Height = 24;
            this.EYMKDataGridView.Size = new System.Drawing.Size(740, 344);
            this.EYMKDataGridView.TabIndex = 44;
            // 
            // idEYMKColumn
            // 
            this.idEYMKColumn.HeaderText = "id";
            this.idEYMKColumn.MinimumWidth = 6;
            this.idEYMKColumn.Name = "idEYMKColumn";
            this.idEYMKColumn.Visible = false;
            // 
            // TeacherColumn
            // 
            this.TeacherColumn.HeaderText = "Преподаватель";
            this.TeacherColumn.MinimumWidth = 6;
            this.TeacherColumn.Name = "TeacherColumn";
            // 
            // DisciplineColumn
            // 
            this.DisciplineColumn.HeaderText = "Предмет";
            this.DisciplineColumn.MinimumWidth = 6;
            this.DisciplineColumn.Name = "DisciplineColumn";
            // 
            // AddCompoundEYMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 608);
            this.Controls.Add(this.EYMKDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChapterСomboBox);
            this.Name = "AddCompoundEYMK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить состав ЭУМК";
            this.Load += new System.EventHandler(this.AddCompoundEYMK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EYMKDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ChapterСomboBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView EYMKDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEYMKColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisciplineColumn;
    }
}