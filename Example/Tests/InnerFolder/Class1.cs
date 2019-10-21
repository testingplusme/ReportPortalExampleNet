using NUnit.Framework;
using System;

namespace Example.Tests.InnerFolder
{
    [TestFixture]
    public class Class1
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            throw new Exception("OneTimeSetUp exception.");
        }

        [Test]
        public void Test1()
        {

        }

        [Test]
        public void Test2()
        {

        }
    }
}
