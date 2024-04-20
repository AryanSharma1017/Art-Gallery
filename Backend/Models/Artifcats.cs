using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace art_gallery.Models;

public class Artifacts
{
    [BsonId]
    public int Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("type")]
    public string Type { get; set; }

    [BsonElement("price")]
    public int Price { get; set; }

    [BsonElement("artist_id")]
    public int ArtistID { get; set; }

    [BsonElement("gallery_id")]
    public int GalleryID { get; set; }

    [BsonElement("creation_date")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime? CreationDate { get; set; }

    [BsonElement("addition_date")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime AdditionDate { get; set; }

    [BsonElement("modified_date")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
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
