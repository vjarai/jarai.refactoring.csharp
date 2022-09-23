using Jarai.Refactoring.Backend.Refactored.Requests;
using Jarai.Refactoring.Backend.Refactored.Responses;

namespace Jarai.Refactoring.Backend.Refactored
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