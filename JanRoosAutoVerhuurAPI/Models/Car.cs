using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JanRoosAutoVerhuurAPI.Models
{
    public class CarDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("brand")]
        public string Brand { get; set; } = string.Empty;
        [BsonElement("model")]
        public string Model { get; set; } = string.Empty;
        [BsonElement("type")]
        public string Type { get; set; } = string.Empty;
        [BsonElement("age")]
        public int Age { get; set; }
        [BsonElement("seats")]
        public int Seats { get; set; }
        [BsonElement("towbar")]
        public bool Towbar { get; set; }
        [BsonElement("color")]
        public string Color { get; set; } = string.Empty;
        [BsonElement("winter_tires")]
        public bool WinterTires { get; set; }
        [BsonElement("roofbox_option")]
        public bool RoofboxOption { get; set; }
        [BsonElement("class")]
        public string Class { get; set; } = string.Empty;
    }
}
