using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace art_gallery.Models;

public class Artist
{
    [BsonId]
    [JsonPropertyName("_id")]
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

    [BsonElement("type")]
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [BsonElement("about")]
    [JsonPropertyName("about")]
    public string? About { get; set; }

    [BsonElement("phone_number")]
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }
    [BsonElement("age")]
    [JsonPropertyName("age")]
    public int Age { get; set; }

    [BsonElement("created_date")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    [JsonPropertyName("created_date")]
    public DateTime CreatedDate { get; set; }  

    [BsonElement("modified_date")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]  
    [JsonPropertyName("modified_date")]
    public DateTime ModifiedDate { get; set; }


    public Artist()
    {

    }

    public Artist(int id, string firstname, string lastname, string email, string type, string phonenumber, int age, DateTime createddate, DateTime modifieddate, string? about = null)
    {
        Id = id;
        FirstName = firstname;
        LastName = lastname;
        Email = email;
        Type = type;
        PhoneNumber = phonenumber;
        Age = age;
        CreatedDate = createddate;
        ModifiedDate = modifieddate;
        About = about;
    }
    
}

