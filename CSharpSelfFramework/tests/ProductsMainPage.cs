using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using CSharpSelfFramework.utilities;
using CSharpSelfFramework.pageObjects;


//cd CSharpSelfFramework
//dotnet test CSharpSelfFramework.csproj----> to test all testcases and classes
//dotnet test CSharpSelfFramework.csproj --filter TestCategory=Smoke  ----> to execute only the selected testcase
//dotnet test CSharpSelfFramework.csproj --filter TestCategory=Smoke --% -- TestRunParameters.Parameter(name=\"browserName\",value=\"Edge\")


namespace CSharpSelfFramework.tests
{
    [Parallelizable(ParallelScope.Children)]//2) 2 methods run in parallel(ondesatti)
    public class E2Etest : Base
    {

        /* [TestCase("rahulshettyacademy", "learning")]//one dataset
        [TestCase("rahulshettya", "learning")]//second dataset,we can perform patameterization
       if there is plenty of data then TestCase Will not be user instead TestCaseSource Used*/
        [Test, TestCaseSource("AddTestDataConfirm"), Category("Regression")]


        //run all datasets of test method in parallel
        //run all test methods in one class parallel
        //run all test files inprojects parellel


        [Parallelizable(ParallelScope.All)]//1) locator and endtoend test method run in sequence,then endtoend tests run in parallel 
        public void EndToEndTest(string username,string password, string[] expectedProducts)
        {
           // string[] expectedProducts = { "iphone X", "Blackberry" };
            string[] actualProducts = new string[2];//creating new arrey

            LoginPage loginpage = new LoginPage(getDriver());
            //loginpage.getUserName().SendKeys("rahulshettyacademy");//in loginpage there is a getUsername method in that i have to pass rahulshettyacademy
            ProductsPage productPage=loginpage.validLogin(username,password);
            productPage.waitForPageDisplay();

            IList<IWebElement> products = productPage.getCards();
            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(productPage.getCardTitle()).Text))
                {
                    // click add to cart
                    product.FindElement(productPage.AddToCardButton()).Click();
                }
                //TestContext.Progress.WriteLine(product.FindElement(By.PartialLinkText("Checkout")).Text);
            }
           CheckoutPage checkoutpage= productPage.checkout();

            IList<IWebElement> checkoutCards = checkoutpage.getCards();
            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;
            }
            Assert.AreEqual(expectedProducts, actualProducts);


            //clicking checkout button
            SelectionPage selectionpage = checkoutpage.getButton();


            //selecting india
            selectionpage.getSelectingName().SendKeys("ind");
            selectionpage.waitForPageDisplay();
            selectionpage.validSelection();

            string confirmTest = selectionpage.getSuccessBtn().Text;
            StringAssert.Contains("Success", confirmTest);


        }

        [Test,Category("Smoke")]
        public void UsernameTest()
        {

            driver.Value.FindElement(By.Id("username")).SendKeys("Harshithaaithal");
            driver.Value.FindElement(By.Id("username")).Clear();
            driver.Value.FindElement(By.Id("username")).SendKeys("Harshithaaithal16");
            driver.Value.FindElement(By.Name("password")).SendKeys("123456");

            // CssSelector
            //Tagname[atribute='value']

            /*    driver.FindElement(By.CssSelector("button[type='submit']")).Click();*/

            //checkbox
            //css-.text-info span:nth-child(1) input
            // xpath-label[@class='text-info']/span/input
            //if u have id we have to convert to css then --->#id or id=terms ==>#terms
            //classname=.class
            driver.Value.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            //XPath
            //      //tagname[@atribute='value']
            driver.Value.FindElement(By.XPath("//input[@type='submit']")).Click();


            //Thread.Sleep(3000);
            //if  this takes 8 sec then we cant change it globally because performance become slow
            //in this case explicit wait is used

            //declare
            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
            .TextToBePresentInElementValue(driver.Value.FindElement(By.Id("signInBtn")), "Sign In"));


            String errormsg = driver.Value.FindElement(By.ClassName("alert")).Text;//grab the test 
            TestContext.Progress.WriteLine(errormsg);// prnt it
        }

        public  static IEnumerable<TestCaseData> AddTestDataConfirm()
        {
          yield return new TestCaseData(getDataParcer().extractData("username"), getDataParcer().extractData("password"), getDataParcer().extractDataArray("products"));//dataset1 
          yield return  new TestCaseData(getDataParcer().extractData("user_wrong"), getDataParcer().extractData("pass_wrong"), getDataParcer().extractDataArray("products"));//dataset2
          yield return   new TestCaseData(getDataParcer().extractData("username"), getDataParcer().extractData("password"), getDataParcer().extractDataArray("products"));//dataset3
           //to call extractdata method we have to create object instead of that we create a method getDataParcer in Base class so that
           //we can directly call a method

        }
    }
}