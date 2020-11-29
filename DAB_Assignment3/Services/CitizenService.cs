using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment3
{
    class CitizenService
    {
        private IMongoCollection<Citizen> _citizens;

        public CitizenService()
        {
            var client = new MongoClient("mongodb://localhost:27017"); // indsæt noget her dit svin
            var database = client.GetDatabase("CoronaDB");

            _citizens = database.GetCollection<Citizen>("Citizen");
        }

    
        // Get Funktioner
        public List<Citizen> Get() =>
            _citizens.Find(Citizen => true).ToList();

        public Citizen Get(string socialSecurityNumber) =>
            _citizens.Find<Citizen>(Citizen => Citizen.SocialSecurityNumber == socialSecurityNumber).FirstOrDefault();

        public List<Citizen> GetFirstName(string firstName) =>
            _citizens.Find(Citizen => Citizen.FirstName == firstName).ToList();

        public List<Citizen> GetLastName(string lastName) =>
            _citizens.Find(Citizen => Citizen.LastName == lastName).ToList();

        public List<Citizen> GetAge(int age) =>
            _citizens.Find(Citizen => Citizen.Age == age).ToList();

        public List<Citizen> GetSex(string sex) =>
            _citizens.Find(Citizen => Citizen.Sex == sex).ToList();

        //public long GetCount() =>
        //    _citizens.CountDocuments(c);

        public Citizen GetRandomCitizen(int count) =>
            _citizens.Find(Citizen => true).Limit(-1).Skip(count).FirstOrDefault();

        //Create, Update, Remove
        public Citizen Create(Citizen citizen)
        {
            _citizens.InsertOne(citizen);
            return citizen;
        }

        public void Update(String socialSecurityNumber, Citizen citizenIn) =>
            _citizens.ReplaceOne(citizen => citizen.SocialSecurityNumber == socialSecurityNumber, citizenIn);

        public void Remove(Citizen citizenIn) =>
            _citizens.DeleteOne(citizen => citizen.SocialSecurityNumber == citizenIn.SocialSecurityNumber);

        public void Remove(string socialSecurityNumber) =>
           _citizens.DeleteOne(citizen => citizen.SocialSecurityNumber == citizen.SocialSecurityNumber);
    }
}
