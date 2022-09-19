using System;
using Refactoring3.Backend.Refactored.Requests;
using Refactoring3.Backend.Refactored.Responses;

namespace Refactoring3.Backend.Refactored.Handlers
{
    public class CalculateTaxHandler : RequestHandler<CalculateTaxRequest, CalculateTaxResponse>
    {
        public override CalculateTaxResponse HandleRequest(CalculateTaxRequest request)
        {
            return new CalculateTaxResponse { Tax = request.Price * .19 };
        }
    }
}