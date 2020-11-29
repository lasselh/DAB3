using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment3.Services
{
    class LocationService
    {
        private IMongoCollection<Location> _locations;

        public LocationService()
        {
            var client = new MongoClient("mongodb://localhost:27017"); // Indsæt navn her
            var database = client.GetDatabase("CoronaDB");

            _locations = database.GetCollection<Location>("Location");
        }


        // Get Funktioner
        public List<Location> Get() =>
            _locations.Find(Location => true).ToList();

        public Location GetAddress(string address) =>
            _locations.Find<Location>(Location => Location.Address == address).FirstOrDefault();

        public Location GetRandomLocation(int count) =>
            _locations.Find(Location => true).Limit(-1).Skip(count).FirstOrDefault();

        //Create, Update, Remove
        public Location Create(Location location)
        {
            _locations.InsertOne(location);
            return location;
        }

        public void Update(String address, Location locationIn) =>
            _locations.ReplaceOne(location => location.Address == address, locationIn);

        public void Remove(Location locationIn) =>
            _locations.DeleteOne(location => location.Address == locationIn.Address);

        public void Remove(string address) =>
           _locations.DeleteOne(location => location.Address == address);
    }
}
