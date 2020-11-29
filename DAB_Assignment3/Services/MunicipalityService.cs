using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment3.Services
{
    class MunicipalityService
    {
        private IMongoCollection<Municipality> _municipality;

        public MunicipalityService()
        {
            var client = new MongoClient("mongodb://localhost:27017"); // indsæt noget her dit svin
            var database = client.GetDatabase("CoronaDB");

            _municipality = database.GetCollection<Municipality>("Municipality");
        }


        // Get Funktioner
        public List<Municipality> Get() =>
            _municipality.Find(Municipality => true).ToList();

        public Municipality Get(int municipalityID) =>
            _municipality.Find<Municipality>(municipality => municipality.MunicipalityID == municipalityID).FirstOrDefault();

        public List<Municipality> GetName(string name) =>
            _municipality.Find(municipality => municipality.Name == name).ToList();

        public List<Municipality> GetPopulation(int population) =>
            _municipality.Find(municipality => municipality.Population == population).ToList();

        public List<Municipality> GetLocation(List<Location> locations) =>
            _municipality.Find(municipality => municipality.Locations == locations).ToList();

        public Municipality GetNation(string nationName) =>
            _municipality.Find(municipality => municipality.NationName == nationName).FirstOrDefault();

        //Create, Update, Remove
        public Municipality Create(Municipality municipality)
        {
            _municipality.InsertOne(municipality);
            return municipality;
        }

        public void Update(int municipalityID, Municipality municipalityIn) =>
           _municipality.ReplaceOne(municipality => municipality.MunicipalityID == municipalityID, municipalityIn);

        public void Remove(Municipality municipalityIn) =>
            _municipality.DeleteOne(municipality => municipality.MunicipalityID == municipalityIn.MunicipalityID);

        public void Remove(int municipalityID) =>
           _municipality.DeleteOne(municipality => municipality.MunicipalityID == municipalityID);
    }
}