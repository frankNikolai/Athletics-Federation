using Microsoft.VisualStudio.TestTools.UnitTesting;
using Athletics_Federation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athletics_Federation.ViewModel.Tests
{
    [TestClass()]
    public class UnitTest
    {
        [TestClass()]
        public class AuthorizationTest
        {
            ViewModel.ViewAuthorization viewAuthorization = new ViewAuthorization();
            [TestMethod()]
            public void AuthorizationTestingCorrectData()
            {
                
                //Arange
                bool actual = true, expected = true;
                string login = "judge";
                string password = "judge1";
                //Act
                try
                {
                    actual = viewAuthorization.Authorization(login, password);
                }
                catch { }

                login = "Administrator";
                password = "admin123";
                try
                {
                    actual = viewAuthorization.Authorization(login, password);
                }
                catch { }
                //Assert
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AuthorizationTestingIncorrectData()
            {
                //Arange
                bool actual = true, expected = true;
                string login = "Maestro";
                string password = "Killer123";
                //Act
                try
                {
                    actual = viewAuthorization.Authorization(login, password);
                }
                catch { }

                login = null;
                password = null;
                try
                {
                    actual = viewAuthorization.Authorization(login, password);
                }
                catch { }
                login = "ikikik";
                password = "lol";
                try
                {
                    actual = viewAuthorization.Authorization(login, password);
                }
                catch { }
                //Assert
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AuthorizationTestingBorderData()
            {
                //Arange
                bool actual = true, expected = true;
                string login = "Judge";
                string password = "hahahahahah";
                //Act
                try
                {
                    actual = viewAuthorization.Authorization(login, password);
                }
                catch { }
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }



        [TestClass()]
        public class AddRole
        {
            ViewModel.ViewRole role = new ViewRole();
            [TestMethod()]
            public void AddRoleTestingCorrectData()
            {

                //Arange
                bool actual = true, expected = true;
                string name = "крапива";
                //Act
                try
                {
                    actual = role.AddRole( name);
                }
                catch { }
                name = "лопух";
                try
                {
                    actual = role.AddRole( name);
                }
                catch { }
                //Assert
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddRoleTestingIncorrectData()
            {
                //Arange
                bool actual = false, expected = false;
                string name = "1%$#$";
                //Act
                try
                {
                    actual = role.AddRole(name);
                }
                catch { }

                name = null;
                try
                {
                    actual = role.AddRole(name);
                }
                catch { }
                name = "143242352";
                try
                {
                    actual = role.AddRole( name);
                }
                catch { }
                //Assert
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddRoleTestingBorderData()
            {
                //Arange
                bool actual = false, expected = false;
                string name = "111111";
                //Act
                try
                {
                    actual = role.AddRole(name);
                }
                catch { }
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }


        [TestClass()]
        public class AddCompetition
        {
            ViewModel.ViewCompetitions viewCompetitions = new ViewCompetitions();
            [TestMethod()]
            public void AddCompetitionTestingCorrectData()
            {
                bool actual = true, expected = true;

                string name = "Трусцой";
                try
                {
                    actual = viewCompetitions.AddCompetition(name);
                }
                catch { }
                
                name = "Забег";
                try
                {
                    actual = viewCompetitions.AddCompetition(name);
                }
                catch { }
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddCompetitionTestingIncorrectData()
            {
                bool actual = false, expected = false;

                string name = null;

                try
                {
                    actual = viewCompetitions.AddCompetition(name);
                }
                catch { }
                name = "&&%%@#$";
                try
                {
                    actual = viewCompetitions.AddCompetition(name);
                }
                catch { }
                
                name = "9432";
                try
                {
                    actual = viewCompetitions.AddCompetition(name);
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddCompetitionTestingBorderData()
            {
                bool actual = false, expected = false;

                string name = "677hhh&";

                try
                {
                    actual = viewCompetitions.AddCompetition(name);
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass()]
        public class AddTeam
        {
            ViewModel.ViewTeam viewTeam = new ViewTeam();
            [TestMethod()]
            public void AddTeamTestingCorrectData()
            {
                bool actual = true, expected = true;

                string name = "Рваные";
                try
                {
                    actual = viewTeam.AddTeam(name);
                }
                catch { }

                name = "Krick";
                try
                {
                    actual = viewTeam.AddTeam(name);
                }
                catch { }
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddTeamTestingIncorrectData()
            {
                bool actual = false, expected = false;

                string name = null;

                try
                {
                    actual = viewTeam.AddTeam(name);
                }
                catch { }
                name = "&&%";
                try
                {
                    actual = viewTeam.AddTeam(name);
                }
                catch { }

                name = "7777";
                try
                {
                    actual = viewTeam.AddTeam(name);
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddTeamTestingBorderData()
            {
                bool actual = false;

                string name = "jfds21#";
                bool expected = false;

                try
                {
                    actual = viewTeam.AddTeam(name);
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass()]
        public class AddUsers
        {
            ViewModel.ViewUsers viewUsers = new ViewUsers();
            [TestMethod()]
            public void AddUsersTestingCorrectData()
            {
                bool actual = true, expected = true;

                string login = "Руканоид";
                string password = "ffffff";
                int IdRole = 3;

                try
                {
                    actual = viewUsers.AddUsers(login, password, IdRole);
                }
                catch { }

                login = "бла-бла-бла";
                password = "ЭЭЭЭЭ";
                IdRole = 2;
                try
                {
                    actual = viewUsers.AddUsers(login, password, IdRole);
                }
                catch { }
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddUsersTestingIncorrectData()
            {
                bool actual = false, expected = false;

                string login = "Руканоид#@#";
                string password = "999999%";
                string NameRole = "Грек%";

                try
                {
                    actual = viewUsers.AddUsers(login, password, Convert.ToInt32(NameRole));
                }
                catch { }
                login = null;
                password = null;
                NameRole = null;
                try
                {
                    actual = viewUsers.AddUsers(login, password, Convert.ToInt32(NameRole));
                }
                catch { }

                login = "sdfwr23er23eds";
                password = "fsdfsff";
                NameRole = "asdfsdfsd";
                try
                {
                    actual = viewUsers.AddUsers(login, password, Convert.ToInt32(NameRole));
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddUsersTestingBorderData()
            {
                bool actual = false, expected = false;

                string login = "222222";
                string password = "111111";
                string NameRole = "2";

                try
                {
                    actual = viewUsers.AddUsers(login, password, Convert.ToInt32(NameRole));
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
        }


        [TestClass()]
        public class DeleteUsers
        {
            ViewModel.ViewUsers viewUsers = new ViewUsers();
            [TestMethod()]
            public void DeleteUsersTestingCorrectData()
            {
                bool actual = true, expected = true;

                int id = 5;

                try
                {
                    actual = viewUsers.DeleteUsers(id);
                }
                catch { }

                id = 6;
                try
                {
                    actual = viewUsers.DeleteUsers(id);
                }
                catch { }
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void DeleteUsersTestingIncorrectData()
            {
                bool actual = false, expected = false;

                string id = null;

                try
                {
                    actual = viewUsers.DeleteUsers(Convert.ToInt32(id));
                }
                catch { }
                id = "$$#!";
                try
                {
                    actual = viewUsers.DeleteUsers(Convert.ToInt32(id));
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void DeleteUsersTestingBorderData()
            {
                bool actual = false, expected = false;

                string id = "$$";

                try
                {
                    actual = viewUsers.DeleteUsers(Convert.ToInt32(id));
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass()]
        public class UpdateUsers
        {
            ViewModel.ViewUsers viewUsers = new ViewUsers();
            [TestMethod()]
            public void UpdateUsersTestingCorrectData()
            {
                bool actual = true, expected = true;

                int id = 3;
                string login = "Руканоид";
                string password = "ffffff";
                int IdRole = 3;

                try
                {
                    actual = viewUsers.UpdateUsers(id, login, password, IdRole);
                }
                catch { }

                id = 4;
                login = "бла-бла-бла";
                password = "ЭЭЭЭЭ";
                IdRole = 2;
                try
                {
                    actual = viewUsers.UpdateUsers(id, login, password, IdRole);
                }
                catch { }
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void UpdateUsersTestingIncorrectData()
            {
                bool actual = false, expected = false;

                string id = "3f";
                string login = "125897345";
                string password = "23213123";
                string IdRole = "3";

                try
                {
                    actual = viewUsers.UpdateUsers(Convert.ToInt32(id), login, password, Convert.ToInt32(IdRole));
                }
                catch { }
                id = null;
                login = null;
                password = null;
                IdRole = null;
                try
                {
                    actual = viewUsers.UpdateUsers(Convert.ToInt32(id), login, password, Convert.ToInt32(IdRole));
                }
                catch { }

                id = "#@#$";
                login = "sdfwr23er23eds";
                password = "fsdfsff";
                IdRole = "asdfsdfsd";
                try
                {
                    actual = viewUsers.UpdateUsers(Convert.ToInt32(id), login, password, Convert.ToInt32(IdRole));
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void UpdateUsersTestingBorderData()
            {
                bool actual = false, expected = false;

                int id = 3;
                string login = "234235435";
                string password = "12431";
                int IdRole = 3;

                try
                {
                    actual = viewUsers.UpdateUsers(id, login, password, IdRole);
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
        }



        [TestClass()]
        public class AddChampionships
        {
            ViewModel.ViewChampionships ViewChampionships = new ViewChampionships();
            [TestMethod()]
            public void AddChampionshipsTestingCorrectData()
            {
                bool actual = true, expected = true;

                string name = "Руканоид";
                string TheDateOfTheBeginning = "11-11-11";
                string TheDateOfTheEnding = "12-12-12";

                try
                {
                    actual = ViewChampionships.AddChampionship( name, 
                        Convert.ToDateTime(TheDateOfTheBeginning), Convert.ToDateTime(TheDateOfTheEnding));
                }
                catch { }

                name = "Xasdа123";
                TheDateOfTheBeginning = "11-11-12";
                TheDateOfTheEnding = "12-11-11";
                try
                {
                    actual = actual = ViewChampionships.AddChampionship(name,
                        Convert.ToDateTime(TheDateOfTheBeginning), Convert.ToDateTime(TheDateOfTheEnding));
                }
                catch { }
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddChampionshipsTestingIncorrectData()
            {
                bool actual = false, expected = false;

                string name = "in";
                string TheDateOfTheBeginning = "fdsf";
                string TheDateOfTheEnding = "vafla";

                try
                {
                    actual = actual = ViewChampionships.AddChampionship(
                        name, Convert.ToDateTime(TheDateOfTheBeginning), Convert.ToDateTime(TheDateOfTheEnding));
                }
                catch { }
                name = "%#$#";
                TheDateOfTheBeginning = "$$$$";
                TheDateOfTheEnding = "%%%%%";
                try
                {
                    actual = actual = ViewChampionships.AddChampionship(name,
                        Convert.ToDateTime(TheDateOfTheBeginning), Convert.ToDateTime(TheDateOfTheEnding));
                }
                catch { }

                name = null;
                TheDateOfTheBeginning = null;
                TheDateOfTheEnding = null;
                try
                {
                    actual = actual = ViewChampionships.AddChampionship(name,
                        Convert.ToDateTime(TheDateOfTheBeginning), Convert.ToDateTime(TheDateOfTheEnding));
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddChampionshipsTestingBorderData()
            {
                bool actual = false, expected = false;

                string name = "111111";
                string TheDateOfTheBeginning = "12-12-12";
                string TheDateOfTheEnding = "20-12-12";

                try
                {
                    actual = actual = actual = ViewChampionships.AddChampionship( name,
                        Convert.ToDateTime(TheDateOfTheBeginning), Convert.ToDateTime(TheDateOfTheEnding));
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass()]
        public class AddMainPanelOfJudge
        {
            ViewModel.ViewMainPanelOfJudges ViewMainPanelOfJudges = new ViewMainPanelOfJudges();
            [TestMethod()]
            public void AddMainPanelOfJudgeTestingCorrectData()
            {
                bool actual = true, expected = true;

                int iduser = 3;
                string Suname = "Петров";
                string FirstName = "Василий";
                string MiddleName = "Генадьевич";

                try
                {
                    actual = ViewMainPanelOfJudges.AddJudge(iduser, Suname, FirstName, MiddleName);
                }
                catch { }
                iduser = 5;
                Suname = "Мамов";
                FirstName = "Иннокентий";
                MiddleName = "Васильевич";
                try
                {
                    actual = ViewMainPanelOfJudges.AddJudge(iduser, Suname, FirstName, MiddleName);
                }
                catch { }
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddMainPanelOfJudgeTestingIncorrectData()
            {
                bool actual = false, expected = false;

                string iduser = "$$#";
                string Suname = "^%#$";
                string FirstName = "$#$#$";
                string MiddleName = "Ад%$%#54мик";

                try
                {
                    actual = ViewMainPanelOfJudges.AddJudge(Convert.ToInt32(iduser), Suname, FirstName, MiddleName);
                }
                catch { }
                iduser = "sdfsd";
                Suname = "5бла-sdfsd-бла5";
                FirstName = "ЭЭЭЭЭgdf%$";
                MiddleName = "Hello$$";
                try
                {
                    actual = ViewMainPanelOfJudges.AddJudge(Convert.ToInt32(iduser), Suname, FirstName, MiddleName);
                }
                catch { }

                iduser = null;
                Suname = null;
                FirstName = null;
                MiddleName = null;
                try
                {
                    actual = ViewMainPanelOfJudges.AddJudge(Convert.ToInt32(iduser), Suname, FirstName, MiddleName);
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddMainPanelOfJudgeTestingBorderData()
            {
                bool actual = false, expected = false;


                string iduser = "10";
                string Suname = "Рав";
                string FirstName = "111111";
                string MiddleName = "Адмик";

                try
                {
                    actual = ViewMainPanelOfJudges.AddJudge(Convert.ToInt32(iduser), Suname, FirstName, MiddleName);
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
        }




        [TestClass()]
        public class AddResulOfTeamPrimacy
        {
            ViewModel.ViewResultOfTeamPrimacy viewResultOfTeamPrimacy = new ViewResultOfTeamPrimacy();
            [TestMethod()]
            public void AddResulOfTeamPrimacyTestingCorrectData()
            {
                bool actual = true, expected = true;

                int Name = 1;
                int Place = 15;
                int Team = 3;
                int Points = 20;

                try
                {
                    actual = viewResultOfTeamPrimacy.AddChampionship( Name, Place, Team, Points);
                }
                catch { }

                Name = 2;
                Place = 6;
                Team = 4;
                Points = 7;
                try
                {
                    actual = viewResultOfTeamPrimacy.AddChampionship(Name, Place, Team, Points);
                }
                catch { }
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddResulOfTeamPrimacyTestingIncorrectData()
            {
                bool actual = false, expected = false;

                string Name = "Что";
                string Place = "15f";
                string Team = "ffffff";
                string Points = "20d";

                try
                {
                    actual = viewResultOfTeamPrimacy.AddChampionship(Convert.ToInt32(Name), Convert.ToInt32(Place),
                        Convert.ToInt32(Team), Convert.ToInt32(Points));
                }
                catch { }

                Name = null;
                Place = null;
                Team = null;
                Points = null;
                try
                {
                    actual = viewResultOfTeamPrimacy.AddChampionship(Convert.ToInt32(Name), Convert.ToInt32(Place),
                         Convert.ToInt32(Team), Convert.ToInt32(Points));
                }
                catch { }

                Name = "5;№";
                Place = "6№;№%)*(Г?";
                Team = "4535346574;%";
                Points = "7;;%%%";
                try
                {
                    actual = viewResultOfTeamPrimacy.AddChampionship(Convert.ToInt32(Name), Convert.ToInt32(Place),
                        Convert.ToInt32(Team), Convert.ToInt32(Points));
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddResulOfTeamPrimacyTestingBorderData()
            {
                bool actual = false, expected = false;

                int id = 10;
                string Name = "Чемпионат 2020 4 квартал";
                int Place = 15;
                string Team = "111111222";
                int Points = 20;

                try
                {
                    actual = viewResultOfTeamPrimacy.AddChampionship(Convert.ToInt32(Name), Convert.ToInt32(Place),
                         Convert.ToInt32(Team), Convert.ToInt32(Points));
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
        }





        [TestClass()]
        public class AddParticipant
        {
            ViewModel.ViewParticipant viewParticipant = new ViewParticipant();
            [TestMethod()]
            public void AddParticipantTestingCorrectData()
            {
                bool actual = true, expected = true;

                int IdActivity = 2;
                string Suname = "Веселова";
                string FirstName = "Наталья";
                string MiddleName = "Ивановна";
                string Gender = "2";
                string Team = "1";

                try
                {
                    actual = viewParticipant.AddParticipant(IdActivity, Suname, FirstName, MiddleName, Convert.ToInt32(Gender), Convert.ToInt32(Team));
                }
                catch { }

                IdActivity = 1;
                Suname = "Желов";
                FirstName = "Василий";
                MiddleName = "Николаевич";
                Gender = "2";
                Team = "2";
                try
                {
                    actual = viewParticipant.AddParticipant(IdActivity, Suname, FirstName, MiddleName, Convert.ToInt32(Gender), Convert.ToInt32(Team));
                }
                catch { }
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddParticipantTestingIncorrectData()
            {
                bool actual = false, expected = false;

                string idActivity = "Такое%";
                string Suname = "Я$";
                string FirstName = "Не&";
                string MiddleName = "$Понимаю";
                string Gender = "1авыfdsf$$";
                string Team = "Хваленн%:";

                try
                {
                    actual = viewParticipant.AddParticipant(Convert.ToInt32(idActivity), Suname, FirstName,
                        MiddleName, Convert.ToInt32(Gender), Convert.ToInt32(Team));
                }
                catch { }
                idActivity = "1111";
                Suname = "2222";
                FirstName = "3333";
                MiddleName = "444";
                Gender = "555";
                Team = "6666";
                try
                {
                    actual = viewParticipant.AddParticipant(Convert.ToInt32(idActivity), Suname, FirstName,
                       MiddleName, Convert.ToInt32(Gender), Convert.ToInt32(Team));
                }
                catch { }

                idActivity = null;
                Suname = null;
                FirstName = null;
                MiddleName = null;
                Gender = null;
                Team = null;
                try
                {
                    actual = viewParticipant.AddParticipant(Convert.ToInt32(idActivity), Suname, FirstName,
                       MiddleName, Convert.ToInt32(Gender), Convert.ToInt32(Team));
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddParticipantTestingBorderData()
            {
                bool actual = false, expected = false;

                string idActivity = "2";
                string Suname = "Руканоид#@";
                string FirstName = "ffffff";
                string MiddleName = "Адмик";
                string Gender = "1";
                string Team = "2";

                try
                {
                    actual = viewParticipant.AddParticipant(Convert.ToInt32(idActivity), Suname, FirstName, MiddleName, Convert.ToInt32(Gender), Convert.ToInt32(Team));
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
        }


        [TestClass()]
        public class AddPersonCompetitions
        {
            ViewModel.ViewPersonCompetitions viewPersonCompetitions = new ViewPersonCompetitions();
            [TestMethod()]
            public void AddPersonCompetitionsTestingCorrectData()
            {
                bool actual = true, expected = true;

                string IdParticipant = "1";
                int Place = 5;
                string IdGender = "1";
                string IdCompetitions = "1";
                string IdChampionship = "1";
                string Result = "7.5";
                int Points = 20;

                try
                {
                    actual = viewPersonCompetitions.AddPerson(Convert.ToInt32(IdParticipant), Place, Convert.ToInt32(IdGender), Convert.ToInt32(IdCompetitions),
                        Convert.ToInt32(IdChampionship),Result, Points);
                }
                catch { }

                IdParticipant = "1";
                Place = 5;
                IdGender = "1";
                IdCompetitions = "5";
                IdChampionship = "1";
                Result = "7.8";
                Points = 15;
                try
                {
                    actual = viewPersonCompetitions.AddPerson(Convert.ToInt32(IdParticipant), Place, Convert.ToInt32(IdGender), Convert.ToInt32(IdCompetitions),
                       Convert.ToInt32(IdChampionship), Result, Points);
                }
                catch { }
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddPersonCompetitionsTestingIncorrectData()
            {
                bool actual = false, expected = false;

                string IdParticipant = "fdsf323F#";
                string Place = "5f";
                string IdGender = "HTO";
                string IdCompetitions = "BEG№";
                string IdChampionship = "2020 ==1 квартал";
                string Result = "$#";
                string Points = "20kiiii";

                try
                {
                    actual = viewPersonCompetitions.AddPerson(Convert.ToInt32(IdParticipant), Convert.ToInt32(Place), Convert.ToInt32(IdGender), Convert.ToInt32(IdCompetitions),
                        Convert.ToInt32(IdChampionship), Result, Convert.ToInt32(Points));
                }
                catch { }
                IdParticipant = null;
                Place = null;
                IdGender = null;
                IdCompetitions = null;
                IdChampionship = null;
                Result = null;
                Points = null;
                try
                {
                    actual = viewPersonCompetitions.AddPerson(Convert.ToInt32(IdParticipant), Convert.ToInt32(Place), Convert.ToInt32(IdGender), Convert.ToInt32(IdCompetitions),
                       Convert.ToInt32(IdChampionship), Result, Convert.ToInt32(Points));
                }
                catch { }

                IdParticipant = "11111";
                Place = "22225";
                IdGender = "4234324234";
                IdCompetitions = "3242543534";
                IdChampionship = "234235245";
                Result = "742342342";
                Points = "20324234";
                try
                {
                    actual = viewPersonCompetitions.AddPerson(Convert.ToInt32(IdParticipant), Convert.ToInt32(Place), Convert.ToInt32(IdGender), Convert.ToInt32(IdCompetitions),
                       Convert.ToInt32(IdChampionship), Result, Convert.ToInt32(Points));
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void AddPersonCompetitionsTestingBorderData()
            {
                bool actual = false, expected = false;

                string IdParticipant = "NDS";
                int Place = 5;
                string IdGender = "Женщина@";
                string IdCompetitions = "бег";
                string IdChampionship = "Чемпионат 2020 1 квартал";
                string Result = "7.5";
                int Points = 20;

                try
                {
                    actual = viewPersonCompetitions.AddPerson(Convert.ToInt32(IdParticipant), Convert.ToInt32(Place), Convert.ToInt32(IdGender), Convert.ToInt32(IdCompetitions),
                        Convert.ToInt32(IdChampionship), Result, Convert.ToInt32(Points));
                }
                catch { }

                Assert.AreEqual(expected, actual);
            }
        }
    }

}