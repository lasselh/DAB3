﻿using System;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment3
{
    class TestCenterManagementService
    {
        private IMongoCollection<TestCenterManagement> _testcentermanagements;

        public TestCenterManagementService()
        {
            var client = new MongoClient(""); // indsæt noget her dit svin
            var database = client.GetDatabase("CoronaDB");

            _testcentermanagements = database.GetCollection<TestCenterManagement>("TestCenter");
        }


        // Get Funktioner
        public List<TestCenterManagement> Get() =>
            _testcentermanagements.Find(TestCentermanagement => true).ToList();

        public TestCenterManagement GetPhoneNumber(int phoneNumber) =>
            _testcentermanagements.Find<TestCenterManagement>(testCenterManagement => testCenterManagement.PhoneNumber == phoneNumber).FirstOrDefault();

        public TestCenterManagement Get(string email) =>
            _testcentermanagements.Find(testcentermanagement => testcentermanagement.Email == email).FirstOrDefault();

        public List<TestCenterManagement> GetTestCenter(TestCenter testCenter) =>
            _testcentermanagements.Find(testcentermanagement => testcentermanagement.testCenter == testCenter).ToList();

        public TestCenterManagement GetTestCenterID(int testCenterID) =>
           _testcentermanagements.Find(testcentermanagement => testcentermanagement.TestCenterID == testCenterID).FirstOrDefault();

        //Create, Update, Remove
        public TestCenterManagement Create(TestCenterManagement testCenterManagement)
        {
            _testcentermanagements.InsertOne(testCenterManagement);
            return testCenterManagement;
        }

        public void Update(int phoneNumber, TestCenterManagement testCenterManagementIn) =>
            _testcentermanagements.ReplaceOne(testcentermanagement => testcentermanagement.PhoneNumber == phoneNumber, testCenterManagementIn);

        public void Remove(TestCenterManagement testCenterManagementIn) =>
            _testcentermanagements.DeleteOne(testcentermanagement => testcentermanagement.PhoneNumber == testCenterManagementIn.PhoneNumber);

        public void Remove(int phoneNumber) =>
           _testcentermanagements.DeleteOne(testcentermanagement => testcentermanagement.PhoneNumber == phoneNumber);
    }
}