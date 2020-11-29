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
    public class Citizen
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("SocialSecurityNumber")] public string SocialSecurityNumber { get; set; }
        [BsonElement("FirstName")] public string FirstName { get; set; }
        [BsonElement("LastName")] public string LastName { get; set; }
        [BsonElement("Sex")] public string Sex { get; set; }
        [BsonElement("Age")] public int Age { get; set; }
        [BsonElement("TestCenterCitizens")] public List<TestCenterCitizen> TestCenterCitizens { get; set; }
        [BsonElement("LocationCitizens")] public List<LocationCitizen> LocationCitizens { get; set; }
        [BsonElement("Municipality")] public Municipality Municipality { get; set; }
        [BsonElement("MunicipalityID")] public int MunicipalityID { get; set; }
    }
}
