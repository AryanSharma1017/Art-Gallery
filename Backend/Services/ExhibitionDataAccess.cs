using art_gallery.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace art_gallery.Services;

public class ExhibitionService{
    private readonly IMongoCollection<Exhibition> _exhibitionCollection;

    public ExhibitionService(IOptions<MongoDBSettings> _mongoDBSettings)
    {
        MongoClient client = new MongoClient(_mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(_mongoDBSettings.Value.DatabaseName);
        _exhibitionCollection = database.GetCollection<Exhibition>("exhibitions");
    }

    public async Task<List<Exhibition>> GetAllExhibitions()
    {
        return await _exhibitionCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<Exhibition> GetExhibition(int id)
    {
        return await _exhibitionCollection.Find(e => e.Id == id).FirstOrDefaultAsync();
    }

    private int GetNextExhibitionId()
    {
        var currentID = _exhibitionCollection.Find(u => true).SortByDescending(u => u.Id).Limit(1).FirstOrDefault();
        if (currentID == null)
        {
            return 1;
        }
        else
        {
            return currentID.Id + 1; 
        }
    }

    public async Task AddExhibition(Exhibition newExhibition)
    {
        newExhibition.Id = GetNextExhibitionId();
        await _exhibitionCollection.InsertOneAsync(newExhibition);
        return;
    }

    public async Task<bool> UpdateExhibition(int id, Exhibition updatedExhibition)
    {
        var existingExhibition = await _exhibitionCollection.Find(u => u.Id ==id).FirstOrDefaultAsync();

        if(existingExhibition == null)
        {
            return false;
        }

        existingExhibition.Name = updatedExhibition.Name ?? existingExhibition.Name;
        existingExhibition.Description = updatedExhibition.Description ?? existingExhibition.Description;
        existingExhibition.Type = updatedExhibition.Type ?? existingExhibition.Type;
        existingExhibition.GalleryId = updatedExhibition.GalleryId != 0 ? updatedExhibition.GalleryId :  existingExhibition.GalleryId;
        existingExhibition.StartDate = updatedExhibition.StartDate != DateTime.MinValue ? updatedExhibition.StartDate : existingExhibition.StartDate;
        existingExhibition.EndDate = updatedExhibition.EndDate != DateTime.MinValue ? updatedExhibition.EndDate : existingExhibition.EndDate;

        var filter = Builders<Exhibition>.Filter.Eq(u => u.Id, id);

        var result = await _exhibitionCollection.ReplaceOneAsync(filter, existingExhibition);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteExhibition(int id)
    {
        FilterDefinition<Exhibition> filter = Builders<Exhibition>.Filter.Eq(e => e.Id, id);
        var result = await _exhibitionCollection.DeleteOneAsync(filter);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}

