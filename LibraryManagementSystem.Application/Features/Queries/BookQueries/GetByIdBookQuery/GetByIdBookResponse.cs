namespace LibraryManagementSystem.Application.Features.Queries.BookQueries.GetByIdBookQuery;

public class GetByIdBookResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public DateTime PublishedDate { get; set; }
    public Guid? CategoryId { get; set; }
}