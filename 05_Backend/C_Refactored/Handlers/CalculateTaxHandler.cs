using Jarai.Refactoring.Backend.Refactored.Requests;
using Jarai.Refactoring.Backend.Refactored.Responses;

namespace Jarai.Refactoring.Backend.Refactored.Handlers
{
    public class CalculateTaxHandler : RequestHandler<CalculateTaxRequest, CalculateTaxResponse>
    {
        public override CalculateTaxResponse HandleRequest(CalculateTaxRequest request)
        {
            return new CalculateTaxResponse { Tax = request.Price * .19 };
        }
    }
}