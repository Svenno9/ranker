namespace backend.DTOs;

public class CreateItemDto
{
    public required string Title { get; set; }

    public int? Score { get; set; }

    public int? Rank { get; set; }
}