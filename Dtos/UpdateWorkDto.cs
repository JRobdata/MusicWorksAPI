using System.ComponentModel.DataAnnotations;

namespace MusicWorksAPI.Dtos
{
    public record UpdateWorkDto(
      
        [Required][StringLength(100)] string Title,
        [Range(1, 10)] int CategoryId,
        [StringLength(200)] string Instrumentation,
        [Range(1, 100)] decimal Price,
        [Range(2000, 2100)] int PublicationYear
    );        
}
