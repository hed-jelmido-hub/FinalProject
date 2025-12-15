namespace FinalProject
{
    partial class Entrance
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
            label1 = new Label();
            labelEmail = new Label();
            labelPassword = new Label();
            label4 = new Label();
            tbxEmail = new TextBox();
            tbxPassword = new TextBox();
            label5 = new Label();
            btnRegister = new Button();
            btnLogIn = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe Print", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(15, 12);
            label1.Name = "label1";
            label1.Size = new Size(566, 105);
            label1.TabIndex = 0;
            label1.Text = "Welcome Marian!";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.BackColor = Color.Transparent;
            labelEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEmail.ForeColor = Color.Black;
            labelEmail.Location = new Point(135, 174);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(69, 28);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "Email:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.BackColor = Color.Transparent;
            labelPassword.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPassword.ForeColor = Color.Black;
            labelPassword.Location = new Point(94, 236);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(114, 28);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(237, 244);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 3;
            // 
            // tbxEmail
            // 
            tbxEmail.Location = new Point(203, 162);
            tbxEmail.Margin = new Padding(3, 4, 3, 4);
            tbxEmail.Multiline = true;
            tbxEmail.Name = "tbxEmail";
            tbxEmail.Size = new Size(215, 38);
            tbxEmail.TabIndex = 5;
            tbxEmail.TextChanged += tbxEmail_TextChanged;
            // 
            // tbxPassword
            // 
            tbxPassword.Location = new Point(203, 225);
            tbxPassword.Margin = new Padding(3, 4, 3, 4);
            tbxPassword.Multiline = true;
            tbxPassword.Name = "tbxPassword";
            tbxPassword.PasswordChar = '*';
            tbxPassword.Size = new Size(215, 38);
            tbxPassword.TabIndex = 9;
            tbxPassword.TextChanged += tbxPassword_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(62, 124);
            label5.Name = "label5";
            label5.Size = new Size(214, 20);
            label5.TabIndex = 10;
            label5.Text = "Please fill up the Following:";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Navy;
            btnRegister.Font = new Font("Segoe UI Emoji", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(82, 330);
            btnRegister.Margin = new Padding(3, 4, 3, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(86, 30);
            btnRegister.TabIndex = 11;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = Color.Navy;
            btnLogIn.Font = new Font("Segoe UI Emoji", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogIn.ForeColor = Color.White;
            btnLogIn.Location = new Point(203, 330);
            btnLogIn.Margin = new Padding(3, 4, 3, 4);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(86, 30);
            btnLogIn.TabIndex = 12;
            btnLogIn.Text = "Log in";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Navy;
            btnExit.Font = new Font("Segoe UI Emoji", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(336, 330);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(86, 30);
            btnExit.TabIndex = 13;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // Entrance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Untitled_design;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(615, 378);
            Controls.Add(btnExit);
            Controls.Add(btnLogIn);
            Controls.Add(btnRegister);
            Controls.Add(label5);
            Controls.Add(tbxPassword);
            Controls.Add(tbxEmail);
            Controls.Add(label4);
            Controls.Add(labelPassword);
            Controls.Add(labelEmail);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Entrance";
            FormClosing += Entrance_FormClosing;
            Load += Entrance_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelEmail;
        private Label labelPassword;
        private Label label4;
        private TextBox tbxEmail;
        private TextBox tbxPassword;
        private Label label5;
        private Button btnRegister;
        private Button btnLogIn;
        private Button btnExit;
    }
}