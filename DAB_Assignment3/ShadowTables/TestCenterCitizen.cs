using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DAB2
{
    public class TestCenterCitizen
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("SocialSecurityNumber")] public string SocialSecurityNumber { get; set; }
        [BsonElement("TestCenterID")] public int TestCenterID { get; set; }
        [BsonElement("Citizen")] public Citizen citizen { get; set; }
        [BsonElement("TestCenter")] public TestCenter testCenter { get; set; }
        [BsonElement("result")] public bool result { get; set; }
        [BsonElement("status")] public string status { get; set; }
        [BsonElement("date")] public string date { get; set; }

    }
}
