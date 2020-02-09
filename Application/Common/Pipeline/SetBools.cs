using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Common.Pipeline
{
    public class SetBools<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        
        private readonly Stopwatch _timer;

        public SetBools()
        {
            _timer = new Stopwatch();
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            return response;
        }
    }
}