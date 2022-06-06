using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
var dbCreds = builder.Configuration["Creds:Mongo"];

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MongoClient>(service =>
{
    MongoClientSettings settings = MongoClientSettings.FromConnectionString($"mongodb+srv://{dbCreds}@cluster0.cikxp.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
    settings.ServerApi = new ServerApi(ServerApiVersion.V1);
    //var pack = new ConventionPack
    //{
    //    new StringIdStoredAsObjectIdConvention()
    //};
    //ConventionRegistry.Register("String Object Ids", pack, x => true);
    return new MongoClient(settings);
});

builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        //googleOptions.ClientId = 
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
