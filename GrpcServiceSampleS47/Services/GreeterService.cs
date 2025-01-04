using Grpc.Core;
using GrpcServiceSampleS47;

namespace GrpcServiceSampleS47.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            foreach (var item in request.Age)
            {
                Console.WriteLine(item);
            }

            foreach (var item in request.Student)
            {
               
            }
            if (request.IsRequeird)
            {
                return Task.FromResult(new HelloReply
                {
                    Message = "Hello " + request.Name
                });

            }

            return base.SayHello(request, context);
        }
    }
}
