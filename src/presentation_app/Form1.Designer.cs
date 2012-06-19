namespace presentation_app
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.TextBox();
            this.execute = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gencode = new System.Windows.Forms.TextBox();
            this.includes = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(12, 101);
            this.code.Multiline = true;
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(388, 170);
            this.code.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Result";
            // 
            // result
            // 
            this.result.Enabled = false;
            this.result.Location = new System.Drawing.Point(431, 25);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(211, 20);
            this.result.TabIndex = 3;
            // 
            // execute
            // 
            this.execute.Location = new System.Drawing.Point(431, 52);
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(90, 23);
            this.execute.TabIndex = 4;
            this.execute.Text = "Execute";
            this.execute.UseVisualStyleBackColor = true;
            this.execute.Click += new System.EventHandler(this.execute_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Generated Code";
            // 
            // gencode
            // 
            this.gencode.Location = new System.Drawing.Point(12, 303);
            this.gencode.Multiline = true;
            this.gencode.Name = "gencode";
            this.gencode.Size = new System.Drawing.Size(388, 283);
            this.gencode.TabIndex = 6;
            // 
            // includes
            // 
            this.includes.FormattingEnabled = true;
            this.includes.Items.AddRange(new object[] {
            "System",
            "System.Math"});
            this.includes.Location = new System.Drawing.Point(12, 26);
            this.includes.Name = "includes";
            this.includes.Size = new System.Drawing.Size(214, 49);
            this.includes.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "using";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 598);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.includes);
            this.Controls.Add(this.gencode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.execute);
            this.Controls.Add(this.result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.code);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button execute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox gencode;
        private System.Windows.Forms.CheckedListBox includes;
        private System.Windows.Forms.Label label4;
    }
}

