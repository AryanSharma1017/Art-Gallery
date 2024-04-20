using System;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace art_gallery.Models;

public class Artifacts
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

    [BsonElement("price")]
    [JsonPropertyName("price")]
    public int Price { get; set; }

    [BsonElement("artist_id")]
    [JsonPropertyName("artist_id")]
    public int ArtistID { get; set; }

    [BsonElement("gallery_id")]
    [JsonPropertyName("gallery_id")]
    public int GalleryID { get; set; }

    [BsonElement("creation_date")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    [JsonPropertyName("creation_date")]
    public DateTime? CreationDate { get; set; }

    [BsonElement("addition_date")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    [JsonPropertyName("addition_date")]
    public DateTime AdditionDate { get; set; }

    [BsonElement("modified_date")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    [JsonPropertyName("modified_date")]
    public DateTime ModifiedDate { get; set; }

    public Artifacts()
    {

    }

    public Artifacts(int id, string name, string type, int price, int artistId, int galleryId, DateTime creationDate, DateTime additionDate, DateTime modifiedDate, string? description = null)
    {
        Id = id;
        Name = name;
        Type = type;
        Price = price;
        ArtistID = artistId;
        GalleryID = galleryId;
        CreationDate = creationDate;
        AdditionDate = additionDate;
        ModifiedDate = modifiedDate;
        Description = description;
    }
}
