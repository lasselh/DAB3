using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment3
{
    class TestCenterService
    {
        private IMongoCollection<TestCenter> _testcenters;

        public TestCenterService()
        {
            var client = new MongoClient("mongodb://localhost:27017"); // indsæt noget her dit svin
            var database = client.GetDatabase("CoronaDB");

            _testcenters = database.GetCollection<TestCenter>("TestCenter");
        }


        // Get Funktioner
        public List<TestCenter> Get() =>
            _testcenters.Find(TestCenter => true).ToList();

        public TestCenter Get(int testCenterID) =>
            _testcenters.Find<TestCenter>(testCenter => testCenter.TestCenterID == testCenterID).FirstOrDefault();

        public List<TestCenter> GetHours(string hours) =>
            _testcenters.Find(testcenter => testcenter.Hours == hours).ToList();

        public TestCenter GetMunicipalityID(int municipalityID) =>
            _testcenters.Find(testcenter => testcenter.MunicipalityID == municipalityID).FirstOrDefault();

        //public long GetCount() =>
        //    _testcenters.CountDocuments(c);

        public TestCenter GetRandomTestCenter(int count) =>
            _testcenters.Find(TestCenter => true).Limit(-1).Skip(count).FirstOrDefault();

        //Create, Update, Remove
        public TestCenter Create(TestCenter testCenter)
        {
            _testcenters.InsertOne(testCenter);
            return testCenter;
        }

        public void Update(int testCenterID, TestCenter testCenterIn) =>
            _testcenters.ReplaceOne(testcenter => testcenter.TestCenterID == testCenterID, testCenterIn);

        public void Remove(TestCenter testCenterIn) =>
            _testcenters.DeleteOne(testcenter => testcenter.TestCenterID == testCenterIn.TestCenterID);

        public void Remove(int testCenterID) =>
           _testcenters.DeleteOne(testcenter => testcenter.TestCenterID == testCenterID);
    }
}