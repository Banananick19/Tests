using System.ComponentModel;
using System.Windows.Forms;

namespace AKCENT
{
    partial class MyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.checkBoxWorker = new System.Windows.Forms.CheckBox();
            this.checkBox2Intern = new System.Windows.Forms.CheckBox();
            this.checkBox3Main = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkBoxWorker
            // 
            this.checkBoxWorker.Location = new System.Drawing.Point(684, 12);
            this.checkBoxWorker.Name = "checkBoxWorker";
            this.checkBoxWorker.Size = new System.Drawing.Size(104, 24);
            this.checkBoxWorker.TabIndex = 1;
            this.checkBoxWorker.Text = "Worker";
            this.checkBoxWorker.UseVisualStyleBackColor = true;
            this.checkBoxWorker.CheckedChanged += new System.EventHandler(this.checkBoxWorker_CheckedChanged);
            // 
            // checkBox2Intern
            // 
            this.checkBox2Intern.Location = new System.Drawing.Point(684, 42);
            this.checkBox2Intern.Name = "checkBox2Intern";
            this.checkBox2Intern.Size = new System.Drawing.Size(104, 24);
            this.checkBox2Intern.TabIndex = 2;
            this.checkBox2Intern.Text = "Intern";
            this.checkBox2Intern.UseVisualStyleBackColor = true;
            // 
            // checkBox3Main
            // 
            this.checkBox3Main.Location = new System.Drawing.Point(684, 72);
            this.checkBox3Main.Name = "checkBox3Main";
            this.checkBox3Main.Size = new System.Drawing.Size(104, 24);
            this.checkBox3Main.TabIndex = 3;
            this.checkBox3Main.Text = "Main";
            this.checkBox3Main.UseVisualStyleBackColor = true;
            this.checkBox3Main.CheckedChanged += new System.EventHandler(this.checkBox3Main_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(684, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 4;
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox3Main);
            this.Controls.Add(this.checkBox2Intern);
            this.Controls.Add(this.checkBoxWorker);
            this.Name = "MyForm";
            this.Text = "MyForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox checkBox2Intern;
        private System.Windows.Forms.CheckBox checkBox3Main;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.CheckBox checkBoxWorker;

        #endregion
    }
}