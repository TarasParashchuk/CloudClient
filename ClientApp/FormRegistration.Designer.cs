﻿namespace ClientApp
{
    partial class FormRegistration
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
            this.button1 = new System.Windows.Forms.Button();
            this.Log_text = new System.Windows.Forms.TextBox();
            this.Pass_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(332, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Зареєструватись";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Log_text
            // 
            this.Log_text.Location = new System.Drawing.Point(66, 5);
            this.Log_text.Name = "Log_text";
            this.Log_text.Size = new System.Drawing.Size(278, 20);
            this.Log_text.TabIndex = 1;
            // 
            // Pass_text
            // 
            this.Pass_text.Location = new System.Drawing.Point(66, 49);
            this.Pass_text.Name = "Pass_text";
            this.Pass_text.Size = new System.Drawing.Size(278, 20);
            this.Pass_text.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Логін";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль";
            // 
            // FormRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 141);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pass_text);
            this.Controls.Add(this.Log_text);
            this.Controls.Add(this.button1);
            this.Name = "FormRegistration";
            this.Text = "Форма реєстрації";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRegistration_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Log_text;
        private System.Windows.Forms.TextBox Pass_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}