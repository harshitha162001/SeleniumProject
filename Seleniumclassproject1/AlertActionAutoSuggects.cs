using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;

namespace Seleniumclassproject1
{
    public class AlertActionAutoSuggects
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {

            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";

        }
        [Test]

        public void Test_Alert()
        {
            String name = "Harshitha";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onclick*='displayConfirm']")).Click();
           String alertText= driver.SwitchTo().Alert().Text;//grab the text
            driver.SwitchTo().Alert().Accept();
            // driver.SwitchTo().Alert().Dismiss();
            //  driver.SwitchTo().Alert().SendKeys("hello");
            StringAssert.Contains(name,alertText);
        }
        [Test]
        public void Test_AutoSuggestionDropDown()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("ind");
            Thread.Sleep(3000);
            IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));
            foreach (IWebElement option in options)
            {
                {
                    if (option.Text.Equals("India"))
                    {
                      
                        option.Click();
                    }
                }
                TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
                //we cant use .text here for the static value .text will be applied

            }
        }
        [Test]
        public void Test_Frame()
        {
            //scroll to go dowm
            IWebElement framescroll = driver.FindElement(By.Id("courses-iframe"));//untill this point the curser should scroll
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", framescroll);
            //id ,name,index
            
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.LinkText("All Access Plan")).Click();

         /* TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".h1")).Text);//now the h1 will disply the all access subcription rather than main title 
                                                                                          //because driver has been switched to the all access plan page

            //to switch back to the default content i.e to the main title page
            driver.SwitchTo().DefaultContent();
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".h1")).Text);
*/


        }

        [Test]

        public void test_Action()
        {
            driver.Url = "https://rahulshettyacademy.com/";
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            //  driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a")).Click();
            a.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();
        }
        [Test]
        public void test_Action1()
        {
            driver.Url = "https://demoqa.com/droppable";
            Actions a = new Actions(driver);
            a.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable"))).Perform();
        }

    }
}
