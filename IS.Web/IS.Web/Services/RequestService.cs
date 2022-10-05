using IS.Web.Contractors;
using IS.Web.DataAccess;
using IS.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IS.Web.Services
{
    public class RequestService : IRequestService
    {
        private readonly ISDbContext _db;
        public RequestService(ISDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<int> GetCountAsync()
        {
            return await _db.Request_LST.CountAsync();
        }

        public async Task<Request_LST> InsertAsync(ISDbContext db,  Guid requestBy, string functionID, string requestStatus)
        {
            var newRequest = new Request_LST
            {
                RequestID = GenerateNewRequestID(db),
                FunctionID = functionID,
                Status = requestStatus,
                ApprovedBy = null,
                ApprovedDate = null,
                CreatedBy = requestBy,
                CreatedDate = Globals.EXEC_DATE,
                ModifiedBy = null,
                ModifiedDate = null
            };

            await db.Request_LST.AddAsync(newRequest);
            await db.SaveChangesAsync();
            return newRequest;
        }

        private string GenerateNewRequestID(ISDbContext db)
        {
            var newRequestID = string.Empty;
            var lastRequest = db.Request_LST.Where(data => data.CreatedDate == Globals.EXEC_DATE)
                                            .OrderBy(data => data.RequestID)
                                            .ToList();

            if (lastRequest == null || lastRequest.Count() == 0)
            {
                newRequestID = Globals.REQUESTID_DEFAULT;
            }
            else
            {
                var lastRequestID = lastRequest.Last().RequestID;
                var firstLayer = Globals.REQUESTID_FIRST_LAYER;
                var secondLayer = Globals.REQUESTID_SECOND_LAYER;

                //Get last RequestID third layer
                var lastThirdLayer = lastRequestID.Substring(Globals.REQUESTID_DEFAULT_LENGTH - Globals.REQUESTID_THIRD_LAYER_LENGTH, Globals.REQUESTID_THIRD_LAYER_LENGTH);

                //Get new RequestID third layer
                var newThirdLayer = (int.Parse(lastThirdLayer) + 1).ToString().PadLeft(Globals.REQUESTID_THIRD_LAYER_LENGTH, Constants.ZERO);

                //Construct new RequestID
                newRequestID = String.Concat(firstLayer, secondLayer, newThirdLayer);
            }

            return newRequestID;
        }
    }
}
