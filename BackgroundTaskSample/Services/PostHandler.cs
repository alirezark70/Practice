using System.Diagnostics;

namespace BackgroundTaskSample.Services
{
    public class PostHandler : DelegatingHandler
    {
        //لاگ زدن و انجام فرایند مربوط با
        //httpMassageHandler
        private readonly ILogger<PostHandler> _logger;
        private readonly Stopwatch _stopwatch;

        public PostHandler(ILogger<PostHandler> logger, Stopwatch stopwatch)
        {
            this._logger = logger;
            this._stopwatch = stopwatch;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Log");
            var reuslt = await base.SendAsync(request, cancellationToken);

            _logger.LogInformation("log");
            //comment
            return reuslt;
        }
    }
}


    
