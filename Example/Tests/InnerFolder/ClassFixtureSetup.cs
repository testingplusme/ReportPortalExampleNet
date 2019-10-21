using NUnit.Framework;
using ReportPortal.Shared;
using System;

namespace Example.Tests.InnerFolder
{
    [SetUpFixture]
    public class ClassFixtureSetup
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Bridge.LogMessage(ReportPortal.Client.Models.LogLevel.Info, "OneTimeSetUp message");
            throw new Exception("Assembly SetUpFixture exception.");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Bridge.LogMessage(ReportPortal.Client.Models.LogLevel.Info, "OneTimeTearDown message");
            throw new Exception("Assembly TearDownFixture exception.");
        }
    }
}
