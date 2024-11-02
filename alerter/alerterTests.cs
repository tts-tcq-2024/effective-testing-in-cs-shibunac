using NUnit.Framework;
using System;
using System.IO;

namespace AlerterSpace.Tests
{
  [TestFixture]
  public class AlerterTests
  {
    [SetUp]
    public void SetUp()
    {
      // Reset the alert failure count before each test
      Alerter.alertFailureCount = 0;
    }

    [Test]
    public void TestAlertInCelcius_NormalTemperature()
    {
      using (var sw = new StringWriter())
      {
        Console.SetOut(sw);
        Alerter.alertInCelcius(68); // 20°C
        var output = sw.ToString().Trim();
        Assert.Equals("ALERT: Temperature is 20 celcius", output);
        Assert.Equals(0, Alerter.alertFailureCount);
      }
    }

    [Test]
    public void TestAlertInCelcius_FreezingTemperature()
    {
      using (var sw = new StringWriter())
      {
        Console.SetOut(sw);
        Alerter.alertInCelcius(32); // 0°C
        var output = sw.ToString().Trim();
        Assert.Equals("ALERT: Temperature is 0 celcius", output);
        Assert.Equals(0, Alerter.alertFailureCount);
      }
    }

    [Test]
    public void TestAlertInCelcius_HighTemperature()
    {
      using (var sw = new StringWriter())
      {
        Console.SetOut(sw);
        Alerter.alertInCelcius(100); // ~37.78°C
        var output = sw.ToString().Trim();
        Assert.Equals("ALERT: Temperature is 37.77777777777778 celcius", output);
        Assert.Equals(0, Alerter.alertFailureCount);
      }
    }

    [Test]
    public void TestAlertInCelcius_FailureSimulation()
    {
      // Override the networkAlertStub to simulate failure
      //Alerter.networkAlertStub = (celcius) => 500;

      using (var sw = new StringWriter())
      {
        Console.SetOut(sw);
        Alerter.alertInCelcius(75); // ~23.89°C
        var output = sw.ToString().Trim();
        Assert.Equals("ALERT: Temperature is 23.88888888888889 celcius", output);
        Assert.Equals(1, Alerter.alertFailureCount);
      }

      // Restore the original stub if needed
      //Alerter.networkAlertStub = (celcius) => 200;
    }

    [Test]
    public void TestAlertInCelcius_NegativeTemperature()
    {
      using (var sw = new StringWriter())
      {
        Console.SetOut(sw);
        Alerter.alertInCelcius(0); // ~-17.78°C
        var output = sw.ToString().Trim();
        Assert.Equals("ALERT: Temperature is -17.77777777777778 celcius", output);
        Assert.Equals(0, Alerter.alertFailureCount);
      }
    }
  }
}
