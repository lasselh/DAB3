using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment3.Services
{
    class LocationCitizenService 
    {
        private IMongoCollection<LocationCitizen> _locationcitizens;

        public LocationCitizenService()
        {
            var client = new MongoClient("mongodb://localhost:27017"); // Indsæt navn her
            var database = client.GetDatabase("CoronaDB");

            _locationcitizens = database.GetCollection<LocationCitizen>("LocationCitizen");
        }


        // Get Funktioner
        public List<LocationCitizen> Get() =>
            _locationcitizens.Find(Locationcitizen => true).ToList();

        public LocationCitizen GetSocialSecurityNumber(string socialSecurityNumber) =>
            _locationcitizens.Find<LocationCitizen>(Locationcitizen => Locationcitizen.SocialSecurityNumber == socialSecurityNumber).FirstOrDefault();

        public List<LocationCitizen> GetSSN(string socialSecurityNumber) =>
            _locationcitizens.Find<LocationCitizen>(Locationcitizen => Locationcitizen.SocialSecurityNumber == socialSecurityNumber).ToList();

        public LocationCitizen GetAddress(string address) =>
           _locationcitizens.Find<LocationCitizen>(Locationcitizen => Locationcitizen.Address == address).FirstOrDefault();

        public List<LocationCitizen> GetADR(string address) =>
           _locationcitizens.Find<LocationCitizen>(Locationcitizen => Locationcitizen.Address == address).ToList();

        public LocationCitizen GetCitizen(Citizen citizen) =>
           _locationcitizens.Find<LocationCitizen>(Locationcitizen => Locationcitizen.citizen == citizen).FirstOrDefault();

        public LocationCitizen GetLocation(Location location) =>
           _locationcitizens.Find<LocationCitizen>(Locationcitizen => Locationcitizen.location == location).FirstOrDefault();

        public LocationCitizen GetDate(string date) =>
           _locationcitizens.Find<LocationCitizen>(Locationcitizen => Locationcitizen.Date == date).FirstOrDefault();

        //public LocationCitizen GetCitizen(string socialSecurityNumber, string address) =>
        //   _locationcitizens.Find<LocationCitizen>(Locationcitizen => 
        //   Locationcitizen.SocialSecurityNumber == socialSecurityNumber && 
        //   Locationcitizen.Address == address)
        //   .FirstOrDefault();

        //Create, Update, Remove
        public LocationCitizen Create(LocationCitizen locationCitizen)
        {
            _locationcitizens.InsertOne(locationCitizen);
            return locationCitizen;
        }

        public void Update(String socialSecurityNumber, LocationCitizen locationCitizenIn) =>
            _locationcitizens.ReplaceOne(locationcitizen => locationcitizen.SocialSecurityNumber == socialSecurityNumber, locationCitizenIn);

        public void Remove(LocationCitizen locationCitizenIn) =>
            _locationcitizens.DeleteOne(locationcitizen => locationcitizen.SocialSecurityNumber == locationCitizenIn.SocialSecurityNumber);

        public void Remove(string socialSecurityNumber) =>
           _locationcitizens.DeleteOne(locationcitizen => locationcitizen.SocialSecurityNumber == socialSecurityNumber);
    }
}
