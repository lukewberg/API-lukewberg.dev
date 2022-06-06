using API_lukewberg.dev.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API_lukewberg.dev.Utils
{
    public class MongoUtils<T> where T : Document
    {
        public MongoClient MongoClient { get; set; }
        public IMongoDatabase? Database { get; set; }

        public IMongoCollection<T>? Collection { get; set; }

        public MongoUtils(MongoClient mongoClient)
        {
            Database = mongoClient.GetDatabase("test");
        }

        public IMongoDatabase GetDatabase(string database) =>
            MongoClient.GetDatabase(database);

        public IMongoCollection<R> GetCollection<R>(string collection) =>
            Database.GetCollection<R>(collection);

        public IFindFluent<R, R> GetDocument<R>(IMongoCollection<R> collection, FilterDefinition<R> filter) =>
            collection.Find(filter).Limit(1);

        public IFindFluent<R, R> GetDocuments<R>(IMongoCollection<R> collection, FilterDefinition<R> filter) =>
            collection.Find(filter);

        public List<R> GetDocuemntsFromList<R>(IMongoCollection<R> collection, List<ObjectId> list)
        {
            if (list != null)
            {
                var filter = Builders<R>.Filter.In("_id", list);
                return GetDocuments(collection, filter).ToList();
            }
            return new List<R>();

        }

        public List<R> GetPaginatedDocuments<R>(IMongoCollection<R> collection, int page, int limit)
        {
            var filter = Builders<R>.Filter.Empty;
            var resultTask = collection.Find(filter).Skip((page - 1) * limit).Limit(limit).ToListAsync();
            Task.WaitAll(resultTask);
            return resultTask.Result;
        }

        public IFindFluent<T, T> SortDocuments(IFindFluent<T, T> documents, SortDefinition<T> sort) =>
            documents.Sort(sort);

        public async Task CreateDocument(IMongoCollection<T> collection, T document) =>
            await collection.InsertOneAsync(document);

    }
}
