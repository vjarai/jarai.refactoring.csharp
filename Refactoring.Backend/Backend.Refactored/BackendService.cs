using System;
using System.Collections.Generic;
using System.Linq;
using Jarai.Refactoring.Backend.Refactored.Requests;
using Jarai.Refactoring.Backend.Refactored.Responses;

namespace Jarai.Refactoring.Backend.Refactored
{
    public class BackendService
    {
        private readonly IEnumerable<RequestHandler> _requestHandlers;


        public BackendService()
        {
            _requestHandlers =  CreateRequestHandlers().ToArray();
        }

        private IEnumerable<RequestHandler> CreateRequestHandlers()
        {
            var requestHandlerType = typeof(RequestHandler);

            var handlerTypes = requestHandlerType.Assembly.GetTypes().Where(t => requestHandlerType.IsAssignableFrom(t) && !t.IsAbstract);

            foreach (var handlerType in handlerTypes)
                yield return ((RequestHandler)Activator.CreateInstance(handlerType));
        }

        public Response ProcessRequest(Request request)
        {
            var handler = _requestHandlers.FirstOrDefault(h => h.CanHandleRequest(request));

            if (handler == null)
                throw new InvalidOperationException("Unknown request Type!");

            return handler.HandleRequest(request);
        }
    }
}