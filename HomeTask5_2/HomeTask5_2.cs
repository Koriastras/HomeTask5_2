using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace HomeTask5_2
{
    public class HomeTask5_2
    {
        [TestFixture]
        public class HomeTask5_1
        {

            IWebDriver driver;

            [SetUp]

            public void BeforeTest()
            {

                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            }

            [TearDown]

            public void AfterTest()
            {
                driver.Quit();
            }

            [TestCase("JohnDoe", "passw0rd")]
            [TestCase("LiliaJY", "isNotMe")]
            [TestCase("GoingTO", "BeAutol")]

            public void CheckInvalidData(string v1, string v2)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                string basePageUrl = "http://automationpractice.com/";
                driver.Navigate().GoToUrl(basePageUrl);

                wait.Until(x => x.FindElement(By.CssSelector(".logo.img-responsive")).Displayed);

                IWebElement signInButtonXPath = driver.FindElement(By.XPath("//a[@title = 'Log in to your customer account']"));
                IWebElement signInButtonCss = driver.FindElement(By.CssSelector(".login"));

                signInButtonXPath.Click();

                wait.Until(x => x.FindElement(By.XPath("//h3[text() = 'Already registered?']")).Displayed);

                IWebElement emailBox = driver.FindElement(By.Id("email"));
                IWebElement emailBoxXPath = driver.FindElement(By.XPath("//input[@id = 'email']"));
                IWebElement emailBoxCss = driver.FindElement(By.CssSelector("#email"));

                emailBox.Click();
                emailBox.SendKeys(v1);

                IWebElement passwordBox = driver.FindElement(By.Id("passwd"));
                IWebElement passwordBoxXPath = driver.FindElement(By.XPath("//input[@type = 'password']"));
                IWebElement passwordBoxCss = driver.FindElement(By.CssSelector("#passwd"));

                passwordBox.Click();
                passwordBox.SendKeys(v2);

                IWebElement logInButton = driver.FindElement(By.Id("SubmitLogin"));
                IWebElement logInButtonXPath = driver.FindElement(By.XPath("//button[@class = 'button btn btn-default button-medium']"));
                IWebElement logInButtonCss = driver.FindElement(By.CssSelector("button[name = 'submit_search']"));

                logInButton.Click();

                IWebElement allertMess = driver.FindElement(By.XPath("//p[text() = 'There is 1 error']"));

                Assert.That(allertMess.Displayed, "User was login with invalid data");

            }

            public static IEnumerable<TestCaseData> InvalidData
            {
                get
                {
                    yield return new TestCaseData("JohnDoe", "passw0rd");
                    yield return new TestCaseData("LiliaJY", "isNotMe");
                    yield return new TestCaseData("GoingTO", "BeAutol");
                }
            }

            [TestCaseSource("InvalidData")]
            public void CheckInvalidDataWittTestCaseData(string v1, string v2)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                string basePageUrl = "http://automationpractice.com/";
                driver.Navigate().GoToUrl(basePageUrl);

                wait.Until(x => x.FindElement(By.CssSelector(".logo.img-responsive")).Displayed);

                IWebElement signInButtonXPath = driver.FindElement(By.XPath("//a[@title = 'Log in to your customer account']"));
                IWebElement signInButtonCss = driver.FindElement(By.CssSelector(".login"));

                signInButtonXPath.Click();

                wait.Until(x => x.FindElement(By.XPath("//h3[text() = 'Already registered?']")).Displayed);

                IWebElement emailBox = driver.FindElement(By.Id("email"));
                IWebElement emailBoxXPath = driver.FindElement(By.XPath("//input[@id = 'email']"));
                IWebElement emailBoxCss = driver.FindElement(By.CssSelector("#email"));

                emailBox.Click();
                emailBox.SendKeys(v1);

                IWebElement passwordBox = driver.FindElement(By.Id("passwd"));
                IWebElement passwordBoxXPath = driver.FindElement(By.XPath("//input[@type = 'password']"));
                IWebElement passwordBoxCss = driver.FindElement(By.CssSelector("#passwd"));

                passwordBox.Click();
                passwordBox.SendKeys(v2);

                IWebElement logInButton = driver.FindElement(By.Id("SubmitLogin"));
                IWebElement logInButtonXPath = driver.FindElement(By.XPath("//button[@class = 'button btn btn-default button-medium']"));
                IWebElement logInButtonCss = driver.FindElement(By.CssSelector("button[name = 'submit_search']"));

                logInButton.Click();

                IWebElement allertMess = driver.FindElement(By.XPath("//p[text() = 'There is 1 error']"));

                // Assert.That(allertMess.Displayed, "User was login with invalid data");
                Assert.IsTrue(allertMess.Displayed, "User was login with invalid data");

            }
        }
    }
}