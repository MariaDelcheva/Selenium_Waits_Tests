# Selenium_Waits_Tests

**Prerequisites**
	Create a new NUnit test project.
	Install the necessary Selenium packages via NuGet: 
Selenium.WebDriver, Selenium.WebDriver.ChromeDriver, Selenium.Support.
	Initialize the ChromeDriver and navigate to the application URL.
	All the tests will be performed on the following URL: https://ww/selenium.dev/selenium/web/dynamic.html 


**1.	Test Without Waits**

Observe failures due to elements not being immediately available.

-	Open your test project and create a new test called AddBoxWithoutWaitsFails().

-	Create a new test called RevealInputWithoutWaitsFail().
  
**2.	Using Thread.Sleep**
   
-	Create a new test called AddBoxWithThreadSleep().

**3.	Implicit Waits**

-	Create a new test method called AddBoxWithImplicitWait().
-	Create a new test method called RevealInputWithImplicitWaits().

**4.	Explicit Waits**

-	Create a new test called RevealInputWithExplicitWaits().

**5.Fluent Wait with Expected Conditions and Ignored Exceptions**

In order to use Expected Conditions, you need to install SeleniumExtras.WaitHelpers via Nuget.
-	Create a new test called AddBoxWithFluentWaitExpectedConditionsAndIgnoredExceptions().

**6.Custom Waits Conditions**

-      Create a new test called RevealInputWithCustomFluentWait().
  
**7.Exceptions:**

Modify the First Two Tests to Assert Exceptions
-	Modify the AddBoxWithoutWaitsFails test to assert the NoSuchElementException thrown when the new box element is not found.

-	Modify the RevealInputWithoutWaitsFail test to assert the ElementNotInteractableException thrown when the input element is not interactable.
