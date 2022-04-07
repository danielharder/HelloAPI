// Set up using documentation from 
// https://mongodb.github.io/mongo-csharp-driver/2.15/getting_started/quick_tour/

using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HelloAPIDatabase
{
   public class MongoDBBase : IMongoDBBase
   {
      private MongoClient _MongoClient;
      private IMongoDatabase _MongoDatabase;
      public string CollectionName { get; set; }
      public MongoDBBase()
      {
         var _MongoClient = new MongoClient("mongodb://localhost:27017");
         var _MongoDatabase = _MongoClient.GetDatabase("HelloAPI");

      }

      public void Insert(BsonDocument document)
      {
         var collection = _MongoDatabase.GetCollection<BsonDocument>(CollectionName);
         collection.InsertOne(document);
      }
      public BsonDocument Get(String field, String valToSearch)
      {
         var collection = _MongoDatabase.GetCollection<BsonDocument>(CollectionName);
         var filter = Builders<BsonDocument>.Filter.Eq(field, valToSearch);
         var document = collection.Find(filter).First();
         return document;
      }
      public List<BsonDocument> GetAll()
      {
         var collection = _MongoDatabase.GetCollection<BsonDocument>(CollectionName);
         var documents = collection.Find(new BsonDocument()).ToList();
         return documents;
      }
      public void Update(String field, String valToSearch, String valToSet)
      {
         var collection = _MongoDatabase.GetCollection<BsonDocument>(CollectionName);
         var filter = Builders<BsonDocument>.Filter.Eq(field, valToSearch);
         var update = Builders<BsonDocument>.Update.Set(field, valToSet);
         collection.UpdateOne(filter, update);
      }
      public void Delete(String field, String valToSearch)
      {
         var collection = _MongoDatabase.GetCollection<BsonDocument>(CollectionName);
         var filter = Builders<BsonDocument>.Filter.Eq(field, valToSearch);
         collection.DeleteOne(filter);
      }

   }
}
