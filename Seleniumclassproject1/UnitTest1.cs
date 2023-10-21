namespace Seleniumclassproject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           TestContext.Progress.WriteLine("Setup method run");

        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("test 1method run"); 
        }
        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("test2 method run");
        }
        [TearDown]
        public void CloseBrowser()
        {
            TestContext.Progress.WriteLine("teardown method run");

        }
    }
}