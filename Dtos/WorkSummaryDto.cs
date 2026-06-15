namespace MusicWorksAPI.Dtos
{
    public record WorkSummaryDto(
            int Id,
            string Title,
            string Category,
            string Instrumentation,
            decimal Price,
            int PublicationYear
        );
}

      