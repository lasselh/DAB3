using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DAB_Assignment3
{
    public class Municipality
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("MunicipalityID")] public int MunicipalityID { get; set; }

        [BsonElement("Name")] public string Name { get; set; }
        [BsonElement("Population")] public float Population { get; set; }
        [BsonElement("Locations")] public List<Location> Locations { get; set; }
        [BsonElement("Nation")] public Nation nation { get; set; }
        [BsonElement("Citizens")] public List<Citizen> Citizens { get; set; }
        [BsonElement("TestCenters")] public List<TestCenter> TestCenters { get; set; }
        [BsonElement("NationName")] public string NationName { get; set; }

    }
}
