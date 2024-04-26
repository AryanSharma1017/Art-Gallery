using art_gallery.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace art_gallery.Services;

public class ArtGalleryService
{
    private readonly IMongoCollection<ArtGallery> _artGalleryCollection;

    public ArtGalleryService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _artGalleryCollection = database.GetCollection<ArtGallery>("art_galleries");
    }

    public async Task<List<ArtGallery>> GetAllGalleries()
    {
        return await _artGalleryCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<ArtGallery> GetGallery(int id)
    {
        return await _artGalleryCollection.Find(g => g.Id == id).FirstOrDefaultAsync();
    }

    private int GetNextGalleryId()
    {
        var currentID = _artGalleryCollection.Find(g => true).SortByDescending(g => g.Id).Limit(1).FirstOrDefault();
        if (currentID == null)
        {
            return 1;
        }
        else
        {
            return currentID.Id + 1; 
        }
    }

    public async Task CreateGallery(ArtGallery gallery)
    {
        gallery.Id = GetNextGalleryId();
        await _artGalleryCollection.InsertOneAsync(gallery);
        return;
    }

    public async Task<bool> UpdateGallery(int id, ArtGallery gallery)
    {
        var existingGallery = await _artGalleryCollection.Find(g => g.Id == id).FirstOrDefaultAsync();

        if (existingGallery == null)
        {
            return false;
        }

        existingGallery.Name = gallery.Name ?? existingGallery.Name;
        existingGallery.Address = gallery.Address ?? existingGallery.Address;
        existingGallery.NumberOfArtifacts = gallery.NumberOfArtifacts != 0 ? gallery.NumberOfArtifacts :  existingGallery.NumberOfArtifacts;
        existingGallery.OngoingExhibition = gallery.OngoingExhibition ?? existingGallery.OngoingExhibition;
        if(existingGallery.OngoingExhibition == "true")
            existingGallery.ExhibitionId = gallery.ExhibitionId != 0 ? gallery.ExhibitionId :  existingGallery.ExhibitionId;
        else
            existingGallery.ExhibitionId = -1;

        var filter = Builders<ArtGallery>.Filter.Eq(g => g.Id, id);

        var result = await _artGalleryCollection.ReplaceOneAsync(filter, existingGallery);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteGallery(int id)
    {
        FilterDefinition<ArtGallery> filter = Builders<ArtGallery>.Filter.Eq(g => g.Id, id);
        var result = await _artGalleryCollection.DeleteOneAsync(filter);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}
