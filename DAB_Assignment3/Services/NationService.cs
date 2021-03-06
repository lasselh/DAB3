﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment3.Services
{
    class NationService
    {
        private IMongoCollection<Nation> _nations;

        public NationService()
        {
            var client = new MongoClient("mongodb://localhost:27017"); // Indsæt navn her
            var database = client.GetDatabase("CoronaDB");

            _nations = database.GetCollection<Nation>("Nation");
        }


        // Get Funktioner
        public List<Nation> Get() =>
            _nations.Find(Nation => true).ToList();

        public Nation Get(string nationName) =>
            _nations.Find<Nation>(nation => nation.NationName == nationName).FirstOrDefault();

        public List<Nation> GetNationID(string nationID) =>
            _nations.Find(nation => nation.NationID == nationID).ToList();

        //Create, Update, Remove
        public Nation Create(Nation nation)
        {
            _nations.InsertOne(nation);
            return nation;
        }

        public void Update(String nationName, Nation nationIn) =>
            _nations.ReplaceOne(nation => nation.NationName == nationName, nationIn);

        public void Remove(Nation nationIn) =>
            _nations.DeleteOne(nation => nation.NationName == nationIn.NationName);

        public void Remove(string nationName) =>
           _nations.DeleteOne(nation => nation.NationName == nationName);
    }
}
