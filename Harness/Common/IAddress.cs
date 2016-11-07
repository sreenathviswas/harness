using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harness
{
    interface IAddress
    {
        [FindsBy(How = How.XPath, Using = "input[@ng-model='model.AddressLine1']")]
        IWebElement AddressLine1 { get; set; }

        [FindsBy(How = How.XPath, Using = "input[@ng-model='model.AddressLine2']")]
        IWebElement AddressLine2 { get; set; }

        [FindsBy(How = How.XPath, Using = "input[@ng-model='model.City']")]
        IWebElement City { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@title='State']")]
        IWebElement State { get; set; }

        [FindsBy(How = How.XPath, Using = "input[@ng-model='model.ZipCode']")]
        IWebElement Zip { get; set; }
    }
}
