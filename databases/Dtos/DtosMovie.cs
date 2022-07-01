using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace databases.Dtos;

public class DtosMovie
{   

    [Required]
    [StringLength(maximumLength: 255, MinimumLength = 5)]
    public string Title { get; set; }

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DtosEGenre? Genre { get; set; }

    [Required]
    [Range(typeof(DateTime), "1/1/1950", "1/1/2023")]  
    public DateTime ReleaseData { get; set; }

    [MaxLength(1024)]
    public string? Description { get; set; }

    [Required]
    [Range(1, 10)]
    public double Imdb { get; set; }
    
    public long Viewed { get; set; }
    public IFormFile? BannerImage { get; set; }
 
}