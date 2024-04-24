using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace art_gallery.Models;
public class ArtGallery
{
    [BsonId]
    [JsonPropertyName("_id")]
    public int Id { get; set; }

    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [BsonElement("address")]
    [JsonPropertyName("address")]
    public string Address { get; set; }

    [BsonElement("number_of_artifacts")]
    [JsonPropertyName("number_of_artifacts")]
    public int NumberOfArtifacts { get; set; }

    [BsonElement("ongoing_exhibition")]
    [JsonPropertyName("ongoing_exhibition")]
    public string? OngoingExhibition { get; set; }

    [BsonElement("exhibition_id")]
    [JsonPropertyName("exhibition_id")]
    public int? ExhibitionId { get; set; }

    public ArtGallery() { }

    public ArtGallery(int id,string name, string address, int numberOfArtifacts, string? ongoingExhibition = null, int? exhibitionId = null)
    {
        Id = id;
        Name = name;
        Address = address;
        NumberOfArtifacts = numberOfArtifacts;
        OngoingExhibition = ongoingExhibition;
        ExhibitionId = exhibitionId;
    }
}
