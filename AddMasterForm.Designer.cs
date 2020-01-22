namespace OXG.ServiceCenterReceipts
{
    partial class AddMasterForm
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
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.PercentTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(70, 9);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(112, 20);
            this.NameTextBox.TabIndex = 0;
            this.NameTextBox.Text = "Имя";
            // 
            // PercentTextBox
            // 
            this.PercentTextBox.Location = new System.Drawing.Point(70, 46);
            this.PercentTextBox.Name = "PercentTextBox";
            this.PercentTextBox.Size = new System.Drawing.Size(112, 20);
            this.PercentTextBox.TabIndex = 1;
            this.PercentTextBox.Text = "Процент";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(70, 81);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(112, 20);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.Text = "Пароль";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Добавить мастера";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 179);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.PercentTextBox);
            this.Controls.Add(this.NameTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddMasterForm";
            this.Text = "AddMasterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox PercentTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button button1;
    }
}