namespace art_gallery.Models;

public class ArtTypes
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Origin { get; set; }
    public DateTime YearOfOrigin { get; set; }    

    public ArtTypes()
    {

    }

    public ArtTypes(int id, string name, DateTime yearoforigin, string? origin = null)
    {
        Id = id;
        Name = name;
        YearOfOrigin = yearoforigin;
        Origin = origin;
    }
    
}

