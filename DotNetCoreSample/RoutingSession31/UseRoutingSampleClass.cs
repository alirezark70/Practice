namespace DotNetCoreSample.RoutingSession31
{
    public static class UseRoutingSampleClass
    {
        
        public static void UseRunSample(this WebApplication application)
        {
            application.Run(async (context) =>
            {
                await context.Response.WriteAsync("Is Ok");
            });
        }

        public static void UseLearningRouting(this WebApplication application)
        {

        }
    }

}
