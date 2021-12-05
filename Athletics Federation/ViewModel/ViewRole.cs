using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Athletics_Federation.ViewModel
{
    public class ViewRole
    {
        AthleticsFederationDatabaseEntities db;
        Role role;
        public bool AddRole(string NameRole)
        {
            Regex specialSymbol = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$])");
            Regex searchFullNumber = new Regex("([0-9]|[ ])");
            MatchCollection matchSpecialSymbol = null;
            MatchCollection matchSearchFullNumber = null;
            if (NameRole != null)
            {
                matchSpecialSymbol = specialSymbol.Matches(NameRole);
                matchSearchFullNumber = searchFullNumber.Matches(NameRole);
            }

            role = new Role();
            db = new AthleticsFederationDatabaseEntities();

            try
            {
                if (NameRole == null || matchSpecialSymbol.Count > 0 || matchSearchFullNumber.Count == NameRole.Length) { return false; }
                else { role.NameRole = Convert.ToString(NameRole); }

                try
                {
                    db.Roles.Add(role);
                    db.SaveChanges();
                }
                catch { }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteRole(int id)
        {
            //role = new Role();
            db = new AthleticsFederationDatabaseEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var DRow = db.Roles.Where(w => w.IdRole == num).FirstOrDefault();
                try
                {
                    db.Roles.Remove(DRow);
                    db.SaveChanges();
                }
                catch { }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
