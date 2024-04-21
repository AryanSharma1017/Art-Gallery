using System;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace art_gallery.Models;

public class ArtTypes
{
    [BsonId]
    [JsonPropertyName("_id")]
    public int Id { get; set; }

    [BsonElement("name")]
    [JsonPropertyName("name")] 
    public string Name { get; set; }

    [BsonElement("origin")]
    [JsonPropertyName("origin")] 
    public string? Origin { get; set; }

    [BsonElement("year_of_origin")]
    [JsonPropertyName("year_of_origin")] 
    public int YearOfOrigin { get; set; }

    public ArtTypes() {}

    public ArtTypes(int id, string name, int yearOfOrigin, string? origin = null)
    {
        Id = id;
        Name = name;
        YearOfOrigin = yearOfOrigin;
        Origin = origin;
    }
}
