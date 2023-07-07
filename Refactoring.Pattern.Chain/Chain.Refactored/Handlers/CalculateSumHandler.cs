using Jarai.Refactoring.Backend.Refactored.Requests;
using Jarai.Refactoring.Backend.Refactored.Responses;

namespace Jarai.Refactoring.Backend.Refactored.Handlers
{
    public class CalculateSumHandler : RequestHandler<CalculateSumRequest, CalculateSumResponse>
    {
        public override CalculateSumResponse HandleRequest(CalculateSumRequest request)
        {
            return new CalculateSumResponse { Sum = request.Number1 + request.Number2 };
        }

    }
}