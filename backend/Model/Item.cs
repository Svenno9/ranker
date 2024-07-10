namespace backend.Model;

public class Item
{
    public Guid Id { get; set; }
    
    public required string Title { get; set; }
    public int? Score { get; set; }
    public int? Rank { get; set; }
}