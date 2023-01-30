using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Api
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var server = WireMockServer.StartWithAdminInterface(8080);
            Console.WriteLine("API is running at http://localhost:{0}", string.Join(",", server.Ports));

            server
                .Given(Request.Create()
                    .WithPath("/echo")
                    .UsingGet()
                    )
                .RespondWith(Response.Create()
                    .WithSuccess()
                    .WithBodyAsJson("Your path is {{request.path}}.")
                    .WithTransformer());

            server
                .Given(Request.Create()
                    .WithPath("/healthcheck")
                    .UsingGet()
                    )
                .RespondWith(Response.Create()
                    .WithSuccess()
                    .WithBodyAsJson($"Current time: {DateTime.Now}"));

            server
                .Given(Request.Create()
                    .WithPath("/slow_response")
                    .UsingGet()
                    )
                .RespondWith(Response.Create()
                    .WithSuccess()
                    .WithBodyAsJson($"Current time: {DateTime.Now}")
                    .WithDelay(TimeSpan.FromSeconds(1)));

            var paths = server.Mappings.Select(m => m.Path).ToList();

            Console.WriteLine();
            Console.WriteLine("Available methods:");
            Console.WriteLine("  /echo");
            Console.WriteLine("  /healthcheck");
            Console.WriteLine("  /slow_response");

            Console.WriteLine();
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}