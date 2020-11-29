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
        public string Id { get; set; }

        [BsonElement("MunicipalityID")] public int MunicipalityID { get; set; }
        [BsonElement("Name")] public string Name { get; set; }
        [BsonElement("Population")] public float Population { get; set; }
        [BsonElement("NationName")] public string NationName { get; set; }

    }
}
