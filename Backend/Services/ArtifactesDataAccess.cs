using art_gallery.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace art_gallery.Services;

public class ArtifactService {
    private readonly IMongoCollection<Artifacts> _artifactCollection;

    public ArtifactService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _artifactCollection = database.GetCollection<Artifacts>("artifacts");
    }

    public async Task<List<Artifacts>> GetAllArtifacts() {
        return await _artifactCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<Artifacts> GetArtifact(int id) {
        return await _artifactCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
    }

    private int GetNextArtifactId()
    {
        var currentID = _artifactCollection.Find(a => true).SortByDescending(a => a.Id).Limit(1).FirstOrDefault();
        if (currentID == null)
        {
            return 1;
        }
        else
        {
            return currentID.Id + 1; 
        }
    }
    public async Task CreateArtifact(Artifacts artifactToAdd)
    {
        artifactToAdd.Id = GetNextArtifactId();
        artifactToAdd.AdditionDate = DateTime.Now;
        artifactToAdd.ModifiedDate = DateTime.Now;
        await _artifactCollection.InsertOneAsync(artifactToAdd);
        return;
    }

    public async Task<bool> UpdateArtifact(int id, Artifacts artifact)
    {
        var ExistingArtifact = await _artifactCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        if (ExistingArtifact == null)
        {
            return false;
        }

        ExistingArtifact.Name = artifact.Name ?? ExistingArtifact.Name;
        ExistingArtifact.Description = artifact.Description ?? ExistingArtifact.Description;
        ExistingArtifact.Type = artifact.Type ?? ExistingArtifact.Type;
        ExistingArtifact.Price = artifact.Price != 0 ? artifact.Price : ExistingArtifact.Price;
        ExistingArtifact.ArtistID = artifact.ArtistID != 0 ? artifact.ArtistID : ExistingArtifact.ArtistID;
        ExistingArtifact.GalleryID = artifact.GalleryID != 0 ? artifact.GalleryID : ExistingArtifact.GalleryID;
        ExistingArtifact.CreationDate = artifact.CreationDate ?? ExistingArtifact.CreationDate;
        ExistingArtifact.ModifiedDate = DateTime.UtcNow;

        var filter = Builders<Artifacts>.Filter.Eq(u => u.Id, id);

        var result = await _artifactCollection.ReplaceOneAsync(filter, ExistingArtifact);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteArtifact(int id) {
        FilterDefinition<Artifacts> filter = Builders<Artifacts>.Filter.Eq(a => a.Id, id);
        var result = await _artifactCollection.DeleteOneAsync(a => a.Id == id);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}
