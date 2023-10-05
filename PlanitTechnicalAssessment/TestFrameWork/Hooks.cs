using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace PlanitTechnicalAssessment.TestFrameWork
{
    /// <summary>
    /// Add all the bindings to the test configurations and any additional funstionality or tools which needs to be hooked
    /// </summary>
    public class Hooks
    {
        public static TestConfig config;
        static Hooks()
        {
            config = new TestConfig();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(TestContext.CurrentContext.TestDirectory + "/AppSettings.json");
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);
        }
    }
}