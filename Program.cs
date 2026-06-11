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


//https://www.mongodb.com/docs/manual/tutorial/insert-documents/

// var documents = new BsonDocument[]
// {
//     new BsonDocument
//     {
//         { "item", "journal" },
//         { "qty", 25 },
//         { "tags", new BsonArray { "blank", "red" } },
//         { "size", new BsonDocument { { "h", 14 }, { "w", 21 }, {  "uom", "cm"} } }
//     },
//     new BsonDocument
//     {
//         { "item", "mat" },
//         { "qty", 85 },
//         { "tags", new BsonArray { "gray" } },
//         { "size", new BsonDocument { { "h", 27.9 }, { "w", 35.5 }, {  "uom", "cm"} } }
//     },
//     new BsonDocument
//     {
//         { "item", "mousepad" },
//         { "qty", 25 },
//         { "tags", new BsonArray { "gel", "blue" } },
//         { "size", new BsonDocument { { "h", 19 }, { "w", 22.85 }, {  "uom", "cm"} } }
//     },
// };
// var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("inventory");

// collection.InsertMany(documents);


// var canvas = collection.Find({})

// Console.WriteLine(canvas.ToJson(new JsonWriterSettings { Indent = true }));


// var emptyFilter = Builders<BsonDocument>.Filter.Empty;
// var result = collection.Find(emptyFilter).ToList();

// Console.WriteLine(result.ToJson(new JsonWriterSettings { Indent = true }));
// Console.WriteLine($"There are {result.Count} in this collection.");




//https://www.mongodb.com/docs/manual/tutorial/query-documents/
// var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("inventory");


// var emptyFilter = Builders<BsonDocument>.Filter.Empty;

// collection.DeleteMany(emptyFilter);

// var documents = new BsonDocument[]
// {
//     new BsonDocument
//     {
//         { "item", "journal" },
//         { "qty", 25 },
//         { "size", new BsonDocument { { "h", 14 }, { "w", 21 }, {  "uom", "cm"} } },
//         { "status", "A" }
//     },
//     new BsonDocument
//     {
//         { "item", "notebook" },
//         { "qty", 50 },
//         { "size", new BsonDocument { { "h",  8.5 }, { "w", 11 }, {  "uom", "in"} } },
//         { "status", "A" }
//     },
//     new BsonDocument
//     {
//         { "item", "paper" },
//         { "qty", 100 },
//         { "size", new BsonDocument { { "h",  8.5 }, { "w", 11 }, {  "uom", "in"} } },
//         { "status", "D" }
//     },
//     new BsonDocument
//     {
//         { "item", "planner" },
//         { "qty", 75 },
//         { "size", new BsonDocument { { "h", 22.85 }, { "w", 30  }, {  "uom", "cm"} } },
//         { "status", "D" }
//     },
//     new BsonDocument
//     {
//         { "item", "postcard" },
//         { "qty", 45 },
//         { "size", new BsonDocument { { "h", 10 }, { "w", 15.25 }, {  "uom", "cm"} } },
//         { "status", "A" }
//     },
// };
// collection.InsertMany(documents);

// var builder = Builders<BsonDocument>.Filter;

// // filterBuilder.And(filterBuilder.Eq())

// var filter = builder.And(
//     builder.Eq("status", "A"),
//     builder.Or(builder.Lt("qty", 30), builder.Regex("item",


//     new BsonRegularExpression("^p"))


//     ));


// var result = collection.Find(filter).ToList();

// Console.WriteLine(result.ToJson(new JsonWriterSettings { Indent = true }));
// Console.WriteLine($"There are {result.Count} in this result");



/* Movies query */


// var movies = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");


// var emptyFilter = Builders<BsonDocument>.Filter.Empty;


// var builder = Builders<BsonDocument>.Filter;

// // filterBuilder.And(filterBuilder.Eq())

// var filter = builder.Eq("year", 1924);


// var moviesFrom1924 = movies.Find(filter).ToList();

// Console.WriteLine(moviesFrom1924.ToJson(new JsonWriterSettings { Indent = true }));
// Console.WriteLine($"There are {moviesFrom1924.Count} in this result");




// NESTED QUERY EXAMPLES
// var inventoryCollection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("inventory");


// var emptyFilter = Builders<BsonDocument>.Filter.Empty;


// var builder = Builders<BsonDocument>.Filter;


// inventoryCollection.DeleteMany(emptyFilter);


