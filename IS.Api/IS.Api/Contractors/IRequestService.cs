using IS.Api.DataAccess;

namespace IS.Api.Contractors
{
    public interface IRequestService
    {
        Task<int> GetCountAsync();
        Task<Request_LST> InsertAsync(ISDbContext db, Guid requestBy, string functionID, string requestStatus);
    }
}