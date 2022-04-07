// Set up using documentation from 
// https://mongodb.github.io/mongo-csharp-driver/2.15/getting_started/quick_tour/

using MongoDB.Bson;
using System.Collections.Generic;

namespace HelloAPIDatabase
{
   public interface IMongoDBBase
   {
      string CollectionName { get; set; }

      void Delete(string field, string valToSearch);
      BsonDocument Get(string field, string valToSearch);
      List<BsonDocument> GetAll();
      void Insert(BsonDocument document);
      void Update(string field, string valToSearch, string valToSet);
   }
}