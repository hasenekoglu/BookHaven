namespace LibraryManagementSystem.Application.Features.Commands.BookCommands.UpdateBook;

public class UpdateBookResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string CategoryName { get; set; }
}