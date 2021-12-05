using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Athletics_Federation.ViewModel
{
    public class ViewParticipant
    {
        public bool AddParticipant(int idActivity, string Suname, string LastName, string MiddleName, int Gender, int IdTeam)
        {
            Regex specialSymbol = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$])");
            Regex searchFullNumber = new Regex("([0-9]|[ ])");

            MatchCollection matchSpecialSymbolSuname = null;
            MatchCollection matchSearchFullNumberSuname = null;

            MatchCollection matchSpecialSymbolLastName = null;
            MatchCollection matchSearchFullNumberLastName = null;

            MatchCollection matchSpecialSymbolMiddleName = null;
            MatchCollection matchSearchFullNumberMiddleName = null;



            if ( Suname != null && LastName != null && MiddleName != null )
            {


                matchSpecialSymbolSuname = specialSymbol.Matches(Suname);
                matchSearchFullNumberSuname = searchFullNumber.Matches(Suname);

                matchSpecialSymbolLastName = specialSymbol.Matches(LastName);
                matchSearchFullNumberLastName = searchFullNumber.Matches(LastName);

                matchSpecialSymbolMiddleName = specialSymbol.Matches(MiddleName);
                matchSearchFullNumberMiddleName = searchFullNumber.Matches(MiddleName);
            }

            Participant participant = new Participant();
            Activity activity = new Activity();
            AthleticsFederationDatabaseEntities db = new AthleticsFederationDatabaseEntities();

            try
            {

                if (idActivity < 0 || idActivity.ToString() == null || idActivity > int.MaxValue ) { return false; }
                else { participant.IdActivity = Convert.ToInt32(idActivity); }

                if (Suname == null || matchSpecialSymbolSuname.Count > 0 || matchSearchFullNumberSuname.Count == Suname.Length) { return false; }
                else { participant.Suname = Convert.ToString(Suname); }

                if (LastName == null || matchSpecialSymbolLastName.Count > 0 || matchSearchFullNumberLastName.Count == LastName.Length) { return false; }
                else { participant.FirstName = Convert.ToString(LastName); }

                if (MiddleName == null || matchSpecialSymbolMiddleName.Count > 0 || matchSearchFullNumberMiddleName.Count == MiddleName.Length) { return false; }
                else { participant.MiddleName = Convert.ToString(MiddleName); }

                if (Gender == null) { return false; }
                else { participant.IdGender = Convert.ToInt32(Gender); }

                if (IdTeam < 0 || IdTeam.ToString() == null || IdTeam > int.MaxValue) { return false; }
                else { participant.IdTeam = Convert.ToInt32(IdTeam); }

                try
                {
                    db.Participants.Add(participant);
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
