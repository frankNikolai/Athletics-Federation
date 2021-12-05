using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Athletics_Federation.ViewModel
{
    public class ViewResultOfTeamPrimacy
    {
        public bool AddChampionship(int IdChampionship, int Place, int IdTeam, int Points)
        {

            ResultOfTeamPrimacy resultOfTeamPrimacy = new ResultOfTeamPrimacy();
            AthleticsFederationDatabaseEntities db = new AthleticsFederationDatabaseEntities();

            try
            {
                if (IdChampionship <= 0 || IdChampionship.ToString() == null || IdChampionship > int.MaxValue) { return false; }
                else { resultOfTeamPrimacy.IdChempionship = Convert.ToInt32(IdChampionship); }

                if (Place <= 0 || Place.ToString() == null || Place > int.MaxValue) { return false; }
                else { resultOfTeamPrimacy.Place = Convert.ToInt32(Place); }

                if (IdTeam <= 0 || IdTeam.ToString() == null || IdTeam > int.MaxValue) { return false; }
                else { resultOfTeamPrimacy.IdTeams = Convert.ToInt32(IdTeam); }

                if (Points <= 0 || Points.ToString() == null || Points > int.MaxValue) { return false; }
                else { resultOfTeamPrimacy.Points = Convert.ToInt32(Points); }

                try
                {
                    db.ResultOfTeamPrimacies.Add(resultOfTeamPrimacy);
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
