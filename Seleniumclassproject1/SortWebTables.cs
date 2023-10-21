using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections;

namespace Seleniumclassproject1
{
    public class SortWebTables
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {

            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";

        }
        [Test]
        public void SortTable()
        {
            ArrayList A=new ArrayList();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByText("20");

            //set 1:get all veg names
            IList<IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach(IWebElement vegie in veggies)
            {
                A.Add(vegie.Text);

            }

            //sort this array sorted -A(manually)
            A.Sort();
            foreach(String element in A)//text is a string so the collection is string
            {
                TestContext.Progress.WriteLine(element);
            }
            //step3:go and click colunm
            //xpath:  //th[contains(@aria-label,'fruit name')]
            driver.FindElement(By.CssSelector("th[aria-label*='fruit name']")).Click();
           
            //step4:get all veggie names into arraylist B (in the website)
            ArrayList B=new ArrayList();

            IList<IWebElement> sortedveggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement vegie in sortedveggies)
            {
                B.Add(vegie.Text);

            }

            //arraylist A to B =equal
            Assert.AreEqual(A, B);

        }
    }
}
