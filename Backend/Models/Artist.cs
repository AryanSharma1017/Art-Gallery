using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace art_gallery.Models;

public class Artist
{
    [BsonId]
    public int Id { get; set; }

    [BsonElement("first_name")]
    public string FirstName { get; set; }

    [BsonElement("last_name")]
    public string LastName { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("type")]
    public string Type { get; set; }

    [BsonElement("about")]
    public string? About { get; set; }
    public int PhoneNumber{get; set; }
    public int Age{get; set; }

    [BsonElement("created_date")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime CreatedDate { get; set; }  

    [BsonElement("modified_date")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]  
    public DateTime ModifiedDate { get; set; }


    public Artist()
    {

    }

    public Artist(int id, string firstname, string lastname, string email, string type, int phonenumber, int age, DateTime createddate, DateTime modifieddate, string? about = null)
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

