using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetExamTask.DAO
{
    public class RoleActionDAO
    {
        public List<action> GetRoleActions(int id)
        {
            List<action> actions = null;
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                actions = db.role_action.Where(x => x.role_id == id).Select(a => a.action).ToList();
            }
            return actions;
        }

        public role GetRoleWithStudentId(int id)
        {
            role role;
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                role = db.role.SingleOrDefault(x => x.student_id == id);
            }
            return role;
        }
        public role GetRoleWithTeacherId(int id)
        {
            role role;
            using (AdoNetExamEntities1 db = new AdoNetExamEntities1())
            {
                role = db.role.SingleOrDefault(x => x.teacher_id == id);
            }
            return role;
        }
    }
}
