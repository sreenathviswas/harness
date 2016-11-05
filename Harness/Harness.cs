using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harness
{
    [TestFixture]
    public class Harness
    {
        [SetUp]
        public void Init()
        {
            SearchContext.Driver = new ChromeDriver();
            SearchContext.Driver.Manage().Window.Maximize();
            SearchContext.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            SearchContext.Driver.Navigate().GoToUrl("http://celebration.fuzeqa1.com/#/login");
        }

        [TestCase("chinchu", "Abc@123")]
        public void Login(string userName, string password)
        {
            Login login = new Login();
            login.Execute(userName, password);
        }

        [Test]
        public void UpdateAccountBasicInfo()
        {
            Login("chinchu", "Abc@123");

            BasicInfo basicInfo = new BasicInfo();
            basicInfo.UpdateBasicInfo("Celebration Dental Group", "1003947326", 593408806, "http://celebration.fuzeqa1.com");
        }

        [TearDown]
        public void Exit()
        {
            SearchContext.Driver.Quit();
        }

    }
}
