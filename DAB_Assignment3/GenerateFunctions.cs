using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using DAB_Assignment3.Services;

namespace DAB_Assignment3
{
    class GenerateFunctions
    {
        ////////////////////////////////////////////////
        // Hjælpefunktioner taget fra Henriks github  //
        ////////////////////////////////////////////////
        static string[] Firstnames = new string[] {
            "Hans", "Jens", "Henrik", "Jesper", "Morten", "Mathias", "Alice", "Bob", "Mette", "Lene", "Hanne", "Lise", "Lise", "Mikkel", "Lasse", "Mathias"
        };
        static string[] Lastnames = new string[] {
            "Hansen", "Jensen", "Olsen", "Mortensen", "Frederiksen", "Larsen", "Vigen"
        };
        static string[] Genders = new string[] { "female", "male" };
        static Random random = new Random();
        public string getDate()
        {
            return setZeroes(random.Next(28) + 1);
        }
        public string getMonth()
        {
            return setZeroes(random.Next(12) + 1);
        }
        public string getYear(int age)
        {
            var birthYear = 2020 - age;
            return birthYear.ToString().Substring(2);
        }
        public string getControl()
        {
            return setZeroes(random.Next(10000), 4);
        }
        public string setZeroes(int i, int length = 2)
        {
            return ("" + i).PadLeft(length, '0');
        }
        ////////////////////////////////////////////////
        ////////// Vores funktioner under //////////////
        ////////////////////////////////////////////////


        // Genererer alle municipality/kommuner i dk og laver en Nation "Danmark".
        public List<int> Municipalities = new List<int>();
        public void ParseMunicipality(MunicipalityService ms, NationService ns)
        {
            // Clears the database of Nations/Munincipality
            var myNations = ns.Get();
            foreach(var i in myNations)
            {
                ns.Remove(i);
            }

            var myMunicipality = ms.Get();
            foreach(var i in myMunicipality)
            {
                ms.Remove(i);
            }

            var dk = new Nation()
            {
                NationName = "Danmark",
                NationID = "1"
            };

            ns.Create(dk);

            string line = "";
            var reader = new StreamReader("./Municipality_test_pos.csv");
            reader.ReadLine(); // Skip first

            while ((line = reader.ReadLine()) != null)
            {
                var data = line.Split(";");
                var population = float.Parse(data[4].Trim());

                var mun = new Municipality()
                {
                    MunicipalityID = int.Parse(data[0].Trim()),
                    Name = data[1].Trim(),
                    Population = population,
                    NationName = "Danmark"
                };

                Municipalities.Add(int.Parse(data[0].Trim()));

                ms.Create(mun);
            }
            reader.Close();
        }
        // Genererer et antal tilfældige citizens, default 100.
        /// <summary>
        /// fuck en nice måde at lave kommentarer på tester123
        /// </summary>
        /// <param name="db">DatabaseContext to add to</param>
        /// <param name="number">Amount of citizens to generate</param>
        public void GenerateCitizens(CitizenService cs, int number = 100)
        {
            // Clears the database of Citizens
            var myCitizen = cs.Get();
            foreach (var i in myCitizen)
            {
                cs.Remove(i);
            }

            for (var i = 0; i < number; i++)
            {
                var age = random.Next(100);
                var temp = random.Next(Municipalities.Count);

                var cit = new Citizen()
                {
                    FirstName = Firstnames[random.Next(Firstnames.Length)],
                    LastName = Lastnames[random.Next(Lastnames.Length)],
                    Sex = Genders[random.Next(Genders.Length)],
                    Age = age,
                    SocialSecurityNumber = $"{getDate()}{getMonth()}{getYear(age)}{getControl()}",
                    MunicipalityID = Municipalities[temp]
                };

                cs.Create(cit);
            }
        }

        // Genererer et antal tilfældige testcentre
        public void GenerateTestCenter(TestCenterService tcs, int number = 100)
        {
            // Clears the database of TestCenter
            var myTestCenters = tcs.Get();
            foreach (var i in myTestCenters)
            {
                tcs.Remove(i);
            }

            for (int i = 1; i < (number + 1); i++)
            {
                var temp = random.Next(Municipalities.Count);

                var testcenter = new TestCenter()
                {
                    TestCenterID = i,
                    MunicipalityID = Municipalities[temp],
                    Hours = "8-20"
                };

                tcs.Create(testcenter);
            }
        }

