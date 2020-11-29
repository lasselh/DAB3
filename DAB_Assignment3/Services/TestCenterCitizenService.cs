using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment3
{
    class TestCenterCitizenService
    {
        private IMongoCollection<TestCenterCitizen> _testcentercitizens;

        public TestCenterCitizenService()
        {
            var client = new MongoClient("mongodb://localhost:27017"); // indsæt noget her dit svin
            var database = client.GetDatabase("CoronaDB");

            _testcentercitizens = database.GetCollection<TestCenterCitizen>("TestCenterCitizen");
        }


        // Get Funktioner
        public List<TestCenterCitizen> Get() =>
            _testcentercitizens.Find(TestCenterCitizen => true).ToList();

        public TestCenterCitizen GetSocialSecurityNumber(string socialSecurityNumber) =>
            _testcentercitizens.Find<TestCenterCitizen>(testCenterCitizen => testCenterCitizen.SocialSecurityNumber == socialSecurityNumber).FirstOrDefault();

        public TestCenterCitizen GetHours(int testCenterID) =>
            _testcentercitizens.Find(testcentercitizen => testcentercitizen.TestCenterID == testCenterID).FirstOrDefault();

        public List<TestCenterCitizen> GetCitizen(Citizen citizen) =>
            _testcentercitizens.Find(testcentercitizen => testcentercitizen.citizen == citizen).ToList();

        public List<TestCenterCitizen> GetTestCenter(TestCenter testcenter) =>
            _testcentercitizens.Find(testcentercitizen => testcentercitizen.testCenter == testcenter).ToList();

        public TestCenterCitizen GetResult(bool result) =>
            _testcentercitizens.Find(testcentercitizen => testcentercitizen.result == result).FirstOrDefault();

        public TestCenterCitizen GetStatus(string status) =>
            _testcentercitizens.Find(testcentercitizen => testcentercitizen.status == status).FirstOrDefault();

        public TestCenterCitizen GetDate(string date) =>
            _testcentercitizens.Find(testcentercitizen => testcentercitizen.date == date).FirstOrDefault();

        //Create, Update, Remove
        public TestCenterCitizen Create(TestCenterCitizen testCenterCitizen)
        {
            _testcentercitizens.InsertOne(testCenterCitizen);
            return testCenterCitizen;
        }

        public void Update(string socialSecurityNumber, TestCenterCitizen testCenterCitizenIn) =>
            _testcentercitizens.ReplaceOne(testcentercitizen => testcentercitizen.SocialSecurityNumber == socialSecurityNumber, testCenterCitizenIn);

        public void Remove(TestCenterCitizen testCenterCitizenIn) =>
            _testcentercitizens.DeleteOne(testcentercitizen => testcentercitizen.SocialSecurityNumber == testCenterCitizenIn.SocialSecurityNumber);

        public void Remove(string socialSecurityNumber) =>
           _testcentercitizens.DeleteOne(testcentercitizen => testcentercitizen.SocialSecurityNumber == socialSecurityNumber);
    }
}