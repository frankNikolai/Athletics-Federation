using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Athletics_Federation.ViewModel
{
    public class ViewPersonCompetitions
    {
        public bool AddPerson(int IdParticipant, int Place, int IdGender, int IdCompetitions, int IdChampionship, string Result,  int Points)
        {
            Regex specialSymbol = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$])");
            Regex searchFullNumber = new Regex("([0-9]|[ ])");

            MatchCollection matchSpecialSymbol = null;
            MatchCollection matchSearchFullNumber = null;

            if (Result != null)
            {
                matchSpecialSymbol = specialSymbol.Matches(Result);
                matchSearchFullNumber = searchFullNumber.Matches(Result);
            }



                PersonCompetition personCompetition = new PersonCompetition();
            AthleticsFederationDatabaseEntities db = new AthleticsFederationDatabaseEntities();

            try
            {

                if (IdParticipant < 0 || IdParticipant.ToString() == null || IdParticipant > int.MaxValue) { return false; }
                else { personCompetition.IdPatricipant = Convert.ToInt32(IdParticipant); }

                if (Place < 0 || Place.ToString() == null || Place > int.MaxValue) { return false; }
                else { personCompetition.Place = Convert.ToInt32(Place); }

                if (IdGender < 0 || IdGender.ToString() == null || IdGender > int.MaxValue) { return false; }
                else { personCompetition.IdGender = Convert.ToInt32(IdGender); }

                if (IdCompetitions < 0 || IdCompetitions.ToString() == null || IdCompetitions > int.MaxValue) { return false; }
                else { personCompetition.IdCompetitions = Convert.ToInt32(IdCompetitions); }

                if (IdChampionship < 0 || IdChampionship.ToString() == null || IdChampionship > int.MaxValue) { return false; }
                else { personCompetition.IdChampionship = Convert.ToInt32(IdChampionship); }

                if (Result == null || matchSpecialSymbol.Count > 0 || matchSearchFullNumber.Count == Result.Length) { return false; }
                else { personCompetition.Result = Convert.ToString(Result); }

                if (Points < 0 || Points.ToString() == null || Points > int.MaxValue) { return false; }
                else { personCompetition.Points = Convert.ToInt32(Points); }

                try
                {
                    db.PersonCompetitions.Add(personCompetition);
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
