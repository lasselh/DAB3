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
    public class TestCenter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("TestCenterID")] public int TestCenterID { get; set; }
        [BsonElement("Hours")] public string Hours { get; set; }
        [BsonElement("MunicipalityID")] public int MunicipalityID { get; set; }

    }
}
