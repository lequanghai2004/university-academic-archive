namespace WinFormsApp
{
    partial class ViewOrder_Form
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
            components = new System.ComponentModel.Container();
            contextMenuStrip = new ContextMenuStrip(components);
            col1ToolStripMenuItem = new ToolStripMenuItem();
            col2ToolStripMenuItem = new ToolStripMenuItem();
            col3ToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox1 = new ToolStripTextBox();
            cell11ToolStripMenuItem = new ToolStripMenuItem();
            cell12ToolStripMenuItem = new ToolStripMenuItem();
            customer_Panel = new Panel();
            dataGridView2 = new DataGridView();
            dataGridView1 = new DataGridView();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            reset_Btn = new Button();
            toMonth_ComBox = new ComboBox();
            fromYear_ComBox = new ComboBox();
            staff_ChkBox = new CheckBox();
            data_ChkBox = new CheckBox();
            onl_RadBtn = new RadioButton();
            offl_RadBtn = new RadioButton();
            orderType_GrpBox = new GroupBox();
            all_RadBtn = new RadioButton();
            fromMonth_ComBox = new ComboBox();
            from_Label = new Label();
            to_Label = new Label();
            toYear_ComBox = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            title_Label = new Label();
            menuStrip1 = new MenuStrip();
            createNewToolStripMenuItem = new ToolStripMenuItem();
            createAcc_ToolStripMenuItem = new ToolStripMenuItem();
            newOrderToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            ordersToolStripMenuItem = new ToolStripMenuItem();
            userInfoToolStripMenuItem = new ToolStripMenuItem();
            updateToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            delAcc_ToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel3 = new TableLayoutPanel();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            contextMenuStrip.SuspendLayout();
            customer_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            orderType_GrpBox.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            menuStrip1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(24, 24);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { col1ToolStripMenuItem, cell11ToolStripMenuItem, cell12ToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new Size(138, 100);
            // 
            // col1ToolStripMenuItem
            // 
            col1ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { col2ToolStripMenuItem, toolStripTextBox1 });
            col1ToolStripMenuItem.Name = "col1ToolStripMenuItem";
            col1ToolStripMenuItem.Size = new Size(137, 32);
            col1ToolStripMenuItem.Text = "Col 1";
            // 
            // col2ToolStripMenuItem
            // 
            col2ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { col3ToolStripMenuItem });
            col2ToolStripMenuItem.Name = "col2ToolStripMenuItem";
            col2ToolStripMenuItem.Size = new Size(190, 34);
            col2ToolStripMenuItem.Text = "Col 2";
            // 
            // col3ToolStripMenuItem
            // 
            col3ToolStripMenuItem.Name = "col3ToolStripMenuItem";
            col3ToolStripMenuItem.Size = new Size(155, 34);
            col3ToolStripMenuItem.Text = "Col 3";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 31);
            // 
            // cell11ToolStripMenuItem
            // 
            cell11ToolStripMenuItem.Name = "cell11ToolStripMenuItem";
            cell11ToolStripMenuItem.Size = new Size(137, 32);
            cell11ToolStripMenuItem.Text = "Cell 11";
            // 
            // cell12ToolStripMenuItem
            // 
            cell12ToolStripMenuItem.Name = "cell12ToolStripMenuItem";
            cell12ToolStripMenuItem.Size = new Size(137, 32);
            cell12ToolStripMenuItem.Text = "Cell 12";
            // 
            // customer_Panel
            // 
            customer_Panel.AutoScroll = true;
            customer_Panel.BackColor = SystemColors.Window;
            customer_Panel.Controls.Add(dataGridView2);
            customer_Panel.Controls.Add(dataGridView1);
            customer_Panel.Location = new Point(371, 36);
            customer_Panel.Name = "customer_Panel";
            customer_Panel.Size = new Size(793, 681);
            customer_Panel.TabIndex = 1;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(3, 440);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.RowTemplate.Height = 33;
            dataGridView2.Size = new Size(787, 238);
            dataGridView2.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ContextMenuStrip = contextMenuStrip;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(787, 422);
            dataGridView1.TabIndex = 2;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // reset_Btn
            // 
            reset_Btn.Location = new Point(209, 651);
            reset_Btn.Name = "reset_Btn";
            reset_Btn.Size = new Size(112, 34);
            reset_Btn.TabIndex = 3;
            reset_Btn.Text = "reset table";
            reset_Btn.UseVisualStyleBackColor = true;
            reset_Btn.Click += reset_Btn_Click;
            // 
            // toMonth_ComBox
            // 
            toMonth_ComBox.DropDownStyle = ComboBoxStyle.DropDownList;
            toMonth_ComBox.FormattingEnabled = true;
            toMonth_ComBox.Items.AddRange(new object[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" });
            toMonth_ComBox.Location = new Point(73, 39);
            toMonth_ComBox.Name = "toMonth_ComBox";
            toMonth_ComBox.Size = new Size(96, 33);
            toMonth_ComBox.TabIndex = 4;
            toMonth_ComBox.SelectedIndexChanged += CheckDateValidity;
            // 
            // fromYear_ComBox
            // 
            fromYear_ComBox.DropDownStyle = ComboBoxStyle.DropDownList;
            fromYear_ComBox.FormattingEnabled = true;
            fromYear_ComBox.Items.AddRange(new object[] { "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026" });
            fromYear_ComBox.Location = new Point(175, 3);
            fromYear_ComBox.Name = "fromYear_ComBox";
            fromYear_ComBox.Size = new Size(96, 33);
            fromYear_ComBox.TabIndex = 5;
            fromYear_ComBox.SelectedIndexChanged += CheckDateValidity;
            // 
            // staff_ChkBox
            // 
            staff_ChkBox.AutoSize = true;
            staff_ChkBox.Location = new Point(3, 3);
            staff_ChkBox.Name = "staff_ChkBox";
            staff_ChkBox.Size = new Size(74, 29);
            staff_ChkBox.TabIndex = 6;
            staff_ChkBox.Text = "Staff";
            staff_ChkBox.UseVisualStyleBackColor = true;
            // 
            // data_ChkBox
            // 
            data_ChkBox.AutoSize = true;
            data_ChkBox.Location = new Point(140, 3);
            data_ChkBox.Name = "data_ChkBox";
            data_ChkBox.Size = new Size(75, 29);
            data_ChkBox.TabIndex = 7;
            data_ChkBox.Text = "Date";
            data_ChkBox.UseVisualStyleBackColor = true;
            // 
            // onl_RadBtn
            // 
            onl_RadBtn.AutoSize = true;
            onl_RadBtn.Location = new Point(6, 30);
            onl_RadBtn.Name = "onl_RadBtn";
            onl_RadBtn.Size = new Size(85, 29);
            onl_RadBtn.TabIndex = 10;
            onl_RadBtn.TabStop = true;
            onl_RadBtn.Text = "online";
            onl_RadBtn.UseVisualStyleBackColor = false;
            // 
            // offl_RadBtn
            // 
            offl_RadBtn.AutoSize = true;
            offl_RadBtn.Location = new Point(6, 65);
            offl_RadBtn.Name = "offl_RadBtn";
            offl_RadBtn.Size = new Size(87, 29);
            offl_RadBtn.TabIndex = 11;
            offl_RadBtn.TabStop = true;
            offl_RadBtn.Text = "offline";
            offl_RadBtn.UseVisualStyleBackColor = true;
            // 
            // orderType_GrpBox
            // 
            orderType_GrpBox.Controls.Add(all_RadBtn);
            orderType_GrpBox.Controls.Add(onl_RadBtn);
            orderType_GrpBox.Controls.Add(offl_RadBtn);
            orderType_GrpBox.Location = new Point(46, 554);
            orderType_GrpBox.Name = "orderType_GrpBox";
            orderType_GrpBox.Size = new Size(136, 138);
            orderType_GrpBox.TabIndex = 12;
            orderType_GrpBox.TabStop = false;
            orderType_GrpBox.Text = "Type of order";
            // 
            // all_RadBtn
            // 
            all_RadBtn.AutoSize = true;
            all_RadBtn.Location = new Point(6, 100);
            all_RadBtn.Name = "all_RadBtn";
            all_RadBtn.Size = new Size(54, 29);
            all_RadBtn.TabIndex = 19;
            all_RadBtn.TabStop = true;
            all_RadBtn.Text = "all";
            all_RadBtn.UseVisualStyleBackColor = true;
            // 
            // fromMonth_ComBox
            // 
            fromMonth_ComBox.DropDownStyle = ComboBoxStyle.DropDownList;
            fromMonth_ComBox.FormattingEnabled = true;
            fromMonth_ComBox.Items.AddRange(new object[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" });
            fromMonth_ComBox.Location = new Point(73, 3);
            fromMonth_ComBox.Name = "fromMonth_ComBox";
            fromMonth_ComBox.Size = new Size(96, 33);
            fromMonth_ComBox.TabIndex = 13;
            fromMonth_ComBox.SelectedIndexChanged += CheckDateValidity;
            // 
            // from_Label
            // 
            from_Label.AutoSize = true;
            from_Label.Location = new Point(3, 0);
            from_Label.Name = "from_Label";
            from_Label.Size = new Size(58, 25);
            from_Label.TabIndex = 14;
            from_Label.Text = "From:";
            // 
            // to_Label
            // 
            to_Label.AutoSize = true;
            to_Label.Location = new Point(3, 36);
            to_Label.Name = "to_Label";
            to_Label.Size = new Size(34, 25);
            to_Label.TabIndex = 15;
            to_Label.Text = "To:";
            // 
            // toYear_ComBox
            // 
            toYear_ComBox.DropDownStyle = ComboBoxStyle.DropDownList;
            toYear_ComBox.FormattingEnabled = true;
            toYear_ComBox.Items.AddRange(new object[] { "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026" });
            toYear_ComBox.Location = new Point(175, 39);
            toYear_ComBox.Name = "toYear_ComBox";
            toYear_ComBox.Size = new Size(96, 33);
            toYear_ComBox.TabIndex = 16;
            toYear_ComBox.SelectedIndexChanged += CheckDateValidity;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(to_Label, 0, 1);
            tableLayoutPanel1.Controls.Add(toYear_ComBox, 2, 1);
            tableLayoutPanel1.Controls.Add(fromMonth_ComBox, 1, 0);
            tableLayoutPanel1.Controls.Add(fromYear_ComBox, 2, 0);
            tableLayoutPanel1.Controls.Add(toMonth_ComBox, 1, 1);
            tableLayoutPanel1.Controls.Add(from_Label, 0, 0);
            tableLayoutPanel1.Location = new Point(46, 462);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(275, 72);
            tableLayoutPanel1.TabIndex = 17;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(data_ChkBox, 1, 0);
            tableLayoutPanel2.Controls.Add(staff_ChkBox, 0, 0);
            tableLayoutPanel2.Location = new Point(46, 370);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(275, 77);
            tableLayoutPanel2.TabIndex = 18;
            // 
            // title_Label
            // 
            title_Label.AutoSize = true;
            title_Label.Font = new Font("Showcard Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point);
            title_Label.Location = new Point(71, 63);
            title_Label.Name = "title_Label";
            title_Label.Size = new Size(215, 40);
            title_Label.TabIndex = 19;
            title_Label.Text = "ORDER VIEW";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { createNewToolStripMenuItem, viewToolStripMenuItem, updateToolStripMenuItem, deleteToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1164, 33);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // createNewToolStripMenuItem
            // 
            createNewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createAcc_ToolStripMenuItem, newOrderToolStripMenuItem });
            createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
            createNewToolStripMenuItem.Size = new Size(78, 29);
            createNewToolStripMenuItem.Text = "Create";
            // 
            // createAcc_ToolStripMenuItem
            // 
            createAcc_ToolStripMenuItem.Enabled = false;
            createAcc_ToolStripMenuItem.Name = "createAcc_ToolStripMenuItem";
            createAcc_ToolStripMenuItem.Size = new Size(216, 34);
            createAcc_ToolStripMenuItem.Text = "New account";
            createAcc_ToolStripMenuItem.Click += createAcc_ToolStripMenuItem_Click;
            // 
            // newOrderToolStripMenuItem
            // 
            newOrderToolStripMenuItem.Name = "newOrderToolStripMenuItem";
            newOrderToolStripMenuItem.Size = new Size(216, 34);
            newOrderToolStripMenuItem.Text = "New order";
            newOrderToolStripMenuItem.Click += newOrderToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ordersToolStripMenuItem, userInfoToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(67, 29);
            viewToolStripMenuItem.Text = "Read";
            // 
            // ordersToolStripMenuItem
            // 
            ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            ordersToolStripMenuItem.Size = new Size(185, 34);
            ordersToolStripMenuItem.Text = "Orders";
            // 
            // userInfoToolStripMenuItem
            // 
            userInfoToolStripMenuItem.Name = "userInfoToolStripMenuItem";
            userInfoToolStripMenuItem.Size = new Size(185, 34);
            userInfoToolStripMenuItem.Text = "User info";
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(86, 29);
            updateToolStripMenuItem.Text = "Update";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { delAcc_ToolStripMenuItem });
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(78, 29);
            deleteToolStripMenuItem.Text = "Delete";
            // 
            // delAcc_ToolStripMenuItem
            // 
            delAcc_ToolStripMenuItem.Enabled = false;
            delAcc_ToolStripMenuItem.Name = "delAcc_ToolStripMenuItem";
            delAcc_ToolStripMenuItem.Size = new Size(216, 34);
            delAcc_ToolStripMenuItem.Text = "User account";
            delAcc_ToolStripMenuItem.Click += delAcc_ToolStripMenuItem_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.8438454F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.1561546F));
            tableLayoutPanel3.Controls.Add(textBox1, 1, 0);
            tableLayoutPanel3.Controls.Add(label2, 0, 1);
            tableLayoutPanel3.Controls.Add(textBox2, 1, 1);
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Location = new Point(12, 145);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(333, 81);
            tableLayoutPanel3.TabIndex = 21;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(149, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 31);
            textBox1.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 40);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 1;
            label2.Text = "Staff name";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(149, 43);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(181, 31);
            textBox2.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(138, 25);
            label1.TabIndex = 0;
            label1.Text = "Customer name";
            // 
            // ViewOrder_Form
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 716);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(menuStrip1);
            Controls.Add(title_Label);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(orderType_GrpBox);
            Controls.Add(reset_Btn);
            Controls.Add(customer_Panel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "ViewOrder_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main_Form";
            Load += Main_Form_Load;
            contextMenuStrip.ResumeLayout(false);
            customer_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            orderType_GrpBox.ResumeLayout(false);
            orderType_GrpBox.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem col1ToolStripMenuItem;
        private ToolStripMenuItem col2ToolStripMenuItem;
        private ToolStripMenuItem col3ToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripMenuItem cell11ToolStripMenuItem;
        private ToolStripMenuItem cell12ToolStripMenuItem;
        private Panel customer_Panel;
        private DataGridView dataGridView1;
        private ContextMenuStrip contextMenuStrip;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private MenuStrip menuStrip;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem customerToolStripMenuItem;
        private Button reset_Btn;
        private ComboBox year_comboBox;
        private ComboBox fromYear_ComBox;
        private ToolStripMenuItem createNewUserToolStripMenuItem;
        private ToolStripMenuItem customerPerspectiveToolStripMenuItem;
        private ToolStripMenuItem removeAnAccountToolStripMenuItem;
        private CheckBox staff_ChkBox;
        private CheckBox data_ChkBox;
        private RadioButton onl_RadBtn;
        private RadioButton offl_RadBtn;
        private GroupBox orderType_GrpBox;
        private ComboBox comboBox1;
        private Label from_Label;
        private Label to_Label;
        private ComboBox toYear_ComBox;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private RadioButton all_RadBtn;
        private Label title_Label;
        private ToolStripMenuItem viewUserAccountToolStripMenuItem;
        private ComboBox toMonth_ComBox;
        private ComboBox fromMonth_ComBox;
        private DataGridView dataGridView2;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem createNewToolStripMenuItem;
        private ToolStripMenuItem createAcc_ToolStripMenuItem;
        private ToolStripMenuItem newOrderToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem ordersToolStripMenuItem;
        private ToolStripMenuItem userInfoToolStripMenuItem;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem delAcc_ToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
    }
}