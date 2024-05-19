using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NoSQL_MongoDb.Helper;
using NoSQL_MongoDb.Models;

namespace NoSQL_MongoDb.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Team> _teamCollecttion;
        public MongoDbService(IOptions<MongoDbsetting> mongoDbSetting)
        {
            var mongoClient = new MongoClient(
                mongoDbSetting.Value.ConnectionURL);

            var mongoDatabase = mongoClient.GetDatabase(
                mongoDbSetting.Value.DatabaseName);

            _teamCollecttion = mongoDatabase.GetCollection<Team>("Teams");
        }

        public async Task<List<Team>> GetAsync() => await _teamCollecttion.Find(_ => true).ToListAsync();
        public async Task<Team> GetByIdAsync(string Id) => await _teamCollecttion.Find(x => x.Id == Id).FirstOrDefaultAsync();
        public async Task CreateAsync(Team team) => await _teamCollecttion.InsertOneAsync(team);
        public async Task UpdateAsync(string Id, Team team) => await _teamCollecttion.ReplaceOneAsync(x => x.Id == Id, team);
        public async Task DeleteAsync(string Id) => await _teamCollecttion.DeleteOneAsync(x=> x.Id == Id);
    }
}
