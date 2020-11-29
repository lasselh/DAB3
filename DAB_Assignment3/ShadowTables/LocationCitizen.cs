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
    public class LocationCitizen
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("SocialSecurityNumber")] public string SocialSecurityNumber { get; set; }
        [BsonElement("Address")] public string Address { get; set; }
        [BsonElement("Citizen")] public Citizen citizen { get; set; }
        [BsonElement("Location")] public Location location { get; set; }
        [BsonElement("Date")] public string Date { get; set; }

    }

}
