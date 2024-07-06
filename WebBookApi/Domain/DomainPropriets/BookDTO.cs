namespace WebBookApi.Domain.NovaPasta1;

public record BookDTO
{
    public required string NameBook { get; set; }

    public required string Author { get; set; }

    public required string DescriptionBook { get; set; }

    public int YearCreate { get; set; }

    public bool IsDeleted { get; set; }

}
