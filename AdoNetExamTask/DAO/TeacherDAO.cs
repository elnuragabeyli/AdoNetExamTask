using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetExamTask.DAO
{
    public class TeacherDAO
    {
        public void AddTeacher(Teacher teacher)
        {
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                db.Teacher.Add(teacher);
                db.SaveChanges();
            }
        }

        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                teachers = db.Teacher.ToList();
            }
            return teachers;
        }

        public void UpdateTeacher(Teacher teacher)
        {
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                var updatedTeacher = db.Teacher.Where(x => x.id == teacher.id).FirstOrDefault();
                updatedTeacher.name = teacher.name;
                updatedTeacher.surname = teacher.surname;
                updatedTeacher.username = teacher.username;
                updatedTeacher.contact = teacher.contact;
                updatedTeacher.password = teacher.password;
                db.Teacher.Add(updatedTeacher);
                db.SaveChanges();
            }
        }

        public void DeleteTeacher(int id)
        {
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                var teacher = db.Teacher.Where(x => x.id == id).FirstOrDefault();
                db.Teacher.Remove(teacher);
                db.SaveChanges();
            }
        }
        public Teacher CheckLogin(string username, string password)
        {
            Teacher teacher = null;
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                teacher = db.Teacher.SingleOrDefault(a => a.username == username && a.password == password);
            }
            return teacher;
        }

    }
}
