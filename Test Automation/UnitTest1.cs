using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Test_Automation
{
    public class Tests
    {
        IWebDriver driver;
        string password = "#Ed0012345$#";
        string email = "diveshn00@outlook.com";
        [SetUp]
        public void Setup()
        {
            // Set up the ChromeDriver
            driver = new ChromeDriver();
        }

        [Test]
        public void OpenOutlookAndSignIn()
        {
            try
            {
                driver.Navigate().GoToUrl("https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=19&ct=1703227183&rver=7.0.6738.0&wp=MBI_SSL&wreply=https%3a%2f%2foutlook.live.com%2fowa%2f%3fcobrandid%3dab0455a0-8d03-46b9-b18b-df2f57b9e44c%26nlp%3d1%26deeplink%3dowa%252f%26RpsCsrfState%3d7654982e-95a5-37e6-bb43-cc3db76e3022&id=292841&aadredir=1&CBCXT=out&lw=1&fl=dob%2cflname%2cwld&cobrandid=ab0455a0-8d03-46b9-b18b-df2f57b9e44c");
                IWebElement emailInput = driver.FindElement(By.XPath("//input[@name='loginfmt']"));
                emailInput.SendKeys(email); 
                IWebElement nextButton = driver.FindElement(By.XPath("//input[@id='idSIButton9']"));
                nextButton.Click();
                IWebElement passwordInput = driver.FindElement(By.XPath("//input[@id='i0118']"));
                passwordInput.SendKeys(password); 
                System.Threading.Thread.Sleep(5000);
                IWebElement signInButton = driver.FindElement(By.XPath("//input[@id='idSIButton9']"));
                signInButton.Click();
                System.Threading.Thread.Sleep(5000);
                IWebElement staySigningButton = driver.FindElement(By.XPath("//*[@id=\"idSIButton9\"]"));
                if (staySigningButton.Enabled)
                {
                    staySigningButton.Click();
                }
                System.Threading.Thread.Sleep(10000);
                IWebElement newEmailButton = driver.FindElement(By.XPath("//*[@id=\"innerRibbonContainer\"]/div[1]/div/div/div/div[1]/div/div/span/button[1]"));
                newEmailButton.Click();
                System.Threading.Thread.Sleep(10000);

                IWebElement ToEmailInput = driver.FindElement(By.XPath("//*[@id=\"docking_InitVisiblePart_0\"]/div/div[3]/div[1]/div/div[3]/div/div/div[1]"));
                ToEmailInput.SendKeys("nsseetohul@gmail.com");
                System.Threading.Thread.Sleep(5000);

                IWebElement subjectInput = driver.FindElement(By.XPath("//input[@placeholder='Add a subject']"));
                subjectInput.SendKeys("Test Automation");
                System.Threading.Thread.Sleep(5000);

                IWebElement EmailContentInput = driver.FindElement(By.XPath("//*[@id=\"editorParent_1\"]/div"));
                EmailContentInput.SendKeys("Divesh Weds Dipti");
                System.Threading.Thread.Sleep(5000);

                IWebElement sendEmailButton = driver.FindElement(By.XPath("//*[@id=\"docking_InitVisiblePart_0\"]/div/div[2]/div[1]/div/span/button[1]"));
                sendEmailButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Test failed with exception: {e.Message}");
                throw; 
            }
        
        }
    }
}
