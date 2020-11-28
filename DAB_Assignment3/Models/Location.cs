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
    public class Location
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("Address")] public string Address { get; set; }
        [BsonElement("LocationCitizens")] public List<LocationCitizen> LocationCitizens { get; set; }
        [BsonElement("Municipality")] public Municipality municipality { get; set; }
        [BsonElement("MunicipalityID")] public string MunicipalityID { get; set; }

    }
}
