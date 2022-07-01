using System.ComponentModel.DataAnnotations;

namespace databases.Entities;

public class Movie
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public EGenre Genre { get; set; }
    public DateTime ReleaseData { get; set; }
    public string Description { get; set; }
    public double Imdb { get; set; }
    public long Viewed { get; set; }

    
}