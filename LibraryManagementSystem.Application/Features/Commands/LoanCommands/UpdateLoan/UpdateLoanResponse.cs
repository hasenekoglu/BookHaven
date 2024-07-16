namespace LibraryManagementSystem.Application.Features.Commands.LoanCommands.UpdateLoan;

public class UpdateLoanResponse
{
    
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public string UserName { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}