using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChallengeN5Now.UnitTest
{
    public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            Environment.SetEnvironmentVariable("CONNECTION_STRING", "Server=localhost;Database=JDChallenge;User=sa;Password=Pass123$;TrustServerCertificate=true;");
            Environment.SetEnvironmentVariable("ELASTICSEARCH_SERVER", "http://localhost:9200");
            Environment.SetEnvironmentVariable("KAFKA_SERVER", "localhost:9092");
        }
    }
}
