namespace WinFormsApp
{
    partial class LogIn_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>

        /// <param name="disposing">true if managed resources should be disposed; 
        /// otherwise, false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            logInButton = new Button();
            newUser_Btn = new Button();
            username_Label = new Label();
            password_Label = new Label();
            password_TxtBox = new TextBox();
            username_TxtBox = new TextBox();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            admin_RadBtn = new RadioButton();
            logInType_GrpBox = new GroupBox();
            logInType_GrpBox.SuspendLayout();
            SuspendLayout();
            // 
            // logInButton
            // 
            logInButton.AccessibleName = "";
            logInButton.BackColor = Color.White;
            logInButton.Location = new Point(31, 171);
            logInButton.Name = "logInButton";
            logInButton.Size = new Size(200, 42);
            logInButton.TabIndex = 2;
            logInButton.Text = "console log in";
            logInButton.UseVisualStyleBackColor = false;
            logInButton.Click += LogInBtn_Click;
            // 
            // newUser_Btn
            // 
            newUser_Btn.Location = new Point(31, 235);
            newUser_Btn.Margin = new Padding(4);
            newUser_Btn.Name = "newUser_Btn";
            newUser_Btn.Size = new Size(200, 42);
            newUser_Btn.TabIndex = 3;
            newUser_Btn.Text = "create new user";
            newUser_Btn.UseVisualStyleBackColor = true;
            newUser_Btn.Click += newUser_Btn_Click;
            // 
            // username_Label
            // 
            username_Label.AutoSize = true;
            username_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            username_Label.Location = new Point(31, 34);
            username_Label.Name = "username_Label";
            username_Label.Size = new Size(126, 32);
            username_Label.TabIndex = 1;
            username_Label.Text = "Username:";
            // 
            // password_Label
            // 
            password_Label.AutoSize = true;
            password_Label.BackColor = Color.Transparent;
            password_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            password_Label.Location = new Point(31, 79);
            password_Label.Name = "password_Label";
            password_Label.Size = new Size(116, 32);
            password_Label.TabIndex = 4;
            password_Label.Text = "Password:";
            // 
            // password_TxtBox
            // 
            password_TxtBox.Location = new Point(163, 82);
            password_TxtBox.Name = "password_TxtBox";
            password_TxtBox.Size = new Size(335, 34);
            password_TxtBox.TabIndex = 1;
            password_TxtBox.UseSystemPasswordChar = true;
            // 
            // username_TxtBox
            // 
            username_TxtBox.Location = new Point(163, 37);
            username_TxtBox.Name = "username_TxtBox";
            username_TxtBox.Size = new Size(335, 34);
            username_TxtBox.TabIndex = 0;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(28, 71);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(74, 32);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "staff";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(28, 109);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(118, 32);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "customer";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // admin_RadBtn
            // 
            admin_RadBtn.AutoSize = true;
            admin_RadBtn.Location = new Point(28, 34);
            admin_RadBtn.Name = "admin_RadBtn";
            admin_RadBtn.Size = new Size(92, 32);
            admin_RadBtn.TabIndex = 0;
            admin_RadBtn.TabStop = true;
            admin_RadBtn.Text = "admin";
            admin_RadBtn.UseVisualStyleBackColor = true;
            // 
            // logInType_GrpBox
            // 
            logInType_GrpBox.Controls.Add(radioButton3);
            logInType_GrpBox.Controls.Add(radioButton2);
            logInType_GrpBox.Controls.Add(admin_RadBtn);
            logInType_GrpBox.Location = new Point(282, 147);
            logInType_GrpBox.Name = "logInType_GrpBox";
            logInType_GrpBox.Size = new Size(216, 150);
            logInType_GrpBox.TabIndex = 7;
            logInType_GrpBox.TabStop = false;
            logInType_GrpBox.Text = "Log in as:";
            // 
            // LogIn_Form
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(532, 309);
            Controls.Add(logInType_GrpBox);
            Controls.Add(newUser_Btn);
            Controls.Add(logInButton);
            Controls.Add(password_TxtBox);
            Controls.Add(username_TxtBox);
            Controls.Add(password_Label);
            Controls.Add(username_Label);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LogIn_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Log In Page";
            logInType_GrpBox.ResumeLayout(false);
            logInType_GrpBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button logInButton;
        private TextBox password_TxtBox;
        private TextBox username_TxtBox;
        private Label username_Label;
        private Label password_Label;
        private Button newUser_Btn;
        private RadioButton admin_RadBtn;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private GroupBox logInType_GrpBox;
    }
}