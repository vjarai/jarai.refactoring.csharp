using System;
using Jarai.Refactoring.Backend.Original.Requests;
using Jarai.Refactoring.Backend.Original.Responses;

namespace Jarai.Refactoring.Backend.Original
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