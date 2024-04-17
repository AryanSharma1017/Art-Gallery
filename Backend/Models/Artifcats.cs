namespace art_gallery.Models;

public class Artifacts
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Type { get; set; }
    public int Price{get; set; }
    public int ArtistID{get; set; }
    public int GalleryID{get; set; }
    public DateTime CreationDate { get; set; }    
    public DateTime AdditionDate { get; set; }    
    public DateTime ModifiedDate { get; set; }


    public Artifacts()
    {

    }

    public Artifacts(int id, string name, string type, int price, int artistid, int galleryid, DateTime creationdate, DateTime additiondate, DateTime modificationdate, string? description = null)
    {
        Id = id;
        Name = name;
        Type = type;
        Price = price;
        ArtistID = artistid;
        GalleryID = galleryid;
        CreationDate = creationdate;
        ModifiedDate = modificationdate;
        AdditionDate = additiondate;
        ModifiedDate = modificationdate;
    }
    
}

