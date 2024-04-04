namespace WinFormsApp
{
    partial class NewOrder_Form
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
            order_Btn = new Button();
            total_Label = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            textBox1 = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // order_Btn
            // 
            order_Btn.Location = new Point(444, 3);
            order_Btn.Name = "order_Btn";
            order_Btn.Size = new Size(129, 34);
            order_Btn.TabIndex = 1;
            order_Btn.Text = "order";
            order_Btn.UseVisualStyleBackColor = true;
            order_Btn.Click += order_Click;
            // 
            // total_Label
            // 
            total_Label.AutoSize = true;
            total_Label.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            total_Label.Location = new Point(3, 0);
            total_Label.Name = "total_Label";
            total_Label.Size = new Size(25, 27);
            total_Label.TabIndex = 2;
            total_Label.Text = "0";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.1658F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.8341961F));
            tableLayoutPanel1.Controls.Add(total_Label, 0, 0);
            tableLayoutPanel1.Controls.Add(order_Btn, 1, 0);
            tableLayoutPanel1.Location = new Point(100, 84);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(579, 41);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.3609676F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.63903F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(textBox1, 1, 0);
            tableLayoutPanel2.Location = new Point(100, 37);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(579, 41);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(135, 25);
            label1.TabIndex = 0;
            label1.Text = "customer name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(173, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(400, 31);
            textBox1.TabIndex = 1;
            // 
            // NewOrder_Form
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Name = "NewOrder_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NewOrder_Form";
            Load += NewOrder_Form_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button order_Btn;
        private Label total_Label;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private TextBox textBox1;
    }
}