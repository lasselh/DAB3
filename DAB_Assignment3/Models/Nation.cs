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
    public class Nation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("NationName")] public string NationName { get; set; }
        [BsonElement("Municipalities")] public List<Municipality> Municipalities { get; set; }
        [BsonElement("NationID")] public string NationID { get; set; }

    }
}
