using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FinalProject
{
    public partial class formRegister : Form
    {
        public formRegister()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegisterNow_Click(object sender, EventArgs e)
        {
            string firstName = tbxFirstName.Text.Trim();
            string lastName = tbxLastName.Text.Trim();
            string email = tbxEmailRegister.Text.Trim();
            string password = tbxCreatePassword.Text.Trim();
            string studentId = tbxIdnumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(tbxIdnumber.Text) ||
                string.IsNullOrWhiteSpace(tbxFirstName.Text) ||
                string.IsNullOrWhiteSpace(tbxLastName.Text) ||
                string.IsNullOrWhiteSpace(tbxEmailRegister.Text) ||
                string.IsNullOrWhiteSpace(tbxCreatePassword.Text))
            {
                MessageBox.Show("Please fill in all fields!");
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(firstName, @"\s{2,}") ||
                System.Text.RegularExpressions.Regex.IsMatch(lastName, @"\s{2,}") ||
                System.Text.RegularExpressions.Regex.IsMatch(email, @"\s{2,}") ||
                System.Text.RegularExpressions.Regex.IsMatch(password, @"\s{2,}") ||
                System.Text.RegularExpressions.Regex.IsMatch(studentId, @"\s{2,}"))
            {
                MessageBox.Show("Registration Error. Too much spaces", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            if (Program.studRepo.EmailExists(tbxEmailRegister.Text))
            {
                MessageBox.Show("Email already exists!", "Registration Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (Program.studRepo.StudentIDExists(tbxIdnumber.Text))
            {
                MessageBox.Show("Student ID already exists!", "Registration Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           

            var student = new Student
            {
                StudentID = tbxIdnumber.Text,
                FirstName = tbxFirstName.Text,
                LastName = tbxLastName.Text,
                Email = tbxEmailRegister.Text,
                Password = tbxCreatePassword.Text
            };

            Program.studRepo.AddStudent(student);
            MessageBox.Show("Registered successfully!");
            this.Close();
        }

        private void tbxIdnumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxEmailRegister_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tbxCreatePassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {
           
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }
    }
}
