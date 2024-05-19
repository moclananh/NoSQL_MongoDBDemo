using MongoDB.Bson.Serialization.Attributes;

namespace NoSQL_MongoDb.Models
{
    public class Team
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string TeamName { get; set; }
        public string Conference {  get; set; }
        public List<User> Users { get; set; }
    }
}
