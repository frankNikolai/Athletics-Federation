using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Athletics_Federation.ViewModel
{
    public class ViewChampionships
    {
        public bool AddChampionship(string NameChampionship, DateTime TheDateOfTheBeginning, DateTime TheDateOfTheEnding)
        {
            Regex specialSymbol = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$])");
            Regex searchFullNumber = new Regex("([0-9]|[ ])");
            MatchCollection matchSpecialSymbol = null;
            MatchCollection matchSearchFullNumber = null;
            if (NameChampionship != null)
            {
                matchSpecialSymbol = specialSymbol.Matches(NameChampionship);
                matchSearchFullNumber = searchFullNumber.Matches(NameChampionship);
            }

            Championship championship = new Championship();
            AthleticsFederationDatabaseEntities db = new AthleticsFederationDatabaseEntities();

            try
            {

                if (NameChampionship == null || matchSpecialSymbol.Count > 0 || matchSearchFullNumber.Count == NameChampionship.Length) { return false; }
                else { championship.NameChampionship = Convert.ToString(NameChampionship); }

                if (TheDateOfTheBeginning == null || TheDateOfTheBeginning.ToString() == null) { return false; }
                else { championship.TheDateOfTheBeginning = Convert.ToDateTime(TheDateOfTheBeginning.ToString()); }

                if (TheDateOfTheEnding == null || TheDateOfTheEnding.ToString() == null) { return false; }
                else { championship.TheDateOfTheEnding = Convert.ToDateTime(TheDateOfTheEnding.ToString()); }

                try
                {
                    db.Championships.Add(championship);
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
