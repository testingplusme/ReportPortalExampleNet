using NUnit.Framework;

namespace Example.Tests
{
    [Category("Category 1"), Category("Category 2")]
    [TestFixture, Ignore("Ignore reason for suite")]
    [Description("All tests in this suite should be skipped.")]
    public class IgnoredClass
    {
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
