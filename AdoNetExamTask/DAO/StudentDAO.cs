using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetExamTask.DAO
{
    public class StudentDAO
    {
        public void AddStudent(Student student)
        {
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                db.Student.Add(student);
                db.SaveChanges();
            }
        }



        public void UpdateStudent(Student student)
        {
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                var updatedStudent = db.Student.Where(x => x.id == student.id).FirstOrDefault();
                updatedStudent.name = student.name;
                updatedStudent.surname = student.surname;
                updatedStudent.username = student.username;
                updatedStudent.contact = student.contact;
                updatedStudent.password = student.password;
                db.Student.Add(updatedStudent);
                db.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                var student = db.Student.Where(x => x.id == id).FirstOrDefault();
                db.Student.Remove(student);
                db.SaveChanges();
            }
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                students = db.Student.ToList();
            }
            return students;
        }

        public Student CheckLogin(string username, string password)
        {
            Student student = null;
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                student = db.Student.SingleOrDefault(a => a.username == username && a.password == password);
            }
            return student; 
        }

        


    }
}
