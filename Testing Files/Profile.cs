using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using System.Threading;
using CSPortalTest;

namespace automateTest
{
    class Profile : TestBase
    {
        [Test]
        public void EditProfileStudent()
         {

            //student login
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/");
            //Enter Username and Paswword
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("ratti@bu.edu");
            driver.FindElement(By.Id("passwordTextBos")).SendKeys("Ratti1234*");

            //click to enter into the system
            driver.FindElement(By.Id("submitButton")).Click();
            Console.WriteLine("Execute Test Login");

            //click to view profile
            driver.FindElement(By.Id("lbluser")).Click();

            driver.FindElement(By.Id("EmpGridView_EditButton1_0")).Click();

            //Clear text
            driver.FindElement(By.Id("TextBox4")).Clear();
            driver.FindElement(By.Id("TextBox5")).Clear();

            //Edit text
            driver.FindElement(By.Id("TextBox4")).SendKeys("Computer Science ");
            driver.FindElement(By.Id("TextBox5")).SendKeys("12/16/2019");


            //click Enter
            driver.FindElement(By.Id("Button2")).Click();

       
        }
        [Test]
        public void EditProfileFaculty()
        {

            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/");
            //Enter Username and Paswword
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("Natalia12@bu.edu");
            driver.FindElement(By.Id("passwordTextBos")).SendKeys("Natalia1234*");

            //click to enter into the system
            driver.FindElement(By.Id("submitButton")).Click();
            Console.WriteLine("Execute Test Login");

            //click to view profile
            driver.FindElement(By.Id("UserLabel1")).Click();

            driver.FindElement(By.Id("EmpGridView_EditButton1_0")).Click();

            //Clear text
            driver.FindElement(By.Id("TextBox3")).Clear();

            //Edit text
            driver.FindElement(By.Id("TextBox3")).SendKeys("Computer Science ");
         
            //click Enter
            driver.FindElement(By.Id("Button2")).Click();

        }

    }
}
