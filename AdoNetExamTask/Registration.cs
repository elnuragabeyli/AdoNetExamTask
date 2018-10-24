using AdoNetExamTask.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetExamTask
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            passwordTextBox.PasswordChar = '*';
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                if (teacherRadioButton.Checked == true)
                {
                    Teacher teacher = new Teacher();
                    teacher.name = nameTextBox.Text;
                    teacher.surname = surnameTextBox.Text;
                    teacher.username = usernameTextBox.Text;
                    teacher.contact = contactTextBox.Text;
                    teacher.password = passwordTextBox.Text;
                    db.Teacher.Add(teacher);
                    db.SaveChanges();
                    Console.WriteLine("Written to databse");
                    this.Visible=false; 
                }
                if (studentRadioButton.Checked == true)
                {
                    Student student = new Student();
                    student.name = nameTextBox.Text;
                    student.surname = surnameTextBox.Text;
                    student.username = usernameTextBox.Text;
                    student.contact = contactTextBox.Text;
                    student.password = passwordTextBox.Text;
                    db.Student.Add(student);
                    db.SaveChanges();
                    Console.WriteLine("Written to databse");
                    this.Visible = false; 
                }
            }
        }  
    }
}