// var documents = new[]
// {
//     new BsonDocument
//     {
//         { "item", "journal" },
//         { "qty", 25 },
//         { "size", new BsonDocument { { "h", 14 }, { "w", 21 }, { "uom", "cm" } } },
//         { "status", "A" }
//     },
//     new BsonDocument
//     {
//         { "item", "notebook" },
//         { "qty", 50 },
//         { "size", new BsonDocument { { "h", 8.5 }, { "w", 11 }, { "uom", "in" } } },
//         { "status", "A" }
//     },
//     new BsonDocument
//     {
//         { "item", "paper" },
//         { "qty", 100 },
//         { "size", new BsonDocument { { "h", 8.5 }, { "w", 11 }, { "uom", "in" } } },
//         { "status", "D" }
//     },
//     new BsonDocument
//     {
//         { "item", "planner" },
//         { "qty", 75 },
//         { "size", new BsonDocument { { "h", 22.85 }, { "w", 30 }, { "uom", "cm" } } },
//         { "status", "D" }
//     },
//     new BsonDocument
//     {
//         { "item", "postcard" },
//         { "qty", 45 },
//         { "size", new BsonDocument { { "h", 10 }, { "w", 15.25 }, { "uom", "cm" } } },
//         { "status", "A" } },
// };
// inventoryCollection.InsertMany(documents);

// // filterBuilder.And(filterBuilder.Eq())

// var filter = builder.And(builder.Lt("size.h", 15), builder.Eq("size.uom", "in"), builder.Eq("status", "D"));
// var result = inventoryCollection.Find(filter).ToList();

// Console.WriteLine(result.ToJson(new JsonWriterSettings { Indent = true }));
// Console.WriteLine($"There are {result.Count} in this result");


// QUERY ARRAYS
// var inventoryCollection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("inventory");


// var emptyFilter = Builders<BsonDocument>.Filter.Empty;


// var builder = Builders<BsonDocument>.Filter;


// inventoryCollection.DeleteMany(emptyFilter);

// var documents = new[]
// {
//     new BsonDocument
//     {
//         { "item", "journal" },
//         { "qty", 25 },
//         { "tags", new BsonArray { "blank", "red" } },
//         { "dim_cm", new BsonArray { 14, 21 } }
//     },
//     new BsonDocument
//     {
//         { "item", "notebook" },
//         { "qty", 50 },
//         { "tags", new BsonArray { "red", "blank" } },
//         { "dim_cm", new BsonArray { 14, 21 } }
//     },
//     new BsonDocument
//     {
//         { "item", "paper" },
//         { "qty", 100 },
//         { "tags", new BsonArray { "red", "blank", "plain" } },
//         { "dim_cm", new BsonArray { 14, 21 } }
//     },
//     new BsonDocument
//     {
//         { "item", "planner" },
//         { "qty", 75 },
//         { "tags", new BsonArray { "blank", "red" } },
//         { "dim_cm", new BsonArray { 22.85, 30 } }
//     },
//     new BsonDocument
//     {
//         { "item", "postcard" },
//         { "qty", 45 },
//         { "tags", new BsonArray { "blue" } },
//         { "dim_cm", new BsonArray { 10, 15.25 } }
//     }
// };
// inventoryCollection.InsertMany(documents);

// // filterBuilder.And(filterBuilder.Eq())


// var filter = builder.SizeGt("tags", 2);

// var result = inventoryCollection.Find(filter).ToList();

// Console.WriteLine(result.ToJson(new JsonWriterSettings { Indent = true }));
// Console.WriteLine($"There are {result.Count} in this result");

// QUERY PROJECT RESULTS

// var inventoryCollection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("inventory");


// var emptyFilter = Builders<BsonDocument>.Filter.Empty;


// var builder = Builders<BsonDocument>.Filter;


// inventoryCollection.DeleteMany(emptyFilter);

