using MongoDB.Driver;

namespace API_lukewberg.dev.Services
{
    public class MongoService
    {
        public MongoClient Client { get; set; }
        public IMongoDatabase? Database { get; set; }

        public MongoService()
        {
            MongoClientSettings settings = MongoClientSettings.FromConnectionString("mongodb+srv://lukewberg:Pontiff22*@cluster0.cikxp.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            Client = new MongoClient(settings);
            Database = Client.GetDatabase("test");
        }

        IMongoDatabase GetDatabase(string database)
        {
            return Client.GetDatabase(database);
        }
    }
}
