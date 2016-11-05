using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Harness
{

    public class Login
    {
        public Login()
        {
            PageFactory.InitElements(SearchContext.Driver, this);
        }

        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.ClassName, Using = "fz-login-button")]
        public IWebElement Submit { get; set; }

        public void Execute(string userName, string password)
        {
            UserName.SendKeys(userName);
            Password.SendKeys(password);
            this.Submit.Click();
        }
    }
}
