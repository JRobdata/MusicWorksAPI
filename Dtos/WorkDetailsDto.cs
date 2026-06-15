namespace MusicWorksAPI.Dtos
{
    public record WorkDetailsDto(
        int Id,
        string Title,
        int CategoryId,
        string Instrumentation,
        decimal Price,
        int PublicationYear
    );
}
