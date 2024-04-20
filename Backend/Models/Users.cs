using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace art_gallery.Models;

public class User
{
    [BsonId]
    // [BsonRepresentation(BsonType.ObjectId)]
    //this allows work on ID as string and save it as ObjectId in mongoDB 
    //and if it doesn't exists it will create a new ObjectId automatically
    //so that we dont have to make a unique string ID
    public int Id { get; set; }

    [BsonElement("first_name")]
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [BsonElement("last_name")]
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [BsonElement("email")]
    [JsonPropertyName("email")]
    public string Email { get; set; }

    [BsonElement("password_hash")]
    [JsonPropertyName("password_hash")]
    public string PasswordHash { get; set; }

    [BsonElement("role")]
    [JsonPropertyName("role")]
    public string Role { get; set; }

    [BsonElement("description")]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [BsonElement("created_date")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    [JsonPropertyName("created_date")]
    public DateTime CreatedDate { get; set; }

    [BsonElement("modified_date")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    [JsonPropertyName("modified_date")]
    //this can be used to change the json name of the property
    public DateTime ModifiedDate { get; set; }

    public User () 
    {
        
    }

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
