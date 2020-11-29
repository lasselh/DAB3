using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using DAB_Assignment3.Services;

namespace DAB_Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            CitizenService cs = new CitizenService();
            LocationService ls = new LocationService();
            MunicipalityService ms = new MunicipalityService();
            NationService ns = new NationService();
            TestCenterService tcs = new TestCenterService();
            TestCenterManagementService tcms = new TestCenterManagementService();

            LocationCitizenService lcs = new LocationCitizenService();
            TestCenterCitizenService tccs = new TestCenterCitizenService();

            //GenerateFunctions gf = new GenerateFunctions();
            CreateFunctions cf = new CreateFunctions();

            int choice;
            int choice2;
            bool finished = false;
            bool finishedSearch = false;


            // program start
            Console.WriteLine("Make a choice! \n" +
                              " 1: Add Denmark municipality and random dummy data\n" +
                              " 2: Empty database");
            choice = Convert.ToInt32(Console.ReadLine());
            //switch (choice)
            //{
            //    case 1:
            //        Console.Clear();
            //        gf.ParseMunicipality(db);
            //        gf.GenerateTestCenter(db, 100);
            //        gf.GenerateCitizens(db, 100);
            //        gf.AddCitizenToTestCenter(db, 100);
            //        gf.GenerateLocation(db, 100);
            //        gf.AddCitizenToLocation(db, 100);
            //        gf.GenerateTestCenterManagement(db, 100);
            //        break;

            //    case 2:
            //        Console.Clear();
            //        break;
            //}

            choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Choose an option... \n" +
                                  " 1: Create Citizen\n" +
                                  " 2: Create Test Center\n" +
                                  " 3: Create Management\n" +
                                  " 4: Create Test Case\n" +
                                  " 5: Create Location\n" +
                                  " 6: Create LocationCitizen\n" +
                                  " 7: Search the database\n" +
                                  " 0: Exit");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        cf.createCitizen(cs);
                        break;

                    case 2:
                        cf.createTestCenter(tcs);
                        break;

                    case 3:
                        cf.createManagement(tcms, tcs);
                        break;

                    case 4:
                        cf.createTestCase(cs, tcs, tccs, lcs);
                        break;

                    case 5:
                        cf.createLocation(ls);
                        break;
                    case 6:
                        cf.createLocationCitizen(lcs, cs, ls);
                        break;

                    case 7:
                        Console.Clear();
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("What do you want to search by? \n" +
                                              " 1: Search by name\n" +
                                              " 2: Search by age groups\n" +
                                              " 3: Search by gender\n" +
                                              " 4: Search by municipality\n" +
                                              " 0: Exit search");

                            choice2 = Convert.ToInt32(Console.ReadLine());
                            switch (choice2)
                            {
                                case 1:
                                    cf.searchForCitizen(cs);
                                    break;
                                case 2:
                                    //cf.searchforAge(db);
                                    break;
                                case 3:
                                    //cf.searchforSex(db);
                                    break;
                                case 4:
                                    //cf.SearchForMunincipality(db);
                                    break;
                                case 0:
                                    finishedSearch = true;
                                    break;
                            }
                        } while (finishedSearch == false);
                        break;
                    case 0:
                        finished = true;
                        break;
                }

            } while (finished == false);
        }
    }
}