// var documents = new[]
// {
//     new BsonDocument
//     {
//         { "item", "journal" },
//         { "status", "A" },
//         { "size", new BsonDocument { { "h", 14 }, { "w", 21 }, { "uom", "cm" } } },
//         { "instock", new BsonArray
//             {
//                 new BsonDocument { { "warehouse", "A" }, { "qty", 5 } } }
//             }
//     },
//     new BsonDocument
//     {
//         { "item", "notebook" },
//         { "status", "A" },
//         { "size", new BsonDocument { { "h", 8.5 }, { "w", 11 }, { "uom", "in" } } },
//         { "instock", new BsonArray
//             {
//                 new BsonDocument { { "warehouse", "C" }, { "qty", 5 } } }
//             }
//     },
//     new BsonDocument
//     {
//         { "item", "paper" },
//         { "status", "D" },
//         { "size", new BsonDocument { { "h", 8.5 }, { "w", 11 }, { "uom", "in" } } },
//         { "instock", new BsonArray
//             {
//                 new BsonDocument { { "warehouse", "A" }, { "qty", 60 } } }
//             }
//     },
//     new BsonDocument
//     {
//         { "item", "planner" },
//         { "status", "D" },
//         { "size", new BsonDocument { { "h", 22.85 }, { "w", 30 }, { "uom", "cm" } } },
//         { "instock", new BsonArray
//             {
//                 new BsonDocument { { "warehouse", "A" }, { "qty", 40 } } }
//             }
//     },
//     new BsonDocument
//     {
//         { "item", "postcard" },
//         { "status", "A" },
//         { "size", new BsonDocument { { "h", 10 }, { "w", 15.25 }, { "uom", "cm" } } },
//         { "instock", new BsonArray
//             {
//                 new BsonDocument { { "warehouse", "B" }, { "qty", 15 } },
//                 new BsonDocument { { "warehouse", "C" }, { "qty", 35 } } }
//             }
//     }
// };


// inventoryCollection.InsertMany(documents);

// // filterBuilder.And(filterBuilder.Eq())


// var filter = Builders<BsonDocument>.Filter.Eq("status", "A");


// //With the exception of the _id field, you cannot combine inclusion and exclusion statements in projection documents.

// // var projection = Builders<BsonDocument>.Projection.Include("item").Include("status").Exclude("_id");

// //return alll but excluded fields
// // var projection = Builders<BsonDocument>.Projection.Exclude("_id").Exclude("size").Exclude("instock");

// //return specific fields
// var projection = Builders<BsonDocument>.Projection.Include("item").Include("status").Slice("instock", -1);

// var result = inventoryCollection.Find(filter).Project(projection).ToList();



// Console.WriteLine(result.ToJson(new JsonWriterSettings { Indent = true }));
// Console.WriteLine($"There are {result.Count} in this result");

// Query NULL values


// var inventoryCollection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("inventory");


// var emptyFilter = Builders<BsonDocument>.Filter.Empty;


// var builder = Builders<BsonDocument>.Filter;


// inventoryCollection.DeleteMany(emptyFilter);
// var documents = new[]
// {
//     new BsonDocument { { "_id", 1 }, { "item", BsonNull.Value } },
//     new BsonDocument { { "_id", 2 } }
// };


// inventoryCollection.InsertMany(documents);


// match any document with a field called "item" and value not equal to null
// var filter = Builders<BsonDocument>.Filter.Ne("item", BsonNull.Value);

// matches only documents that contain the item field with a null value
// var filter = Builders<BsonDocument>.Filter.Type("item", BsonType.Null);


//Documents missing the field 'item'
// var filter = Builders<BsonDocument>.Filter.Exists("item", false);



// var result = inventoryCollection.Find(filter).ToList();

// Console.WriteLine(result.ToJson(new JsonWriterSettings { Indent = true }));
// Console.WriteLine($"There are {result.Count} in this result");



// //Set read concern for snapshots
// var snapshotClient = client.WithReadConcern(ReadConcern.Snapshot);



//UPDATE


// var inventoryCollection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("inventory");


// var emptyFilter = Builders<BsonDocument>.Filter.Empty;


// var builder = Builders<BsonDocument>.Filter;


