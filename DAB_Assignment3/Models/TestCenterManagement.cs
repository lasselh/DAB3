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
    public class TestCenterManagement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("PhoneNumber")] public int PhoneNumber { get; set; }
        [BsonElement("Emal")] public string Email { get; set; }
        [BsonElement("TestCenter")] public TestCenter testCenter { get; set; }
        [BsonElement("TestCenterID")] public int TestCenterID { get; set; }

    }
}
