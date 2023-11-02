namespace blank
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
            this.button_Task2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Task2
            // 
            this.button_Task2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Task2.Location = new System.Drawing.Point(12, 36);
            this.button_Task2.Name = "button_Task2";
            this.button_Task2.Size = new System.Drawing.Size(710, 89);
            this.button_Task2.TabIndex = 4;
            this.button_Task2.Text = "Триангуляция монотонных полигонов";
            this.button_Task2.UseVisualStyleBackColor = true;
            this.button_Task2.Click += new System.EventHandler(this.button_Task2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 161);
            this.Controls.Add(this.button_Task2);
            this.Name = "Form1";
            this.Text = "Загатовка";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Task2;
    }
}