// inventoryCollection.DeleteMany(emptyFilter);
// var documents = new[]
// {
//     new BsonDocument
//     {
//         { "item", "canvas" },
//         { "qty", 100 },
//         { "size", new BsonDocument { { "h", 28 }, { "w", 35.5 }, { "uom", "cm" } } },
//         { "status", "A" }
//     },
//     new BsonDocument
//     {
//         { "item", "journal" },
//         { "qty", 25 },
//         { "size", new BsonDocument { { "h", 14 }, { "w", 21 }, { "uom", "cm" } } },
//         { "status", "A" }
//     },
//     new BsonDocument
//     {
//         { "item", "mat" },
//         { "qty", 85 },
//         { "size", new BsonDocument { { "h", 27.9 }, { "w", 35.5 }, { "uom", "cm" } } },
//         { "status", "A" }
//     },
//     new BsonDocument
//     {
//         { "item", "mousepad" },
//         { "qty", 25 },
//         { "size", new BsonDocument { { "h", 19 }, { "w", 22.85 }, { "uom", "cm" } } },
//         { "status", "P" }
//     },
//     new BsonDocument
//     {
//         { "item", "notebook" },
//         { "qty", 50 },
//         { "size", new BsonDocument { { "h", 8.5 }, { "w", 11 }, { "uom", "in" } } },
//         { "status", "P" } },
//     new BsonDocument
//     {
//         { "item", "paper" },
//         { "qty", 100 },
//         { "size", new BsonDocument { { "h", 8.5 }, { "w", 11 }, { "uom", "in" } } },
//         { "status", "D" }
//     },
//     new BsonDocument
//     {
//         { "item", "planner" },
//         { "qty", 75 },
//         { "size", new BsonDocument { { "h", 22.85 }, { "w", 30 }, { "uom", "cm" } } },
//         { "status", "D" }
//     },
//     new BsonDocument
//     {
//         { "item", "postcard" },
//         { "qty", 45 },
//         { "size", new BsonDocument { { "h", 10 }, { "w", 15.25 }, { "uom", "cm" } } },
//         { "status", "A" }
//     },
//     new BsonDocument
//     {
//         { "item", "sketchbook" },
//         { "qty", 80 },
//         { "size", new BsonDocument { { "h", 14 }, { "w", 21 }, { "uom", "cm" } } },
//         { "status", "A" }
//     },
//     new BsonDocument
//     {
//         { "item", "sketch pad" },
//         { "qty", 95 },
//         { "size", new BsonDocument { { "h", 22.85 }, { "w", 30.5 }, { "uom", "cm" } } }, { "status", "A" } },
// };


// inventoryCollection.InsertMany(documents);

// //Update the first document which is paper
// // var filter = Builders<BsonDocument>.Filter.Eq("item", "paper");
// // var update = Builders<BsonDocument>.Update.Set("size.uom", "cm").Set("status", "P").CurrentDate("lastModified");
// // var result = inventoryCollection.UpdateOne(filter, update);


// //Update every document which has quantity larger than 50
// var filter = Builders<BsonDocument>.Filter.Lt("qty", 50);
// var update = Builders<BsonDocument>.Update.Set("size.uom", "in").Set("status", "P").CurrentDate("lastModified");
// var result = inventoryCollection.UpdateMany(filter, update);

// Console.WriteLine($"Was the result ackownledged? {result.IsAcknowledged}");
// Console.WriteLine($"There are {result.ModifiedCount} documents modified in this result");




//Update with aggregate example


var inventoryCollection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("inventory");


var emptyFilter = Builders<BsonDocument>.Filter.Empty;


var builder = Builders<BsonDocument>.Filter;



inventoryCollection.DeleteMany(emptyFilter);
var documents = new[]
 {
 new BsonDocument {  { "_id", 1},
 { "test1", 95},
 { "test2", 92},{ "test3", 90},{ "modified", DateTime.Parse("01/05/2020") }


 },

  new BsonDocument {  { "_id", 2},
 { "test1", 98},
 { "test2", 100},{ "test3", 102},{ "modified", DateTime.Parse("01/05/2020") }


 },
  new BsonDocument {  { "_id", 3},
 { "test1", 95},
 { "test2", 110},{ "modified", DateTime.Parse("01/04/2020") }


 }

};


inventoryCollection.InsertMany(documents);





var filter = builder.Eq("_id", 1);
var updateOperation = Builders<BsonDocument>.Update.Set("test3", 98).CurrentDate("modified");
inventoryCollection.UpdateOne(filter, updateOperation);




var result = inventoryCollection.Find(emptyFilter).ToList();

Console.WriteLine(result.ToJson(new JsonWriterSettings { Indent = true }));
Console.WriteLine($"There are {result.Count} in this collection.");
//recreate thh following in C#

// db.students2.updateMany( {},
//   [
//     { $replaceRoot: { newRoot:
//        { $mergeObjects: [ { quiz1: 0, quiz2: 0, test1: 0, test2: 0 }, "$$ROOT" ] }
//     } },
//     { $set: { modified: "$$NOW"}  }
//   ]
// )

