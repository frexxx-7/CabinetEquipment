namespace CabinetEquipment.Forms
{
    partial class Directorys
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
            this.KabinetButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BackButtonButton = new System.Windows.Forms.Button();
            this.SubjectsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KabinetButton
            // 
            this.KabinetButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KabinetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KabinetButton.Location = new System.Drawing.Point(200, 105);
            this.KabinetButton.Name = "KabinetButton";
            this.KabinetButton.Size = new System.Drawing.Size(183, 46);
            this.KabinetButton.TabIndex = 1;
            this.KabinetButton.Text = "Виды оснащений";
            this.KabinetButton.UseVisualStyleBackColor = true;
            this.KabinetButton.Click += new System.EventHandler(this.KabinetButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(194, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Справочники";
            // 
            // BackButtonButton
            // 
            this.BackButtonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButtonButton.Location = new System.Drawing.Point(12, 12);
            this.BackButtonButton.Name = "BackButtonButton";
            this.BackButtonButton.Size = new System.Drawing.Size(132, 39);
            this.BackButtonButton.TabIndex = 7;
            this.BackButtonButton.Text = "Назад";
            this.BackButtonButton.UseVisualStyleBackColor = true;
            this.BackButtonButton.Click += new System.EventHandler(this.BackButtonButton_Click);
            // 
            // SubjectsButton
            // 
            this.SubjectsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SubjectsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SubjectsButton.Location = new System.Drawing.Point(200, 206);
            this.SubjectsButton.Name = "SubjectsButton";
            this.SubjectsButton.Size = new System.Drawing.Size(183, 46);
            this.SubjectsButton.TabIndex = 8;
            this.SubjectsButton.Text = "Предметы";
            this.SubjectsButton.UseVisualStyleBackColor = true;
            this.SubjectsButton.Click += new System.EventHandler(this.SubjectsButton_Click);
            // 
            // Directorys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 577);
            this.Controls.Add(this.SubjectsButton);
            this.Controls.Add(this.BackButtonButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KabinetButton);
            this.Name = "Directorys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочники";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Directorys_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button KabinetButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BackButtonButton;
        private System.Windows.Forms.Button SubjectsButton;
    }
}