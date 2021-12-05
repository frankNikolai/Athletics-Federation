using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Athletics_Federation.ViewModel
{
    public class ViewTeam
    {
        public bool AddTeam(string NameTeam)
        {
            Regex specialSymbol = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$])");
            Regex searchFullNumber = new Regex("([0-9]|[ ])");
            MatchCollection matchSpecialSymbol = null;
            MatchCollection matchSearchFullNumber = null;
            if (NameTeam != null)
            {
                matchSpecialSymbol = specialSymbol.Matches(NameTeam);
                matchSearchFullNumber = searchFullNumber.Matches(NameTeam);
            }

            Team team = new Team();
            AthleticsFederationDatabaseEntities db = new AthleticsFederationDatabaseEntities();

            try
            {
                if (NameTeam == null || matchSpecialSymbol.Count > 0 || matchSearchFullNumber.Count == NameTeam.Length) { return false; }
                else { team.NameTeam = Convert.ToString(NameTeam); }

                try
                {
                    db.Teams.Add(team);
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
