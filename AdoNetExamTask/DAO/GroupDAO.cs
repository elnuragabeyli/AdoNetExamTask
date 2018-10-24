using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetExamTask.DAO
{
    public class GroupDAO
    {
        public void AddGroup(Group group)
        {
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                db.Group.Add(group);
                db.SaveChanges();
            }
        }

        public List<Group> GetGroups()
        {
            List<Group> groups = new List<Group>();
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                groups = db.Group.Include("Teacher").Include("Lesson").ToList();
            }
            return groups;
        }

        public void UpdateGroup(Group group)
        {
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                var updatedGroup = db.Group.Where(x => x.id == group.id).FirstOrDefault();
                updatedGroup.name = group.name;
                db.Group.Add(updatedGroup);
                db.SaveChanges();
            }
        }

        public void DeleteGroup(int id)
        {
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                var group = db.Group.Where(x => x.id == id).FirstOrDefault();
                db.Group.Remove(group);
                db.SaveChanges();
            }
        }

    }
}
