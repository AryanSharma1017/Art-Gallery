using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace art_gallery.Models;
public class ArtGallery
{
    [BsonId] // MongoDB document primary key
    public int Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("address")]
    public string Address { get; set; }

    [BsonElement("numberOfArtifacts")]
    public int NumberOfArtifacts { get; set; }

    [BsonElement("ongoingExhibition")]
    public bool? OngoingExhibition { get; set; }

    [BsonElement("exhibitionId")]
     // Linking this to another document type, allowed to be null
    public int? ExhibitionId { get; set; }

    // Default constructor
    public ArtGallery() { }

    // Constructor with parameters
    public ArtGallery(int id,string name, string address, int numberOfArtifacts, bool? ongoingExhibition = null, int? exhibitionId = null)
    {
        Id = id;
        Name = name;
        Address = address;
        NumberOfArtifacts = numberOfArtifacts;
        OngoingExhibition = ongoingExhibition;
        ExhibitionId = exhibitionId;
    }
}
