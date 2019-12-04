using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace CSPortalTest
{
    class TestBase2
    {

        // Create new student account
        [Test]
        static void createStudentTest(IWebDriver driver)
        {
          //Enter student details
          drive.FindElement(By.Id("firstnameTextBox")).SendKeys("AutoTest Fname");
          drive.FindElement(By.Id("lastNameTextBox")).SendKeys("AutoTest Lname");
          drive.FindElement(By.Id("schoolTextBox")).SendKeys("AutoTest SchoolName");
          drive.FindElement(By.Id("DropDownList1")).SendKeys("Student");
          drive.FindElement(By.Id("usernameTextBox")).SendKeys("#AutoTestStudent@bu.edu");
          drive.FindElement(By.Id("passwordTextBox")).SendKeys("#AutoTestPassword");
          drive.FindElement(By.Id("confirmPasswordTextBox")).SendKeys("#AutoTestPassword");


          //click to enter into the system
          driver.FindElement(By.Id("registerButton")).Click();

          driver.Manage().Window.Maximize();
          driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max

        }


        // Create new faculty account
        [Test]
        static void createFacultyTest(IWebDriver driver)
        {
          //Enter faculty details
          drive.FindElement(By.Id("firstnameTextBox")).SendKeys("AutoTest Fname");
          drive.FindElement(By.Id("lastNameTextBox")).SendKeys("AutoTest Lname");
          drive.FindElement(By.Id("schoolTextBox")).SendKeys("AutoTest SchoolName");
          drive.FindElement(By.Id("DropDownList1")).SendKeys("Faculty");
          drive.FindElement(By.Id("usernameTextBox")).SendKeys("#AutoTestFaculty@bu.edu");
          drive.FindElement(By.Id("passwordTextBox")).SendKeys("#AutoTestPassword");
          drive.FindElement(By.Id("confirmPasswordTextBox")).SendKeys("#AutoTestPassword");


          //click to enter into the system
          driver.FindElement(By.Id("registerButton")).Click();

          driver.Manage().Window.Maximize();
          driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max

        }


        // Add new project
        [Test]
        static void addProjectTest(IWebDriver driver)
        {
            //Enter project details
            drive.FindElement(By.Id("ProjectNameBox")).SendKeys("AutoTest Pname");
            drive.FindElement(By.Id("projectDesBox")).SendKeys("AutoTest P Desc.");
            drive.FindElement(By.Id("LinkBox")).SendKeys("AutoTest www.testProject.com");
            drive.FindElement(By.Id("uploadBox")).SendKeys("12/02/2019");
            drive.FindElement(By.Id("projectTagBox")).SendKeys("#AutoTest");

            //click to enter into the system
            driver.FindElement(By.Id("sumbit")).Click();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max

        }


        // Project List find a Project Name
        [Test]
        static void findProjectTestName(IWebDriver driver)
        {
            //Enter project details
            drive.FindElement(By.Id("DropDownList1")).SendKeys("Project Name");
            drive.FindElement(By.Id("TextBox1")).SendKeys("AutoTest Pname");


            //click to enter into the system

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max

        }


        // Project List find a Project Author
        [Test]
        static void findProjectTestAuthor(IWebDriver driver)
        {
            //Enter project details
            drive.FindElement(By.Id("DropDownList1")).SendKeys("Author Name");
            drive.FindElement(By.Id("TextBox1")).SendKeys("AutoTest Fname");


            //click to enter into the system

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max

        }

    
        // Add Comment
        [Test]
        static void addCommentTest(IWebDriver driver)
        {
            //Enter commnet details
            drive.FindElement(By.Id("commentBox")).SendKeys("Testing comment feature");

            //click to enter into the system
            driver.FindElement(By.Id("submit")).Click();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max

        }



    }
}
