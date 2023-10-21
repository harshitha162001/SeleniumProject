using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using ICSharpCode.SharpZipLib.Zip;
using OpenQA.Selenium.DevTools.V116.Page;
using AventStack.ExtentReports.Listener.Entity;

namespace CSharpSelfFramework.utilities
{
    public  class Base
    {
        public  ExtentReports extent;
       public  ExtentTest test;
        String browserName;

        //reportfile
        [OneTimeSetUp]
        public void SetUp()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Harshitha");

        }

        /*public  IWebDriver driver;*/
        public ThreadLocal<IWebDriver> driver=new ThreadLocal<IWebDriver>();
        [SetUp]
        public void StartBrowser()
        {
            test= extent.CreateTest(TestContext.CurrentContext.Test.Name);//testname
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {
                //configuration
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browserName);
            driver.Value.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }
        public IWebDriver getDriver()
        {
            return driver.Value;
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {//factory design pattern
                case "FireFox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;


            }
        }
        public static jsonReader getDataParcer()
        {
            return new jsonReader();
        }

        [TearDown]
        public void AfterTest()
        {
            //result of execution is catched by
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;


            DateTime time = DateTime.Now;
            String fileName = "Screenshot" + time.ToString("h_mm_ss") + ".png";

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Fail("Test Failed", captureScreenShot(driver.Value, fileName));
                test.Log(Status.Fail, "Test failed with logtrace" + stackTrace);
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
            }
            extent.Flush();

                driver.Value.Quit();
            
        }


        public  Media captureScreenShot(IWebDriver driver,String screenShotName)
        {
           ITakesScreenshot ts= (ITakesScreenshot)driver;
          var screenshot=  ts.GetScreenshot().AsBase64EncodedString;//screenshot in base64 format
          return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();//base64 to their compatible media entity
        }

    }

}
