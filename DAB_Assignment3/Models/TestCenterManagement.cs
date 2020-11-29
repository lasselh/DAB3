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
    public class TestCenterManagement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("PhoneNumber")] public int PhoneNumber { get; set; }
        [BsonElement("Email")] public string Email { get; set; }
        [BsonElement("TestCenterID")] public int TestCenterID { get; set; }
        [BsonElement("TestCenter")] public TestCenter testCenter { get; set; }
    }
}
