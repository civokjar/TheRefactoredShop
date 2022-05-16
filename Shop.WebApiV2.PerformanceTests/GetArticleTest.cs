using NBomber.CSharp;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop.WebApiV2.PerformanceTests
{
    [TestFixture]
    internal class GetArticleTest
    {

        [Test]
        public void GetArticleTestCaseScenario1()
        {

            var httpFactory = ClientFactory.Create(
                  name: "http_factory",
                  clientCount: 1,
                  initClient: (number, context) => Task.FromResult(new HttpClient())
              );
            var step = Step.Create("step", httpFactory, execute: async context =>
            {


                var response = await context.Client.GetAsync("https://localhost:44349/Shop/Article/12145?maxExpectedPrice=350",
                                                    context.CancellationToken);

                return NBomber.Plugins.Http.FSharp.Response.ofHttp(new HttpResponseMessage(response.StatusCode));


            });


            var scenario = ScenarioBuilder.CreateScenario("scenario with 1 client", step);

            NBomberRunner
                .RegisterScenarios(scenario)
                .Run();


        }
    }
}
