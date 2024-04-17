using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace art_gallery.Models;
public class Exhibition
{
    [BsonId] // MongoDB document primary key
    [BsonRepresentation(BsonType.ObjectId)]
    public int Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("type")]
    public string Type { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)] // Ensures the date is handled in UTC
    [BsonElement("startDate")]
    public DateTime StartDate { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    [BsonElement("endDate")]
    public DateTime EndDate { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("galleryId")]
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
