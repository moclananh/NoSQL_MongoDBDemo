
The first, we need to create database name in the MongoDB

Step to config:
1. Install MongoDb package
  <ItemGroup>
       <PackageReference Include="MongoDB.Driver" Version="2.25.0" />
  </ItemGroup>
2. Setting
2.1 Create class MongoDbSetting:
 public string ConnectionURL { get; set; } = null;
 public string DatabaseName { get; set; } = null;

2.2 Configuration in json file
  "MongoDB": {
    "ConnectionURL": "mongodb://localhost:27017",
    "DatabaseName":  "demo_mongodb"
  },


3. Create Models
//Primary Key form (auto generated)
 [BsonId]
 [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
 public string Id { get; set; }


4. Create MongoService and controller

5. Config in Program
//setting mongodb here
builder.Services.Configure<MongoDbsetting>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDbService>(); //declare DI

