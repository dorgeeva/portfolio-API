namespace portfolio_API.Models;
public class PostItem
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set;}
    public bool IsComplete { get; set; }

}