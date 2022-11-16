using IS.Web.DataAccess;

namespace IS.Web.Contractors
{
    public interface IRequestService
    {
        Task<int> GetCountAsync();
        Task<Request_LST> InsertAsync(ISDbContext db, Guid requestBy, string functionID, string requestStatus);
    }
}