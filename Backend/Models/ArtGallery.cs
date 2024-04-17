using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace art_gallery.Models;
public class ArtGallery
{
    [BsonId] // MongoDB document primary key
    [BsonRepresentation(BsonType.ObjectId)] // Id represented as ObjectId but handled in C# as string
    public string Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("address")]
    public string Address { get; set; }

    [BsonElement("numberOfArtifacts")]
    public int NumberOfArtifacts { get; set; }

    [BsonElement("ongoingExhibition")]
    public bool OngoingExhibition { get; set; }

    [BsonElement("exhibitionId")]
    [BsonRepresentation(BsonType.ObjectId)] // Linking this to another document type, allowed to be null
    public string? ExhibitionId { get; set; }

    // Default constructor
    public ArtGallery() { }

    // Constructor with parameters
    public ArtGallery(string name, string address, int numberOfArtifacts, bool ongoingExhibition, string? exhibitionId = null)
    {
        Name = name;
        Address = address;
        NumberOfArtifacts = numberOfArtifacts;
        OngoingExhibition = ongoingExhibition;
        ExhibitionId = exhibitionId;
    }
}
