namespace CabinetEquipment
{
    partial class Main
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
            this.KabinetButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TeachersButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.EYMKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KabinetButton
            // 
            this.KabinetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KabinetButton.Location = new System.Drawing.Point(141, 81);
            this.KabinetButton.Name = "KabinetButton";
            this.KabinetButton.Size = new System.Drawing.Size(183, 46);
            this.KabinetButton.TabIndex = 0;
            this.KabinetButton.Text = "Кабинеты";
            this.KabinetButton.UseVisualStyleBackColor = true;
            this.KabinetButton.Click += new System.EventHandler(this.KabinetButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(169, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Главная";
            // 
            // TeachersButton
            // 
            this.TeachersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TeachersButton.Location = new System.Drawing.Point(141, 182);
            this.TeachersButton.Name = "TeachersButton";
            this.TeachersButton.Size = new System.Drawing.Size(183, 46);
            this.TeachersButton.TabIndex = 2;
            this.TeachersButton.Text = "Преподаватели";
            this.TeachersButton.UseVisualStyleBackColor = true;
            this.TeachersButton.Click += new System.EventHandler(this.TeachersButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(124, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "Перечень оснащений";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // EYMKButton
            // 
            this.EYMKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EYMKButton.Location = new System.Drawing.Point(141, 362);
            this.EYMKButton.Name = "EYMKButton";
            this.EYMKButton.Size = new System.Drawing.Size(183, 46);
            this.EYMKButton.TabIndex = 4;
            this.EYMKButton.Text = "ЭУМК";
            this.EYMKButton.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 516);
            this.Controls.Add(this.EYMKButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TeachersButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KabinetButton);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button KabinetButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TeachersButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button EYMKButton;
    }
}

