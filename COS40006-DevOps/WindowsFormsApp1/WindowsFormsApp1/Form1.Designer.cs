namespace WindowsFormsApp1
{
    partial class Form1
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
            this.numbers_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.operand1_textBox = new System.Windows.Forms.TextBox();
            this.operator_textBox = new System.Windows.Forms.TextBox();
            this.operand2_textBox = new System.Windows.Forms.TextBox();
            this.plus_button = new System.Windows.Forms.Button();
            this.minus_button = new System.Windows.Forms.Button();
            this.multiply_button = new System.Windows.Forms.Button();
            this.divide_button = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.equal_button = new System.Windows.Forms.Button();
            this.reset_button = new System.Windows.Forms.Button();
            this.resultValue_textBox = new System.Windows.Forms.TextBox();
            this.resultLabel_textBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // numbers_flowLayoutPanel
            // 
            this.numbers_flowLayoutPanel.Location = new System.Drawing.Point(12, 305);
            this.numbers_flowLayoutPanel.Name = "numbers_flowLayoutPanel";
            this.numbers_flowLayoutPanel.Size = new System.Drawing.Size(123, 132);
            this.numbers_flowLayoutPanel.TabIndex = 9;
            // 
            // operand1_textBox
            // 
            this.operand1_textBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.operand1_textBox.Location = new System.Drawing.Point(30, 48);
            this.operand1_textBox.Name = "operand1_textBox";
            this.operand1_textBox.ReadOnly = true;
            this.operand1_textBox.Size = new System.Drawing.Size(136, 22);
            this.operand1_textBox.TabIndex = 10;
            this.operand1_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.operand1_textBox.Click += new System.EventHandler(this.operand1_textBox_Click);
            // 
            // operator_textBox
            // 
            this.operator_textBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.operator_textBox.Location = new System.Drawing.Point(172, 48);
            this.operator_textBox.Name = "operator_textBox";
            this.operator_textBox.ReadOnly = true;
            this.operator_textBox.Size = new System.Drawing.Size(21, 22);
            this.operator_textBox.TabIndex = 12;
            this.operator_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // operand2_textBox
            // 
            this.operand2_textBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.operand2_textBox.Location = new System.Drawing.Point(199, 48);
            this.operand2_textBox.Name = "operand2_textBox";
            this.operand2_textBox.ReadOnly = true;
            this.operand2_textBox.Size = new System.Drawing.Size(136, 22);
            this.operand2_textBox.TabIndex = 13;
            this.operand2_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.operand2_textBox.Click += new System.EventHandler(this.operand2_textBox_Click);
            // 
            // plus_button
            // 
            this.plus_button.Location = new System.Drawing.Point(3, 3);
            this.plus_button.Name = "plus_button";
            this.plus_button.Size = new System.Drawing.Size(38, 38);
            this.plus_button.TabIndex = 14;
            this.plus_button.Text = "+";
            this.plus_button.UseVisualStyleBackColor = true;
            this.plus_button.Click += new System.EventHandler(this.operator_button_Click);
            // 
            // minus_button
            // 
            this.minus_button.Location = new System.Drawing.Point(47, 3);
            this.minus_button.Name = "minus_button";
            this.minus_button.Size = new System.Drawing.Size(38, 38);
            this.minus_button.TabIndex = 15;
            this.minus_button.Text = "-";
            this.minus_button.UseVisualStyleBackColor = true;
            this.minus_button.Click += new System.EventHandler(this.operator_button_Click);
            // 
            // multiply_button
            // 
            this.multiply_button.Location = new System.Drawing.Point(3, 47);
            this.multiply_button.Name = "multiply_button";
            this.multiply_button.Size = new System.Drawing.Size(38, 38);
            this.multiply_button.TabIndex = 16;
            this.multiply_button.Text = "*";
            this.multiply_button.UseVisualStyleBackColor = true;
            this.multiply_button.Click += new System.EventHandler(this.operator_button_Click);
            // 
            // divide_button
            // 
            this.divide_button.Location = new System.Drawing.Point(47, 47);
            this.divide_button.Name = "divide_button";
            this.divide_button.Size = new System.Drawing.Size(38, 38);
            this.divide_button.TabIndex = 17;
            this.divide_button.Text = "/";
            this.divide_button.UseVisualStyleBackColor = true;
            this.divide_button.Click += new System.EventHandler(this.operator_button_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.plus_button);
            this.flowLayoutPanel2.Controls.Add(this.minus_button);
            this.flowLayoutPanel2.Controls.Add(this.multiply_button);
            this.flowLayoutPanel2.Controls.Add(this.divide_button);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(141, 348);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(91, 89);
            this.flowLayoutPanel2.TabIndex = 18;
            // 
            // equal_button
            // 
            this.equal_button.Location = new System.Drawing.Point(238, 396);
            this.equal_button.Name = "equal_button";
            this.equal_button.Size = new System.Drawing.Size(38, 38);
            this.equal_button.TabIndex = 18;
            this.equal_button.Text = "=";
            this.equal_button.UseVisualStyleBackColor = true;
            this.equal_button.Click += new System.EventHandler(this.equal_button_Click);
            // 
            // reset_button
            // 
            this.reset_button.Location = new System.Drawing.Point(238, 351);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(38, 38);
            this.reset_button.TabIndex = 19;
            this.reset_button.Text = "AC";
            this.reset_button.UseVisualStyleBackColor = true;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // resultValue_textBox
            // 
            this.resultValue_textBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resultValue_textBox.Location = new System.Drawing.Point(96, 96);
            this.resultValue_textBox.Name = "resultValue_textBox";
            this.resultValue_textBox.ReadOnly = true;
            this.resultValue_textBox.Size = new System.Drawing.Size(136, 22);
            this.resultValue_textBox.TabIndex = 20;
            // 
            // resultLabel_textBox
            // 
            this.resultLabel_textBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resultLabel_textBox.Location = new System.Drawing.Point(30, 96);
            this.resultLabel_textBox.Name = "resultLabel_textBox";
            this.resultLabel_textBox.ReadOnly = true;
            this.resultLabel_textBox.Size = new System.Drawing.Size(59, 22);
            this.resultLabel_textBox.TabIndex = 21;
            this.resultLabel_textBox.Text = "Result:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 449);
            this.Controls.Add(this.resultLabel_textBox);
            this.Controls.Add(this.resultValue_textBox);
            this.Controls.Add(this.reset_button);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.operand2_textBox);
            this.Controls.Add(this.operator_textBox);
            this.Controls.Add(this.operand1_textBox);
            this.Controls.Add(this.equal_button);
            this.Controls.Add(this.numbers_flowLayoutPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel numbers_flowLayoutPanel;
        private System.Windows.Forms.TextBox operand1_textBox;
        private System.Windows.Forms.TextBox operator_textBox;
        private System.Windows.Forms.TextBox operand2_textBox;
        private System.Windows.Forms.Button plus_button;
        private System.Windows.Forms.Button minus_button;
        private System.Windows.Forms.Button multiply_button;
        private System.Windows.Forms.Button divide_button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button equal_button;
        private System.Windows.Forms.Button reset_button;
        private System.Windows.Forms.TextBox resultValue_textBox;
        private System.Windows.Forms.TextBox resultLabel_textBox;
    }
}

