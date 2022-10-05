using IS.Web.Contractor;
using IS.Web.DataAccess;
using IS.Web.Models;

namespace IS.Web.Controllers
{
    public static class UtilityController
    {
        public async static Task<Request> GenerateNewRequest(IBaseRepository<Request> requestRepo, 
                                                            Guid requestBy,
                                                            string functionID,
                                                            string requestStatus)
        {
            var newRequestID = string.Empty;
            var dateToday = DateTime.Parse(Globals.EXEC_DATE);

            var lastRequest = await requestRepo.Last(condition => condition.CreatedDate == dateToday,
                                                     sort => sort.RequestID);

            if (lastRequest == null)
            {
                newRequestID = Globals.REQUESTID_DEFAULT;
            }
            else
            {
                var lastRequestID = lastRequest.RequestID;
                var firstLayer = Globals.REQUESTID_FIRST_LAYER;
                var secondLayer = Globals.REQUESTID_SECOND_LAYER;

                //Get last RequestID third layer
                var lastThirdLayer = lastRequestID.Substring(Globals.REQUESTID_DEFAULT_LENGTH - Globals.REQUESTID_THIRD_LAYER_LENGTH, Globals.REQUESTID_THIRD_LAYER_LENGTH);

                //Get new RequestID third layer
                var newThirdLayer = (int.Parse(lastThirdLayer) + 1).ToString().PadLeft(Globals.REQUESTID_THIRD_LAYER_LENGTH, Constants.ZERO);

                //Construct new RequestID
                newRequestID = String.Concat(firstLayer, secondLayer, newThirdLayer);
            }

            var newRequest = new Request
            {
                RequestID = newRequestID,
                FunctionID = functionID,
                Status = requestStatus,
                ApprovedBy = null,
                ApprovedDate = null,
                CreatedBy = requestBy,
                CreatedDate = dateToday,
                ModifiedBy = null,
                ModifiedDate = null
            };

            return newRequest;
        }
    }
}
