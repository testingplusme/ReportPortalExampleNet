using NUnit.Framework;
using System;

namespace Example.Tests
{
    [Parallelizable]
    
    [TestFixture]
    public class Class3
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            throw new Exception("Setup exception.");
        }

        [Test]
        public void Test1()
        {
            
        }

        [Test]
        public void Test2()
        {
            
        }

        [Test]
        public void Test3()
        {
            
        }
    }
}
