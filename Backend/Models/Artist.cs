namespace art_gallery.Models;

public class Artist
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Type { get; set; }
    public string? About { get; set; }
    public int PhoneNumber{get; set; }
    public int Age{get; set; }
    public DateTime CreatedDate { get; set; }    
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