        // Genererer et antal tilfældige lokationer
        public void GenerateLocation(LocationService ls, int number = 100)
        {
            // Clears the database of Locations
            var myLocation = ls.Get();
            foreach (var i in myLocation)
            {
                ls.Remove(i);
            }

            for (int i = 1; i < (number + 1); i++)
            {
                var temp = random.Next(Municipalities.Count);

                var location = new Location()
                {
                    Address = "Vejnavn " + i.ToString(),
                    MunicipalityID = Municipalities[temp]
                };

                ls.Create(location);
            }
        }

        // Genererer et antal tilfældige TestCenterManagements
        public void GenerateTestCenterManagement(TestCenterManagementService tcms, int number = 100)
        {
            // Clears the database of TestCenterManagements
            var myTestCenterManagements = tcms.Get();
            foreach (var i in myTestCenterManagements)
            {
                tcms.Remove(i);
            }

            for (int i = 1; i < (number + 1); i++)
            {
                var temp = random.Next(Municipalities.Count);
                var tcm = new TestCenterManagement()
                {
                    PhoneNumber = 10000000 + i,
                    Email = "random@mail" + i.ToString() + ".dk",
                    TestCenterID = i
                };

                tcms.Create(tcm);
            }
        }

        // Udfylder skyggetabellen TestCenterCitizen, binder tilfældige citizens til tilfældige testcentre
        // Kræver at der allerede er Citizens og TestCenter i databasen
        public void AddCitizenToTestCenter(CitizenService cs, TestCenterService tcs, TestCenterCitizenService tccs, int number = 100)
        {
            // Clears the database of TestCenterCitizens
            var myTestCenterCitizen = tccs.Get();
            foreach (var i in myTestCenterCitizen)
            {
                tccs.Remove(i);
            }

            for (int i = 0; i < number; i++)
            {
                //int rcit = random.Next((int)cs.GetCount());
                //int rtcr = random.Next((int)tcs.GetCount());

                int rcit = random.Next(100);
                int rtcr = random.Next(100);

                var cit = cs.GetRandomCitizen(rcit);
                var tcr = tcs.GetRandomTestCenter(rtcr);

                var tcc = new TestCenterCitizen()
                {
                    SocialSecurityNumber = cit.SocialSecurityNumber,
                    TestCenterID = tcr.TestCenterID,
                    date = $"{getDate()}{getMonth()}{getYear(0)}"
                };

                int rnum = random.Next(100);
                if (rnum < 33)
                {
                    tcc.result = false;
                    tcc.status = "Not Ready";
                }
                else if (rnum < 66)
                {
                    tcc.result = true;
                    tcc.status = "Ready";
                }
                else if (rnum <= 100)
                {
                    tcc.result = false;
                    tcc.status = "Ready";
                }

                tccs.Create(tcc);
            }
        }

        // Udfylder LocationCitizen skyggetabellen, binder tilfældige citizens til tilfældige lokationer
        // Kræver at der allerede er Citizens og TestCenter i databasen
        public void AddCitizenToLocation(CitizenService cs, LocationService ls, LocationCitizenService lcs, int number = 100)
        {
            // Clears the database of LocationCitizen
            var myLocationCitizen = lcs.Get();
            foreach (var i in myLocationCitizen)
            {
                lcs.Remove(i);
            }

            for (int i = 0; i < number; i++)
            {
                //int rcit = random.Next(db.Citizen.Count());
                //int rloc = random.Next(db.Location.Count());

                int rcit = random.Next(100);
                int rloc = random.Next(100);

                var cit = cs.GetRandomCitizen(rcit);
                var loc = ls.GetRandomLocation(rloc);

                var lcc = new LocationCitizen()
                {
                    SocialSecurityNumber = cit.SocialSecurityNumber,
                    Address = loc.Address,
                    Date = $"{getDate()}{getMonth()}{getYear(0)}"
                };

                lcs.Create(lcc);
            }
        }
    }
}
