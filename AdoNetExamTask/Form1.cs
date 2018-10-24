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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            passwordBox.PasswordChar = '*';
            mainView1.Visible = false;
        }
        public Student Student = null;
        public Teacher Teacher = null;

        //public void ChangeUser(object user)
        //{
        //    if (user is Student)
        //    {
        //        Student = user as Student;
        //    }
        //    else
        //    {
        //        Teacher = user as Teacher;
        //    }
        //}

        StudentDAO StudentDAO = new StudentDAO();
        TeacherDAO TeacherDAO = new TeacherDAO();
        private void button1_Click(object sender, EventArgs e)//LOGIN
        {
            if (TeacherRadioButton.Checked == true)
            {
                TeacherDAO teacherDAO = new TeacherDAO();
                Teacher teacher = teacherDAO.CheckLogin(usernametextBox.Text, passwordBox.Text);
                if (teacher == null)
                    MessageBox.Show("Username or Password Wrong");
                else
                {
                   // ChangeUser(teacher);
                    Teacher = teacher;
                    mainView1.Visible = true;
                }
            }

            if (StudentRadioButton.Checked == true)
            {
                StudentDAO studentDao = new StudentDAO();
                Student student = studentDao.CheckLogin(usernametextBox.Text, passwordBox.Text);
                if (student == null)
                    MessageBox.Show("Username or Password Wrong");
                else
                {
                    // ChangeUser(student);
                    Student = student;
                    mainView1.Visible = true;
                }
            }

        }
        Registration n = new Registration();
        private void button2_Click(object sender, EventArgs e)//registration
        {
            n.Visible = true;
        }


    }
}
