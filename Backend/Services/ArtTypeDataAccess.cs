using art_gallery.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace art_gallery.Services;

public class ArtTypeService {
    private readonly IMongoCollection<ArtTypes> _artTypeCollection;

    public ArtTypeService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _artTypeCollection = database.GetCollection<ArtTypes>("art_types");
    }

    public async Task<List<ArtTypes>> GetAllArtTypes() {
        return await _artTypeCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<ArtTypes> GetArtType(int id) {
        return await _artTypeCollection.Find(at => at.Id == id).FirstOrDefaultAsync();
    }

    private int GetNextArtTypeId()
    {
        var currentID = _artTypeCollection.Find(u => true).SortByDescending(u => u.Id).Limit(1).FirstOrDefault();
        if (currentID == null)
        {
            return 1;
        }
        else
        {
            return currentID.Id + 1; 
        }
    }
    
    public async Task CreateArtType(ArtTypes artTypeToAdd)
    {
        artTypeToAdd.Id = GetNextArtTypeId();
        await _artTypeCollection.InsertOneAsync(artTypeToAdd);
        return;
    }

    public async Task<bool> UpdateArtType(int id, ArtTypes artTypeToUpdate)
    {
        var ExistingArtType = await _artTypeCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        if (ExistingArtType == null)
        {
            return false;
        }

        ExistingArtType.Name = artTypeToUpdate.Name ?? ExistingArtType.Name;
        ExistingArtType.Origin = artTypeToUpdate.Origin ?? ExistingArtType.Origin;
        ExistingArtType.YearOfOrigin = artTypeToUpdate.YearOfOrigin != 0 ? artTypeToUpdate.YearOfOrigin :  ExistingArtType.YearOfOrigin;;
        
        var filter = Builders<ArtTypes>.Filter.Eq(a => a.Id, id);

        var result = await _artTypeCollection.ReplaceOneAsync(filter, ExistingArtType);

        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteArtType(int id) {

        var result = await _artTypeCollection.DeleteOneAsync(at => at.Id == id);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}
