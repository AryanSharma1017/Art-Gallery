using art_gallery.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace art_gallery.Services;

public class ArtistService {
    private readonly IMongoCollection<Artist> _artistCollection;

    public ArtistService(IOptions<MongoDBSettings> _mongoDBSettings)
    {
        MongoClient client = new MongoClient(_mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(_mongoDBSettings.Value.DatabaseName);
        _artistCollection = database.GetCollection<Artist>("artists");
    }

    public async Task<List<Artist>> GetAllArtists() 
    {
        return await _artistCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<Artist> GetArtist(int id)
    {
        return await _artistCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
    }

    private int GetNextArtistId()
    {
        var currentID = _artistCollection.Find(a => true).SortByDescending(a => a.Id).Limit(1).FirstOrDefault();
        if (currentID == null)
        {
            return 1;
        }
        else
        {
            return currentID.Id + 1; 
        }
    }

    public async Task CreateArtist(Artist ArtistToAdd)
    {
        ArtistToAdd.Id = GetNextArtistId();
        ArtistToAdd.CreatedDate = DateTime.Now;
        ArtistToAdd.ModifiedDate = DateTime.Now;
        await _artistCollection.InsertOneAsync(ArtistToAdd);
        return;
    }

    public async Task<bool> UpdateArtist(int id, Artist Artisttoupdate)
    {
        var ExistingArtist = await _artistCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        if (ExistingArtist == null)
        {
            return false;
        }

        ExistingArtist.FirstName = Artisttoupdate.FirstName ?? ExistingArtist.FirstName;
        ExistingArtist.LastName = Artisttoupdate.LastName ?? ExistingArtist.LastName;
        ExistingArtist.Email = Artisttoupdate.Email ?? ExistingArtist.Email;
        ExistingArtist.Type = Artisttoupdate.Type ?? ExistingArtist.Type;
        ExistingArtist.About = Artisttoupdate.About ?? ExistingArtist.About;
        ExistingArtist.PhoneNumber = Artisttoupdate.PhoneNumber ?? ExistingArtist.PhoneNumber;
        ExistingArtist.Age = Artisttoupdate.Age != 0 ? Artisttoupdate.Age : ExistingArtist.Age;

        ExistingArtist.ModifiedDate = DateTime.UtcNow;

        var filter = Builders<Artist>.Filter.Eq(a => a.Id, id);

        var result = await _artistCollection.ReplaceOneAsync(filter, ExistingArtist);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteArtist(int id) {
        FilterDefinition<Artist> filter = Builders<Artist>.Filter.Eq(user => user.Id, id);
        var result = await _artistCollection.DeleteOneAsync(filter);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}

