using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNetExamTask.DAO;

namespace AdoNetExamTask
{
    public partial class MainView : UserControl
    {

        public MainView()
        {
            InitializeComponent();
            Show();
        }
        Form1 Form1;

        private void selectBtn_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                StudentDAO studentDao = new StudentDAO();
                dataGridView1.DataSource = studentDao.GetStudents();
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                TeacherDAO teacherDao = new TeacherDAO();
                dataGridView1.DataSource = teacherDao.GetTeachers();
            }

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        } 
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectBtn.Enabled = false;
            insertBtn.Enabled = false;
            updateBtn.Enabled = false;
            deleteBtn.Enabled = false;
            if (comboBox1.SelectedIndex == 0)
            {
                if (Form1.Student != null)
                {
                    RoleActionDAO roleDao = new RoleActionDAO();
                    var a = roleDao.GetRoleActions(roleDao.GetRoleWithStudentId(Form1.Student.id).id);

                    if (a.SingleOrDefault(x => x.name == "SelectStudent") != null)
                        selectBtn.Enabled = true;
                    if (a.SingleOrDefault(x => x.name == "InsertStudent") != null)
                        insertBtn.Enabled = true;
                    if (a.SingleOrDefault(x => x.name == "UpdateStudent") != null)
                        updateBtn.Enabled = true;
                    if (a.SingleOrDefault(x => x.name == "DeleteStudent") != null)
                        deleteBtn.Enabled = true;
                }
                else if(Form1.Teacher!=null)
                {
                    RoleActionDAO roleDao = new RoleActionDAO(); 
                    var a = roleDao.GetRoleActions(roleDao.GetRoleWithTeacherId(Form1.Teacher.id).id);

                    if (a.SingleOrDefault(x => x.name == "SelectStudent") != null)
                        selectBtn.Enabled = true;
                    if (a.SingleOrDefault(x => x.name == "InsertStudent") != null)
                        insertBtn.Enabled = true;
                    if (a.SingleOrDefault(x => x.name == "UpdateStudent") != null)
                        updateBtn.Enabled = true;
                    if (a.SingleOrDefault(x => x.name == "DeleteStudent") != null)
                        deleteBtn.Enabled = true;
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                if (Form1.Student != null)
                {
                    RoleActionDAO roleDao = new RoleActionDAO();

                    var a = roleDao.GetRoleActions(roleDao.GetRoleWithStudentId(Form1.Student.id).id);

                    if (a.SingleOrDefault(x => x.name == "SelectStudent") != null)
                        selectBtn.Enabled = true;
                    if (a.SingleOrDefault(x => x.name == "InsertStudent") != null)
                        insertBtn.Enabled = true;
                    if (a.SingleOrDefault(x => x.name == "UpdateStudent") != null)
                        updateBtn.Enabled = true;
                    if (a.SingleOrDefault(x => x.name == "DeleteStudent") != null)
                        deleteBtn.Enabled = true;
                }
                else if (Form1.Teacher != null)
                {
                    RoleActionDAO roleDao = new RoleActionDAO();

                    var a = roleDao.GetRoleActions(roleDao.GetRoleWithTeacherId(Form1.Teacher.id).id);

                    if (a.SingleOrDefault(x => x.name == "SelectTeacher") != null)
                        selectBtn.Enabled = true;
                    if (a.SingleOrDefault(x => x.name == "InsertTeacher") != null)
                        insertBtn.Enabled = true;
                    if (a.SingleOrDefault(x => x.name == "UpdateTeacher") != null)
                        updateBtn.Enabled = true;
                    if (a.SingleOrDefault(x => x.name == "DeleteTeacher") != null)
                        deleteBtn.Enabled = true;
                }
            }
        }
    }
}
