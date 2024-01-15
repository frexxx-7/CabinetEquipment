namespace CabinetEquipment.Forms
{
    partial class EYMK
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
            this.BackButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.EYMKDataGridView = new System.Windows.Forms.DataGridView();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.idDocrors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeacherColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisciplineColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.EYMKDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(114, 36);
            this.BackButton.TabIndex = 14;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateButton.Location = new System.Drawing.Point(777, 12);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(114, 36);
            this.UpdateButton.TabIndex = 15;
            this.UpdateButton.Text = "Обновить";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
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
            this.idDocrors,
            this.TeacherColumn,
            this.DisciplineColumn,
            this.ElementColumn});
            this.EYMKDataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.EYMKDataGridView.Location = new System.Drawing.Point(12, 68);
            this.EYMKDataGridView.Name = "EYMKDataGridView";
            this.EYMKDataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EYMKDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.EYMKDataGridView.RowTemplate.Height = 24;
            this.EYMKDataGridView.Size = new System.Drawing.Size(879, 413);
            this.EYMKDataGridView.TabIndex = 25;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteButton.Location = new System.Drawing.Point(279, 530);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(114, 36);
            this.DeleteButton.TabIndex = 28;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditButton.Location = new System.Drawing.Point(145, 530);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(114, 36);
            this.EditButton.TabIndex = 27;
            this.EditButton.Text = "Изменить";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Location = new System.Drawing.Point(12, 530);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(114, 36);
            this.AddButton.TabIndex = 26;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextBox.Location = new System.Drawing.Point(514, 537);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(243, 22);
            this.SearchTextBox.TabIndex = 30;
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Location = new System.Drawing.Point(777, 530);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(114, 36);
            this.SearchButton.TabIndex = 29;
            this.SearchButton.Text = "Поиск";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // idDocrors
            // 
            this.idDocrors.HeaderText = "id";
            this.idDocrors.MinimumWidth = 6;
            this.idDocrors.Name = "idDocrors";
            this.idDocrors.Visible = false;
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
            // ElementColumn
            // 
            this.ElementColumn.HeaderText = "Элемент";
            this.ElementColumn.MinimumWidth = 6;
            this.ElementColumn.Name = "ElementColumn";
            // 
            // EYMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 578);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.EYMKDataGridView);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.BackButton);
            this.Name = "EYMK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ЭУМК";
            this.Load += new System.EventHandler(this.EYMK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EYMKDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.DataGridView EYMKDataGridView;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisciplineColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementColumn;
    }
}