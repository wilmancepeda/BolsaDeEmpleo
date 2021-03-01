using BolsaEmpleo.IRepository;
using BolsaEmpleo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BolsaEmpleoTests.ConfigurationsTest
{
    [TestClass]
    class ConfigurationTests
    {
        IConfigurationRepository _configurationRepository;
        public ConfigurationTests(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }
        [TestMethod]
        public void GetConfiguration_ShouldBeTheSameAsync()
        {
            //Arrange
            byte id = 1;

            var expected = new Configuration() { IdConfiguration = 1, ConfigutarionName = "ShowJobMax", Value = "3" };
            //Act
            Configuration actual = _configurationRepository.GetConfiguration(id).Result.Data;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Configuration));
            Assert.AreEqual(expected, actual);
        }
    }
}
