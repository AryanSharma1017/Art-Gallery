using art_gallery.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace art_gallery.Services;

public class MongoDBService {
    private readonly IMongoCollection<User> _userCollection;

    public MongoDBService(IOptions<MongoDBSettings> _mongoDBSettings)
    {
        MongoClient client = new MongoClient(_mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(_mongoDBSettings.Value.DatabaseName);
        _userCollection = database.GetCollection<User>(_mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<User>> GetUsers() {
        return await _userCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task CreateUser(User user)
    {
        await _userCollection.InsertOneAsync(user);
        return;
    }

    public async Task AddUser(string id, string data)
    {
        FilterDefinition<User> filter = Builders<User>.Filter.Eq("id", id);
        UpdateDefinition<User> update = Builders<User>.Update.AddToSet<string>("data", data); // make sure the name of the field is equal to the name of the field in json
        await _userCollection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteAsync(string id) {
        FilterDefinition<User> filter = Builders<User>.Filter.Eq("id", id);
        await _userCollection.DeleteOneAsync(filter);
        return;
    }
}


// Reference : https://www.youtube.com/watch?v=jJK9alBkzU0