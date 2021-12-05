using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athletics_Federation.ViewModel
{
    public class ViewAuthorization
    {
        AthleticsFederationDatabaseEntities db = new AthleticsFederationDatabaseEntities();
        public bool Authorization(string login, string password)
        {
            if (login == "" || password == "")
            {
                return false;
            }
            if (db.Users.Select(item => item.Login + " " + item.Password).Contains(login + " " + password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
