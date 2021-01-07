using APITemplate.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITemplate.Services
{
    public class MongoDBService
    {
        private IMongoCollection<Dishes> DishCollection { get; }

        public MongoDBService(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoCli = new MongoClient(databaseUrl);
            var mongodatabase = mongoCli.GetDatabase(databaseName);

            DishCollection = mongodatabase.GetCollection<Dishes>(collectionName);
        }

        //Inserting a document inside respective collection.
        public async Task InsertDish(Dishes dish) => await DishCollection.InsertOneAsync(dish);

        //Fetching all document in a single collection
        public async Task<List<Dishes>> GetDishes()
        {
            var dishes = new List<Dishes>();
            var alldocs = await DishCollection.FindAsync(new BsonDocument());
            await alldocs.ForEachAsync(doc => dishes.Add(doc));
            return dishes;
        }

        //Updating the collection document with ID reference
        public async Task<string> Update(string id,Dishes dishes)
        {
            var updatedocs = await DishCollection.ReplaceOneAsync(zz => zz.DishID == id, dishes);
            return "";
        }
    }
}
