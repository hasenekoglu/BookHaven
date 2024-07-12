namespace LibraryManagementSystem.Application.Features.Commands.LoanCommands.UpdateLoan;

public class UpdateLoanResponse
{
    public Guid BookId { get; set; }
    public int UserId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}