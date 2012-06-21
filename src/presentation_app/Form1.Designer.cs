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
            this.label5 = new System.Windows.Forms.Label();
            this.compiler_output = new System.Windows.Forms.TextBox();
            this.change_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // code
            // 
            this.code.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code.Location = new System.Drawing.Point(12, 126);
            this.code.Multiline = true;
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(399, 251);
            this.code.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(431, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Result";
            // 
            // result
            // 
            this.result.Enabled = false;
            this.result.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result.ForeColor = System.Drawing.SystemColors.ControlText;
            this.result.Location = new System.Drawing.Point(431, 35);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(478, 29);
            this.result.TabIndex = 3;
            // 
            // execute
            // 
            this.execute.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.execute.Location = new System.Drawing.Point(431, 70);
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(98, 32);
            this.execute.TabIndex = 4;
            this.execute.Text = "Execute";
            this.execute.UseVisualStyleBackColor = true;
            this.execute.Click += new System.EventHandler(this.execute_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Generated Code";
            // 
            // gencode
            // 
            this.gencode.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gencode.Location = new System.Drawing.Point(12, 429);
            this.gencode.Multiline = true;
            this.gencode.Name = "gencode";
            this.gencode.Size = new System.Drawing.Size(897, 550);
            this.gencode.TabIndex = 6;
            // 
            // includes
            // 
            this.includes.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.includes.FormattingEnabled = true;
            this.includes.Items.AddRange(new object[] {
            "System",
            "System.Drawing"});
            this.includes.Location = new System.Drawing.Point(16, 35);
            this.includes.Name = "includes";
            this.includes.Size = new System.Drawing.Size(214, 52);
            this.includes.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "using";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(431, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Compiler Output";
            // 
            // compiler_output
            // 
            this.compiler_output.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compiler_output.ForeColor = System.Drawing.Color.Red;
            this.compiler_output.Location = new System.Drawing.Point(435, 207);
            this.compiler_output.Multiline = true;
            this.compiler_output.Name = "compiler_output";
            this.compiler_output.Size = new System.Drawing.Size(474, 170);
            this.compiler_output.TabIndex = 10;
            // 
            // change_label
            // 
            this.change_label.AutoSize = true;
            this.change_label.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change_label.Location = new System.Drawing.Point(652, 75);
            this.change_label.Name = "change_label";
            this.change_label.Size = new System.Drawing.Size(50, 22);
            this.change_label.TabIndex = 11;
            this.change_label.Text = "label";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 983);
            this.Controls.Add(this.change_label);
            this.Controls.Add(this.compiler_output);
            this.Controls.Add(this.label5);
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
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox compiler_output;
        private System.Windows.Forms.Label change_label;
    }
}

