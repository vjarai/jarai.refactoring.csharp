using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Refactoring3.Backend.Refactored.Requests;
using Refactoring3.Backend.Refactored.Responses;

namespace Refactoring3.Backend.Refactored
{

    public abstract class RequestHandler
    {
        public abstract Response HandleRequest(Request request);

        public abstract bool CanHandleRequest(Request request);
    }

    public abstract class RequestHandler<TRequest, TResponse> : RequestHandler
        where TRequest : Request
        where TResponse : Response
    {
        public override Response HandleRequest(Request request)
        {
            return HandleRequest(request as TRequest);
        }

        public abstract TResponse HandleRequest(TRequest request);

        public override bool CanHandleRequest(Request request)
        {
            return request is TRequest;
        }
    }
}