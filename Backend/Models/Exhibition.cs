using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;


namespace art_gallery.Models;
public class Exhibition
{
    [BsonId]
    [JsonPropertyName("_id")]
    public int Id { get; set; }

    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [BsonElement("description")]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [BsonElement("type")]
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    [BsonElement("start_date")]
    [JsonPropertyName("start_date")]
    public DateTime StartDate { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    [BsonElement("end_date")]
    [JsonPropertyName("end_date")]
    public DateTime EndDate { get; set; }

    [BsonElement("gallery_id")]
    [JsonPropertyName("gallery_id")]
    public int GalleryId { get; set; }

    // Default constructor
    public Exhibition() { }

    // Constructor with parameters
    public Exhibition(string name, string? description, string type, DateTime startDate, DateTime endDate, int galleryId)
    {
        Name = name;
        Description = description;
        Type = type;
        StartDate = startDate;
        EndDate = endDate;
        GalleryId = galleryId;
    }
}
