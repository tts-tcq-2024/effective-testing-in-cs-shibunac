using NUnit.Framework;
using System;
using System.IO;

namespace AlerterSpace.Tests {
    [TestFixture]
    public class AlerterTests {
        [SetUp]
        public void SetUp() {
            // Reset the alert failure count before each test
            Alerter.alertFailureCount = 0;
        }

        [Test]
        public void TestAlertInCelcius_ErrorHandling() {
            // Override the networkAlertStub to simulate failure
            Alerter.networkAlertStub = (celcius) => 500;

            using (var sw = new StringWriter()) {
                Console.SetOut(sw);
                Alerter.alertInCelcius(75); // ~23.89°C
                var output = sw.ToString().Trim();
                Assert.AreEqual("ALERT: Temperature is 23.88888888888889 celcius", output);
                Assert.AreEqual(1, Alerter.alertFailureCount); // Expecting failure count to increment
            }

            // Restore the original stub if needed
            Alerter.networkAlertStub = (celcius) => 200; // Reset for other tests if necessary
        }
    }
}
