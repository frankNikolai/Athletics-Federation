using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Athletics_Federation.ViewModel
{
    public class ViewActivity
    {
        public bool AddActivity(int id, string NameActivity)
        {
            Regex specialSymbol = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$])");
            Regex searchFullNumber = new Regex("([0-9]|[ ])");
            MatchCollection matchSpecialSymbol = null;
            MatchCollection matchSearchFullNumber = null;
            if (NameActivity != null)
            {
                matchSpecialSymbol = specialSymbol.Matches(NameActivity);
                matchSearchFullNumber = searchFullNumber.Matches(NameActivity);
            }

            Activity activity = new Activity();
            AthleticsFederationDatabaseEntities db = new AthleticsFederationDatabaseEntities();

            try
            {
                if (id < 0 || id.ToString() == null || id > int.MaxValue) { return false; }
                else { activity.ID = Convert.ToInt32(id); }

                if (NameActivity == null || matchSpecialSymbol.Count > 0 || matchSearchFullNumber.Count == NameActivity.Length) { return false; }
                else { activity.NameActivity = Convert.ToString(NameActivity); }

                try
                {
                    db.Activities.Add(activity);
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
