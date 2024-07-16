namespace LibraryManagementSystem.Application.Features.Commands.LoanCommands.CreateLoan;

public class CreateLoanResponse
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public string UserId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}