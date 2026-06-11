using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
if (connectionString == null)
{
    Console.WriteLine("You must set your 'MONGODB_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/get-started/create-connection-string");
    Environment.Exit(0);
}
var client = new MongoClient(connectionString);



// var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");
// var filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");
// var document = collection.Find(filter).First();
// Console.WriteLine(document.ToJson(new JsonWriterSettings { Indent = true }));


/* Insert 1 */

// var document = new BsonDocument
// {
//     {"_id", "testid"},
//     { "item", "canvas" },
//     { "qty", 100 },
//     { "tags", new BsonArray { "cotton" } },
//     { "size", new BsonDocument { { "h", 28 }, { "w", 35.5 }, { "uom", "cm" } } }
// };
// var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("inventory");
// collection.InsertOne(document);


// var emptyFilter = Builders<BsonDocument>.Filter.Eq("item", "canvas");
// var canvas = collection.Find(emptyFilter).First();




var documents = new BsonDocument[]
{
    new BsonDocument
    {
        { "item", "journal" },
        { "qty", 25 },
        { "tags", new BsonArray { "blank", "red" } },
        { "size", new BsonDocument { { "h", 14 }, { "w", 21 }, {  "uom", "cm"} } }
    },
    new BsonDocument
    {
        { "item", "mat" },
        { "qty", 85 },
        { "tags", new BsonArray { "gray" } },
        { "size", new BsonDocument { { "h", 27.9 }, { "w", 35.5 }, {  "uom", "cm"} } }
    },
    new BsonDocument
    {
        { "item", "mousepad" },
        { "qty", 25 },
        { "tags", new BsonArray { "gel", "blue" } },
        { "size", new BsonDocument { { "h", 19 }, { "w", 22.85 }, {  "uom", "cm"} } }
    },
};
var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("inventory");

collection.InsertMany(documents);


// var canvas = collection.Find({})

// Console.WriteLine(canvas.ToJson(new JsonWriterSettings { Indent = true }));


var emptyFilter = Builders<BsonDocument>.Filter.Empty;
var result = collection.Find(emptyFilter).ToList();

Console.WriteLine(result.ToJson(new JsonWriterSettings { Indent = true }));
Console.WriteLine($"There are {result.Count} in this collection.");
