namespace LibraryManagementSystem.Application.Features.Queries.LoanQueries.GetByIdLoanQuery;

public class GetByIdLoanResponse
{
    public Guid BookId { get; set; }
    public int UserId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}