using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium_Waits
{
    public class WebDriver_Waits_Tests
    {
        IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html");
        }

        [TearDown]
        public void TearDown()
        {
           driver.Quit();
           driver.Dispose();
        }

        [Test]
        public void AddRedBoxWithoutWaitsFails()
        { 
            // locate  and click add button
              driver.FindElement(By.XPath("//input[@value='Add a box!']")).Click();

           // locate red box by ID
              IWebElement redBox = driver.FindElement(By.Id("box0"));

           // Assert that red box is displayed.
              Assert.True(redBox.Displayed);

           // The test will fail because there is a delay in rendering the "redBox" and the test will not find it. 
        }

        [Test]
        public void RevealInputWithoutWaitsFail()
        {
            // locate  and click "Reveal a new input" button
               driver.FindElement(By.XPath("//input[@value='Reveal a new input']")).Click();

            // locate input field
               IWebElement inputField = driver.FindElement(By.Id("revealed"));

            // Fill input field 
               inputField.SendKeys("Displayed");

            // Assert tha the value is correct
               Assert.That(inputField.GetAttribute("value"), Is.EqualTo("Displayed"));

            // The test will fail because there is a delay in rendering the "inputField" and the test will not find it. 
        }

        [Test]
        public void AddRedBoxWithThreadSleep()
        {
            // locate  and click add button
               driver.FindElement(By.XPath("//input[@value='Add a box!']")).Click();

            // wait for a fixed amount of time (e.g., 3 seconds).
               Thread.Sleep(3000);

            // Check if a new red box has been created
               IWebElement redBox = driver.FindElement(By.Id("box0"));

            // Assert that new red box is displayed.
               Assert.True(redBox.Displayed);
        }

        [Test]
        public void AddRedBoxWithImplicitWait()
        {
            // locate  and click add button
               driver.FindElement(By.XPath("//input[@value='Add a box!']")).Click();

            // Set up implicit wait 
               driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); 


            // Check if a new red box has been created
               IWebElement redBox = driver.FindElement(By.Id("box0"));

            // Assert that new red box is displayed
               Assert.True(redBox.Displayed);
        }

        [Test]
        public void RevealInputWithImplicitWaits()
        {
            // locate  and click "Reveal a new input" button
               driver.FindElement(By.XPath("//input[@value='Reveal a new input']")).Click();

            // Set up Implicit wait 
               driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); 

            // locate input field
               IWebElement inputField = driver.FindElement(By.Id("revealed"));

            // Assert that the "inputField" exists and is interactable by checking its tag name
               Assert.That(inputField.TagName, Is.EqualTo("input"));
        }

        [Test]
        public void RevealInputWithExplicitWaits()
        {
            // locate  and click "Reveal a new input" button
                driver.FindElement(By.XPath("//input[@value='Reveal a new input']")).Click();

            // Create Explicit wait to wait for the "inputField" to be displayed.
                 WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(3));

            // Locate input field
                IWebElement inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("revealed")));

            // Fill data in inputField
               inputField.SendKeys("Displayed");    


            // Assert that the "inputField" exists and is interactable by checking its tag name
               Assert.That(inputField.GetAttribute("value"), Is.EqualTo("Displayed"));
        }


        [Test]
        public void AddRedBoxWithFluentWaitExpectedConditionsAndIgnoredExceptions()
        {
            // locate and click "Add a box!" button
                driver.FindElement(By.XPath("//input[@value='Add a box!']")).Click();

            // Set up Fluent Wait with ExpectedConditions wait for 3 sec.
                WebDriverWait  wait = new WebDriverWait(driver,TimeSpan.FromSeconds(3));

            // Set up PolliingInterval of 500 milliseconds.
                wait.PollingInterval = TimeSpan.FromMilliseconds(500);

            // Create IgnoreExceptionType
               wait.IgnoreExceptionTypes(typeof(NoSuchElementException));


            // Wait until the new red box is present and displayed
               IWebElement redBox = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("box0")));

            // Assert that new red box is displayed.
               Assert.True(redBox.Displayed);
        }


        [Test]
        public void RevealInputWithCustomFluentWait()
        {
            // locate  and click "Reveal a new input" button
                driver.FindElement(By.XPath("//input[@value='Reveal a new input']")).Click();

            // Set up Fluent wait  with ExceptionContidions wait for 5 seconds.
                WebDriverWait  wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            // Set up PollingInterval of 200 milliseconds.
                wait.PollingInterval = TimeSpan.FromMilliseconds(200);

            //  Create Fluent Wait to ignore specific exceptions
                wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

            // Wait until the "inputField "is present and displayed
                IWebElement inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("revealed")));

            // Fill input field 
               inputField.SendKeys("Displayed");



            // Assert that the value is correct
               Assert.That(inputField.GetAttribute("value"), Is.EqualTo("Displayed"));

            // Assert that the "inputField" exists and is interactable by checking its tag name
               Assert.That(inputField.TagName, Is.EqualTo("input"));   
        }

        [Test]
        public void AddRedBoxWithoutWaits_ReturnNoSuchElementException()
        {

            // Locate and click "Add a box!" button
                driver.FindElement(By.XPath("//input[@value='Add a box!']")).Click();

            // Locate red box 
            // Assert that NoSuchElementException thrown when the new redBox is not found.

            Assert.Throws<NoSuchElementException>(() =>
            {
                IWebElement redBox = driver.FindElement(By.Id("box0"));
            });
        }

        [Test]
        public void RevealInputWithoutWaits_ReturnElementNotInteractableException()
        {

            // Locate and click "Reveal a new input" button
               driver.FindElement(By.XPath("//input[@value='Reveal a new input']")).Click();

            // Locate input field and try to fill it immediately
            // Assert that ElementNotInteractableException thrown when the input element is not interactable.

            Assert.Throws<ElementNotInteractableException>(() =>
            {
                IWebElement inputField = driver.FindElement(By.Id("revealed"));
                inputField.SendKeys("Displayed");
            });
        }
    }
}