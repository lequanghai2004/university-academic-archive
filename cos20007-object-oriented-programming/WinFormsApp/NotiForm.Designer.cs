namespace WinFormsApp
{
    partial class NotiForm
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
            noti_Label = new Label();
            SuspendLayout();
            // 
            // noti_Label
            // 
            noti_Label.Anchor = AnchorStyles.None;
            noti_Label.AutoSize = true;
            noti_Label.Location = new Point(153, 63);
            noti_Label.Name = "noti_Label";
            noti_Label.Size = new Size(49, 25);
            noti_Label.TabIndex = 0;
            noti_Label.Text = "label";
            noti_Label.TextAlign = ContentAlignment.MiddleCenter;
            noti_Label.Click += noti_Label_Click;
            // 
            // NotiForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(345, 149);
            Controls.Add(noti_Label);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "NotiForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += NotiForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label noti_Label;
    }
}