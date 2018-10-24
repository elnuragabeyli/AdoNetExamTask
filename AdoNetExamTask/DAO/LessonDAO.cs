using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetExamTask.DAO
{

    public class LessonDAO
    {
        public void AddLesson(Lesson lesson)
        {
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                db.Lesson.Add(lesson);
                db.SaveChanges();
            }
        }

        public List<Lesson> GetLessons()
        {
            List<Lesson> lessons = new List<Lesson>();
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                lessons = db.Lesson.ToList();
            }
            return lessons;
        }

        public void UpdateLesson(Lesson lesson)
        {
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                var updatedLesson = db.Lesson.Where(x => x.id == lesson.id).FirstOrDefault();
                updatedLesson.name = lesson.name;
                updatedLesson.price = lesson.price;
                db.Lesson.Add(updatedLesson);
                db.SaveChanges();
            }
        }

        public void DeleteLesson(int id)
        {
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                var lesson = db.Lesson.Where(x => x.id == id).FirstOrDefault();
                db.Lesson.Remove(lesson);
                db.SaveChanges();
            }
        }

    }
}
