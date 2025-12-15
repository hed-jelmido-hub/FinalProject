
namespace FinalProject
{
    partial class formRegister
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
            tbxFirstName = new TextBox();
            label3 = new Label();
            label4 = new Label();
            tbxEmailRegister = new TextBox();
            tbxLastName = new TextBox();
            labelFirstName = new Label();
            labelLastName = new Label();
            tbxIdnumber = new TextBox();
            labelIDNumber = new Label();
            label8 = new Label();
            labelEmailRegister = new Label();
            btnRegisterNow = new Button();
            tbxCreatePassword = new TextBox();
            labelCreatepassword = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(57, 64);
            label1.Name = "label1";
            label1.Size = new Size(260, 48);
            label1.TabIndex = 0;
            label1.Text = "Register your";
            label1.Click += label1_Click;
            // 
            // tbxFirstName
            // 
            tbxFirstName.Location = new Point(691, 134);
            tbxFirstName.Name = "tbxFirstName";
            tbxFirstName.Size = new Size(107, 31);
            tbxFirstName.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Black", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(57, 96);
            label3.Name = "label3";
            label3.Size = new Size(332, 96);
            label3.TabIndex = 3;
            label3.Text = "Account";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(57, 179);
            label4.Name = "label4";
            label4.Size = new Size(100, 32);
            label4.TabIndex = 4;
            label4.Text = "with us";
            label4.Click += label4_Click;
            // 
            // tbxEmailRegister
            // 
            tbxEmailRegister.Location = new Point(691, 252);
            tbxEmailRegister.Name = "tbxEmailRegister";
            tbxEmailRegister.Size = new Size(230, 31);
            tbxEmailRegister.TabIndex = 5;
            tbxEmailRegister.TextChanged += tbxEmailRegister_TextChanged;
            // 
            // tbxLastName
            // 
            tbxLastName.Location = new Point(814, 134);
            tbxLastName.Name = "tbxLastName";
            tbxLastName.Size = new Size(107, 31);
            tbxLastName.TabIndex = 6;
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.BackColor = Color.Transparent;
            labelFirstName.Location = new Point(691, 116);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(111, 25);
            labelFirstName.TabIndex = 7;
            labelFirstName.Text = "First Name*";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.BackColor = Color.Transparent;
            labelLastName.Location = new Point(814, 116);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(101, 25);
            labelLastName.TabIndex = 8;
            labelLastName.Text = "Last Name";
            // 
            // tbxIdnumber
            // 
            tbxIdnumber.Location = new Point(691, 196);
            tbxIdnumber.Name = "tbxIdnumber";
            tbxIdnumber.Size = new Size(230, 31);
            tbxIdnumber.TabIndex = 9;
            tbxIdnumber.TextChanged += tbxIdnumber_TextChanged;
            // 
            // labelIDNumber
            // 
            labelIDNumber.AutoSize = true;
            labelIDNumber.BackColor = Color.Transparent;
            labelIDNumber.Location = new Point(775, 168);
            labelIDNumber.Name = "labelIDNumber";
            labelIDNumber.Size = new Size(63, 25);
            labelIDNumber.TabIndex = 10;
            labelIDNumber.Text = "ID no.";
            labelIDNumber.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(814, 168);
            label8.Name = "label8";
            label8.Size = new Size(0, 25);
            label8.TabIndex = 12;
            label8.Click += label8_Click;
            // 
            // labelEmailRegister
            // 
            labelEmailRegister.AutoSize = true;
            labelEmailRegister.BackColor = Color.Transparent;
            labelEmailRegister.Location = new Point(775, 230);
            labelEmailRegister.Name = "labelEmailRegister";
            labelEmailRegister.Size = new Size(58, 25);
            labelEmailRegister.TabIndex = 13;
            labelEmailRegister.Text = "Email";
            labelEmailRegister.Click += label9_Click;
            // 
            // btnRegisterNow
            // 
            btnRegisterNow.Location = new Point(691, 351);
            btnRegisterNow.Name = "btnRegisterNow";
            btnRegisterNow.Size = new Size(230, 36);
            btnRegisterNow.TabIndex = 14;
            btnRegisterNow.Text = "Register Now";
            btnRegisterNow.UseVisualStyleBackColor = true;
            btnRegisterNow.Click += btnRegisterNow_Click;
            // 
            // tbxCreatePassword
            // 
            tbxCreatePassword.Location = new Point(691, 314);
            tbxCreatePassword.Name = "tbxCreatePassword";
            tbxCreatePassword.PasswordChar = '*';
            tbxCreatePassword.Size = new Size(230, 31);
            tbxCreatePassword.TabIndex = 15;
            tbxCreatePassword.TextChanged += tbxCreatePassword_TextChanged;
            // 
            // labelCreatepassword
            // 
            labelCreatepassword.AutoSize = true;
            labelCreatepassword.Location = new Point(726, 286);
            labelCreatepassword.Name = "labelCreatepassword";
            labelCreatepassword.Size = new Size(152, 25);
            labelCreatepassword.TabIndex = 16;
            labelCreatepassword.Text = "Create Password";
            // 
            // formRegister
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Untitled_design;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(967, 458);
            Controls.Add(label1);
            Controls.Add(labelCreatepassword);
            Controls.Add(tbxCreatePassword);
            Controls.Add(btnRegisterNow);
            Controls.Add(labelEmailRegister);
            Controls.Add(label8);
            Controls.Add(labelIDNumber);
            Controls.Add(tbxIdnumber);
            Controls.Add(labelLastName);
            Controls.Add(labelFirstName);
            Controls.Add(tbxLastName);
            Controls.Add(tbxEmailRegister);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tbxFirstName);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "formRegister";
            Text = "formRegistar";
            ResumeLayout(false);
            PerformLayout();
        }





        #endregion

        private Label label1;
        private TextBox tbxFirstName;
        private Label label3;
        private Label label4;
        private TextBox tbxEmailRegister;
        private TextBox tbxLastName;
        private Label labelFirstName;
        private Label labelLastName;
        private TextBox tbxIdnumber;
        private Label labelIDNumber;
        private Label label8;
        private Label labelEmailRegister;
        private Button btnRegisterNow;
        private TextBox tbxCreatePassword;
        private Label labelCreatepassword;
    }
}