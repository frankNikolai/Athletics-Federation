using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Athletics_Federation.ViewModel
{
    public class ViewMainPanelOfJudges
    {
        public bool AddJudge( int idUser, string Suname, string FirstName, string MiddleName)
        {
            Regex specialSymbol = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$])");
            Regex searchFullNumber = new Regex("([0-9]|[ ])");

            MatchCollection matchSpecialSymbolSuname = null;
            MatchCollection matchSearchFullNumberSuname = null;

            MatchCollection matchSpecialSymbolFirstName = null;
            MatchCollection matchSearchFullNumberFirstName = null;

            MatchCollection matchSpecialSymbolMiddleName = null;
            MatchCollection matchSearchFullNumberMiddleName = null;

            if (Suname != null && FirstName != null && MiddleName != null)
            {
                matchSpecialSymbolSuname = specialSymbol.Matches(Suname);
                matchSearchFullNumberSuname = searchFullNumber.Matches(Suname);

                matchSpecialSymbolFirstName = specialSymbol.Matches(FirstName);
                matchSearchFullNumberFirstName = searchFullNumber.Matches(FirstName);

                matchSpecialSymbolMiddleName = specialSymbol.Matches(MiddleName);
                matchSearchFullNumberMiddleName = searchFullNumber.Matches(MiddleName);
            }

            MainPanelOfJudge mainPanelOfJudge = new MainPanelOfJudge();
            AthleticsFederationDatabaseEntities db = new AthleticsFederationDatabaseEntities();

            try
            {

                if (Suname == null || matchSpecialSymbolSuname.Count > 0 || matchSearchFullNumberSuname.Count == Suname.Length) { return false; }
                else { mainPanelOfJudge.Suname = Convert.ToString(Suname); }

                if (FirstName == null || matchSpecialSymbolFirstName.Count > 0 || matchSearchFullNumberFirstName.Count == FirstName.Length) { return false; }
                else { mainPanelOfJudge.FirstName = Convert.ToString(FirstName); }

                if (MiddleName == null || matchSpecialSymbolMiddleName.Count > 0 || matchSearchFullNumberMiddleName.Count == MiddleName.Length) { return false; }
                else { mainPanelOfJudge.MiddleName = Convert.ToString(MiddleName); }

                try
                {
                    db.MainPanelOfJudges.Add(mainPanelOfJudge);
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
