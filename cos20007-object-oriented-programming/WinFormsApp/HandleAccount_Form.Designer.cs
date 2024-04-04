namespace WinFormsApp
{
    partial class HandleAccount_Form
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
            tableLayoutPanel = new TableLayoutPanel();
            email_TxtBox = new TextBox();
            phoneNo_TxtBox = new TextBox();
            fullname_TxtBox = new TextBox();
            priority_TxtBox = new TextBox();
            password_Label = new Label();
            pwdconfirm_Label = new Label();
            priority_Label = new Label();
            fullname_Label = new Label();
            email_Label = new Label();
            phoneNo_Label = new Label();
            pwdconfirm_TxtBox = new TextBox();
            password_TxtBox = new TextBox();
            username_Label = new Label();
            username_TxtBox = new TextBox();
            btn = new Button();
            title_Label = new Label();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel.Controls.Add(email_TxtBox, 1, 4);
            tableLayoutPanel.Controls.Add(phoneNo_TxtBox, 1, 5);
            tableLayoutPanel.Controls.Add(fullname_TxtBox, 1, 3);
            tableLayoutPanel.Controls.Add(priority_TxtBox, 1, 2);
            tableLayoutPanel.Controls.Add(password_Label, 0, 0);
            tableLayoutPanel.Controls.Add(pwdconfirm_Label, 0, 1);
            tableLayoutPanel.Controls.Add(priority_Label, 0, 2);
            tableLayoutPanel.Controls.Add(fullname_Label, 0, 3);
            tableLayoutPanel.Controls.Add(email_Label, 0, 4);
            tableLayoutPanel.Controls.Add(phoneNo_Label, 0, 5);
            tableLayoutPanel.Controls.Add(pwdconfirm_TxtBox, 1, 1);
            tableLayoutPanel.Controls.Add(password_TxtBox, 1, 0);
            tableLayoutPanel.Location = new Point(80, 161);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 6;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel.Size = new Size(636, 258);
            tableLayoutPanel.TabIndex = 2;
            // 
            // email_TxtBox
            // 
            email_TxtBox.Location = new Point(193, 175);
            email_TxtBox.Name = "email_TxtBox";
            email_TxtBox.Size = new Size(440, 31);
            email_TxtBox.TabIndex = 6;
            email_TxtBox.TextChanged += TxtBox_TextChanged;
            // 
            // phoneNo_TxtBox
            // 
            phoneNo_TxtBox.Location = new Point(193, 218);
            phoneNo_TxtBox.Name = "phoneNo_TxtBox";
            phoneNo_TxtBox.Size = new Size(440, 31);
            phoneNo_TxtBox.TabIndex = 7;
            phoneNo_TxtBox.TextChanged += TxtBox_TextChanged;
            // 
            // fullname_TxtBox
            // 
            fullname_TxtBox.Location = new Point(193, 132);
            fullname_TxtBox.Name = "fullname_TxtBox";
            fullname_TxtBox.Size = new Size(440, 31);
            fullname_TxtBox.TabIndex = 5;
            fullname_TxtBox.TextChanged += TxtBox_TextChanged;
            // 
            // priority_TxtBox
            // 
            priority_TxtBox.Location = new Point(193, 89);
            priority_TxtBox.Name = "priority_TxtBox";
            priority_TxtBox.Size = new Size(440, 31);
            priority_TxtBox.TabIndex = 4;
            priority_TxtBox.TextChanged += TxtBox_TextChanged;
            // 
            // password_Label
            // 
            password_Label.AutoSize = true;
            password_Label.Location = new Point(3, 0);
            password_Label.Name = "password_Label";
            password_Label.Size = new Size(87, 25);
            password_Label.TabIndex = 0;
            password_Label.Text = "Password";
            // 
            // pwdconfirm_Label
            // 
            pwdconfirm_Label.AutoSize = true;
            pwdconfirm_Label.Location = new Point(3, 43);
            pwdconfirm_Label.Name = "pwdconfirm_Label";
            pwdconfirm_Label.Size = new Size(165, 25);
            pwdconfirm_Label.TabIndex = 1;
            pwdconfirm_Label.Text = "Conform password";
            // 
            // priority_Label
            // 
            priority_Label.AutoSize = true;
            priority_Label.Location = new Point(3, 86);
            priority_Label.Name = "priority_Label";
            priority_Label.Size = new Size(68, 25);
            priority_Label.TabIndex = 2;
            priority_Label.Text = "Priority";
            // 
            // fullname_Label
            // 
            fullname_Label.AutoSize = true;
            fullname_Label.Location = new Point(3, 129);
            fullname_Label.Name = "fullname_Label";
            fullname_Label.Size = new Size(88, 25);
            fullname_Label.TabIndex = 3;
            fullname_Label.Text = "Full name";
            // 
            // email_Label
            // 
            email_Label.AutoSize = true;
            email_Label.Location = new Point(3, 172);
            email_Label.Name = "email_Label";
            email_Label.Size = new Size(54, 25);
            email_Label.TabIndex = 4;
            email_Label.Text = "Email";
            // 
            // phoneNo_Label
            // 
            phoneNo_Label.AutoSize = true;
            phoneNo_Label.Location = new Point(3, 215);
            phoneNo_Label.Name = "phoneNo_Label";
            phoneNo_Label.Size = new Size(92, 25);
            phoneNo_Label.TabIndex = 5;
            phoneNo_Label.Text = "Phone no.";
            // 
            // pwdconfirm_TxtBox
            // 
            pwdconfirm_TxtBox.Location = new Point(193, 46);
            pwdconfirm_TxtBox.Name = "pwdconfirm_TxtBox";
            pwdconfirm_TxtBox.Size = new Size(440, 31);
            pwdconfirm_TxtBox.TabIndex = 3;
            pwdconfirm_TxtBox.UseSystemPasswordChar = true;
            pwdconfirm_TxtBox.TextChanged += TxtBox_TextChanged;
            // 
            // password_TxtBox
            // 
            password_TxtBox.Location = new Point(193, 3);
            password_TxtBox.Name = "password_TxtBox";
            password_TxtBox.Size = new Size(440, 31);
            password_TxtBox.TabIndex = 2;
            password_TxtBox.UseSystemPasswordChar = true;
            password_TxtBox.TextChanged += TxtBox_TextChanged;
            // 
            // username_Label
            // 
            username_Label.AutoSize = true;
            username_Label.Location = new Point(83, 122);
            username_Label.Name = "username_Label";
            username_Label.Size = new Size(91, 25);
            username_Label.TabIndex = 1;
            username_Label.Text = "Username";
            // 
            // username_TxtBox
            // 
            username_TxtBox.Location = new Point(273, 124);
            username_TxtBox.Name = "username_TxtBox";
            username_TxtBox.Size = new Size(440, 31);
            username_TxtBox.TabIndex = 1;
            username_TxtBox.TextChanged += TxtBox_TextChanged;
            // 
            // btn
            // 
            btn.Location = new Point(291, 457);
            btn.Name = "btn";
            btn.Size = new Size(182, 34);
            btn.TabIndex = 3;
            btn.Text = "create new user";
            btn.UseVisualStyleBackColor = true;
            btn.Click += btn_Click;
            // 
            // title_Label
            // 
            title_Label.AutoSize = true;
            title_Label.Font = new Font("Showcard Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point);
            title_Label.Location = new Point(228, 57);
            title_Label.Name = "title_Label";
            title_Label.Size = new Size(362, 40);
            title_Label.TabIndex = 14;
            title_Label.Text = "CREATE NEW ACCOUNT";
            // 
            // HandleAccount_Form
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 520);
            Controls.Add(title_Label);
            Controls.Add(btn);
            Controls.Add(username_TxtBox);
            Controls.Add(username_Label);
            Controls.Add(tableLayoutPanel);
            Name = "HandleAccount_Form";
            Text = "HandleAccount";
            Load += HandleAccount_Load;
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Label password_Label;
        private Label username_Label;
        private TextBox phoneNo_TxtBox;
        private TextBox email_TxtBox;
        private TextBox fullname_TxtBox;
        private TextBox priority_TxtBox;
        private TextBox pwdconfirm_TxtBox;
        private Label pwdconfirm_Label;
        private Label priority_Label;
        private Label fullname_Label;
        private Label email_Label;
        private Label phoneNo_Label;
        private TextBox password_TxtBox;
        private TextBox username_TxtBox;
        private Button btn;
        private Label title_Label;
    }
}