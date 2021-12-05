using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Athletics_Federation.ViewModel
{
    public class ViewCompetitions
    {
        public bool AddCompetition(string NameCompetitions)
        {
            Regex specialSymbol = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$])");
            Regex searchFullNumber = new Regex("([0-9]|[ ])");
            MatchCollection matchSpecialSymbol = null;
            MatchCollection matchSearchFullNumber = null;
            if (NameCompetitions != null)
            {
                matchSpecialSymbol = specialSymbol.Matches(NameCompetitions);
                matchSearchFullNumber = searchFullNumber.Matches(NameCompetitions);
            }

            Competition competition = new Competition();
            AthleticsFederationDatabaseEntities db = new AthleticsFederationDatabaseEntities();

            try
            {
                if (NameCompetitions == null || matchSpecialSymbol.Count > 0 || matchSearchFullNumber.Count == NameCompetitions.Length) { return false; }
                else { competition.NameCompetition = Convert.ToString(NameCompetitions); }

                try
                {
                    db.Competitions.Add(competition);
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
