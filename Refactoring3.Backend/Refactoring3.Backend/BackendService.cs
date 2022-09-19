using System;
using Refactoring3.Backend.Original.Requests;
using Refactoring3.Backend.Original.Responses;

namespace Refactoring3.Backend.Original
{
    public class BackendService
    {
        public Response ProcessRequest(Request request)
        {

            if (request is CalculateSumRequest calculateSumRequest)
            {
                // Simulate some complicated calculations...
                return new CalculateSumResponse { Sum = calculateSumRequest.Number1 + calculateSumRequest.Number2 };
            }
            else if (request is CalculateTaxRequest calculateTaxRequest)  
            {
                // Simulate some complicated calculations...
                return new CalculateTaxResponse { Tax = calculateTaxRequest.Price * .19 };
            }

            throw new InvalidOperationException("Unknown request Type!");

        }
    }
}