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

    public async Task<List<User>> GetUsers() {
        return await _userCollection.Find(new BsonDocument()).ToListAsync();
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

    public async Task CreateUser(User UserToAdd)
    {
        UserToAdd.Id = GetNextUserId();
        await _userCollection.InsertOneAsync(UserToAdd);
        return;
    }

    public async Task UpdateUser(int id, User Usertoupdate)
    {
        var ExistingUser = await _userCollection.Find(u => u.Id == id).FirstOrDefaultAsync();

        if (ExistingUser == null)
        {
            return;
        }

        ExistingUser.FirstName = Usertoupdate.FirstName ?? ExistingUser.FirstName;
        ExistingUser.LastName = Usertoupdate.LastName ?? ExistingUser.LastName;
        ExistingUser.Email = Usertoupdate.Email ?? ExistingUser.Email;
        ExistingUser.PasswordHash = Usertoupdate.PasswordHash ?? ExistingUser.PasswordHash;
        ExistingUser.Role = Usertoupdate.Role ?? ExistingUser.Role;
        ExistingUser.Description = Usertoupdate.Description ?? ExistingUser.Description;

        ExistingUser.ModifiedDate = DateTime.UtcNow;

        var filter = Builders<User>.Filter.Eq(u => u.Id, id);
        await _userCollection.ReplaceOneAsync(filter, ExistingUser);
    }

    public async Task DeleteUser(int id) {
        FilterDefinition<User> filter = Builders<User>.Filter.Eq(user => user.Id, id);
        await _userCollection.DeleteOneAsync(filter);
        return;
    }
}


// Reference : https://www.youtube.com/watch?v=jJK9alBkzU0