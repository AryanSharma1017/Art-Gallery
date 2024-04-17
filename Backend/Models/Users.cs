using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace art_gallery.Models;
public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] // MongoDB-specific attribute for the ID
    public int Id { get; set; }

    [BsonElement("firstName")]
    public string FirstName { get; set; }

    [BsonElement("lastName")]
    public string LastName { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("passwordHash")]
    public string PasswordHash { get; set; }

    [BsonElement("role")]
    public string Role { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("createdDate")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime CreatedDate { get; set; }

    [BsonElement("modifiedDate")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime ModifiedDate { get; set; }

    public User () {}

    public User (int id, string firstname, string lastname, string email, string passwordhash, string role, DateTime createddate, DateTime modifieddate, string? description = null) 
    {
        Id = id;
        FirstName = firstname;
        LastName = lastname;
        Email = email;
        PasswordHash = passwordhash;
        Role = role;
        Description = description;
        CreatedDate = createddate;
        ModifiedDate = modifieddate;
    }
}
