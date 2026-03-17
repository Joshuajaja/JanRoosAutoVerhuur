using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JanRoosAutoVerhuurAPI.Models
{

     public class CarDto
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public ObjectId Id { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public string Type { get; set; }
            public int Age { get; set; }
            public int Seats { get; set; }
            public bool Towbar { get; set; }
            public string Color { get; set; }
            public bool WinterTires { get; set; }
            public bool RoofboxOption { get; set; }
            public string Class { get; set; }
        }
}
