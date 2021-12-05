using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Athletics_Federation.ViewModel
{
    public class ViewUsers
    {
        AthleticsFederationDatabaseEntities db;
        User user;
        public bool AddUsers(string Login, string Password, int IdRole)
        {
            Regex specialSymbol = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$])");
            Regex searchFullNumber = new Regex("([0-9]|[ ])");

            MatchCollection matchSpecialSymbolLogin = null;
            MatchCollection matchSearchFullNumberLogin = null;

            MatchCollection matchSpecialSymbolPassword = null;

            if (Login != null && Password != null)
            {
                matchSpecialSymbolLogin = specialSymbol.Matches(Login);
                matchSearchFullNumberLogin = searchFullNumber.Matches(Login);

                matchSpecialSymbolPassword = specialSymbol.Matches(Password);

            }
            user = new User();

            db = new AthleticsFederationDatabaseEntities();

            try
            {

                if (Login == null || matchSpecialSymbolLogin.Count > 0 || matchSearchFullNumberLogin.Count == Login.Length) { return false; }
                else { user.Login = Convert.ToString(Login); }

                if (Password == null || matchSpecialSymbolPassword.Count > 0) { return false; }
                else { user.Password = Convert.ToString(Password); }

                if (IdRole < 0 || IdRole.ToString() == null || IdRole > int.MaxValue) { return false; }
                else { user.IdRole = Convert.ToInt32(IdRole); }

                try
                {
                    db.Users.Add(user);
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
        public bool DeleteUsers(int id)
        {
            Regex specialSymbol = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$])");
            Regex SearchString = new Regex("[A-Z]|[А-Я]");
            MatchCollection matchSpecialSymbol = null;
            MatchCollection matchSearchString = null;

            if (id.ToString() != null )
            {
                matchSpecialSymbol = specialSymbol.Matches(Convert.ToString(id));
                matchSearchString = SearchString.Matches(Convert.ToString(id));
            }
            user = new User();

            db = new AthleticsFederationDatabaseEntities();
            StringBuilder error = new StringBuilder();
            try
            {
                int num = Convert.ToInt32(id);
                if (matchSpecialSymbol.Count > 0 || id > int.MaxValue) { return false; }
                if (matchSearchString.Count == id.ToString().Length || id <= 0) { return false; }

                try
                {
                    var DRow = db.Users.Where(w => w.ID == num).FirstOrDefault();
                    db.Users.Remove(DRow);
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


        public bool UpdateUsers(int id, string login, string password, int IdRole)
        {
            user = new User();

            db = new AthleticsFederationDatabaseEntities();

            Regex specialSymbol = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$])");
            Regex searchFullNumber = new Regex("([0-9]|[ ])");

            MatchCollection matchSpecialSymbolLogin = null;
            MatchCollection matchSearchFullNumberLogin = null;

            MatchCollection matchSpecialSymbolPassword = null;

            if (login != null && password != null)
            {
                matchSpecialSymbolLogin = specialSymbol.Matches(login);
                matchSearchFullNumberLogin = searchFullNumber.Matches(login);

                matchSpecialSymbolPassword = specialSymbol.Matches(password);

            }

            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(id.ToString())) { return false; }
            else if (login == "" || matchSpecialSymbolLogin.Count > 0 || matchSearchFullNumberLogin.Count == login.Length) { return false; }
            else if (password == "") { return false; }
            else if (IdRole.ToString() == "" || matchSpecialSymbolPassword.Count > 0) { return false; }
            else
            {
                try
                {
                    int num = Convert.ToInt32(id);
                    var URow = db.Users.Where(w => w.ID == num).FirstOrDefault();
                    URow.Login = Convert.ToString(login);
                    URow.Password = Convert.ToString(password);
                    URow.Role.NameRole = Convert.ToString(IdRole);
                    db.SaveChanges();
                }
                catch { }
                return true;
            }
        }
    }
}

