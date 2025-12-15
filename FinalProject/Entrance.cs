using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace FinalProject
{
    public partial class Entrance : Form
    {
        public Entrance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }



        private void Entrance_Load(object sender, EventArgs e)
        {

        }

        private void Entrance_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.ShowDialog();

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            formRegister f1 = new formRegister();
            f1.ShowDialog();

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
        

            string email = tbxEmail.Text;
            string pass = tbxPassword.Text;
            bool inputsAreValid = string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass);

            if (inputsAreValid)
            {
                MessageBox.Show("Please fill in all fields.",
                   "Validation Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            var student = Program.studRepo.GetStudentByEmailAndPassword(
                tbxEmail.Text.Trim(),
                tbxPassword.Text.Trim()
            );

            if (student != null)        
            {
                MessageBox.Show($"Welcome {student.FirstName}!", "Loading Account..." ,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                USPSDashboard dashboard = new USPSDashboard(student); 
                dashboard.Show(); 
                this.Hide(); 
            }
            else
            {
                
                if (!Program.studRepo.EmailExists(tbxEmail.Text))
                {
                    MessageBox.Show("Account not found! Please register first." ,"Validation Error",
                        MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation); 
                }
                else
                {
                    MessageBox.Show("Invalid email or password!", "Log In Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


