using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APITemplate.Models
{
    public class Dishes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DishID { get; set; }
        [BsonRequired]
        public string DishName { get; set; }
        public string ShortDescription { get; set; }
        [BsonRequired]
        public string Price { get; set; }
        [BsonRequired]
        public string CategoryName { get; set; }
        public string TimeOfDay { get; set; }
        public bool   DishDeactivation { get; set; }
        public string DishWaitingTime { get; set; }
    }
}
