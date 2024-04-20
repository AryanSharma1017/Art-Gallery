using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace art_gallery.Models;

public class ArtTypes
{
    [BsonId]
    public int Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("origin")]
    public string? Origin { get; set; }

    [BsonElement("year_of_origin")]
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
