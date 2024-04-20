using art_gallery.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace art_gallery.Services;

public class UserService {
    private readonly IMongoCollection<User> _userCollection;

    public UserService(IOptions<MongoDBSettings> _mongoDBSettings)
    {
        MongoClient client = new MongoClient(_mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(_mongoDBSettings.Value.DatabaseName);
        _userCollection = database.GetCollection<User>("users");
    }

    public async Task<List<User>> GetAllUsers() {
        return await _userCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<User> GetUser(int id)
    {
        return await _userCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
    }

    private int GetNextUserId()
    {
        var currentID = _userCollection.Find(u => true).SortByDescending(u => u.Id).Limit(1).FirstOrDefault();
        if (currentID == null)
        {
            return 1;
        }
        else
        {
            return currentID.Id + 1; 
        }
    }

    public async Task CreateUser(User user)
    {
        user.Id = GetNextUserId();
        user.CreatedDate = DateTime.Now;
        user.ModifiedDate = DateTime.Now;
        await _userCollection.InsertOneAsync(user);
        return;
    }

    public async Task<bool> UpdateUser(int id, User user)
    {
        var ExistingUser = await _userCollection.Find(u => u.Id == id).FirstOrDefaultAsync();

        if (ExistingUser == null)
        {
            return false;
        }

        ExistingUser.FirstName = user.FirstName ?? ExistingUser.FirstName;
        ExistingUser.LastName = user.LastName ?? ExistingUser.LastName;
        ExistingUser.Email = user.Email ?? ExistingUser.Email;
        ExistingUser.PasswordHash = user.PasswordHash ?? ExistingUser.PasswordHash;
        ExistingUser.Role = user.Role ?? ExistingUser.Role;
        ExistingUser.Description = user.Description ?? ExistingUser.Description;

        ExistingUser.ModifiedDate = DateTime.UtcNow;

        var filter = Builders<User>.Filter.Eq(u => u.Id, id);
        var result = await _userCollection.ReplaceOneAsync(filter, ExistingUser);
        // var result = await _userCollection.ReplaceOneAsync(u => u.Id == id, user);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteUser(int id) {
        FilterDefinition<User> filter = Builders<User>.Filter.Eq(user => user.Id, id);
        var result = await _userCollection.DeleteOneAsync(filter);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}


// Reference : https://www.youtube.com/watch?v=jJK9alBkzU0