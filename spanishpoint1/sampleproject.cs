using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.DevTools.V112.WebAuthn;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace spanishpoint1
{
    internal class sampleproject
    {
        

        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.spanishpoint.ie/");
            driver.Manage().Window.Maximize();
            if (driver.FindElements(By.Id("cookie-law-info-bar")).Count > 0)
              {
                
                IWebElement acceptButton = driver.FindElement(By.Id("wt-cli-accept-btn"));
                acceptButton.Click();
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement solutionsServices = driver.FindElement(By.XPath("(//li[@id='menu-item-30711']//a[1])[1]"));
            Actions action = new Actions(driver);
            action.MoveToElement(solutionsServices).Click().Perform();
            IWebElement modernSolutions = driver.FindElement(By.XPath("(//a[@href='https://www.spanishpoint.ie/solutions/modern-work/'])[1]"));
            modernSolutions.Click();
            IWebElement condentCollabration = driver.FindElement(By.XPath("(//a[@href='#1612870161121-10af43ab-0ec4'])[1]"));
            condentCollabration.Click();
            IWebElement condentCollabrationHeader = driver.FindElement(By.XPath("//h3[text()='Content & Collaboration']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            String Actual = (String)js.ExecuteScript("return arguments[0].innerText;", condentCollabrationHeader);
            string Expected = "Content & Collaboration";
            Assert.AreEqual(Actual, Expected);
            string actualTagName = condentCollabrationHeader.TagName;
            string expectedTagName = "h3";
            Assert.AreEqual(actualTagName, expectedTagName);
            IWebElement textInParagraph = driver.FindElement(By.XPath("//p[contains(text(),'Spanish Point customers tell us that people are their most important asset. Our customers ask us')]"));
            String actualParagraphText =(String)js.ExecuteScript("return arguments[0].innerText;", textInParagraph);
            String expectedParagraphText = "Spanish Point customers tell us that people are their most important asset";
            if (!actualParagraphText.Contains(expectedParagraphText)) 
            {
                Assert.Fail();
            }
        }
    }
}
