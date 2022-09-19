using Refactoring3.Backend.Refactored.Requests;
using Refactoring3.Backend.Refactored.Responses;

namespace Refactoring3.Backend.Refactored.Handlers
{
    public class CalculateSumHandler : RequestHandler<CalculateSumRequest, CalculateSumResponse>
    {
        public override CalculateSumResponse HandleRequest(CalculateSumRequest request)
        {
            return new CalculateSumResponse { Sum = request.Number1 + request.Number2 };
        }

    }
}