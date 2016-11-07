using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Harness
{
    public class Locations : BasePage
    {

        [FindsBy(How = How.ClassName, Using = "fz-btn-blue")]
        public IWebElement Add { get; set; }

        [FindsBy(How = How.Name, Using = "shortname")]
        public IWebElement ShortName { get; set; }

        [FindsBy(How = How.Name, Using = "locationname")]
        public IWebElement LocationName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@ng-model='model.AddressLine1']")]
        public IWebElement AddressLine1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@ng-model='model.AddressLine2']")]
        public IWebElement AddressLine2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@ng-model='model.City']")]
        public IWebElement City { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@title='State']")]
        public IWebElement State { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@ng-model='model.ZipCode']")]
        public IWebElement Zip { get; set; }

        public Locations()
        {
            PageFactory.InitElements(SearchContext.Driver, this);
        }

        public void AddLocation(string shortName, string locationName, string addressLine1, string addressLine2,
            string city, string state, string zip)
        {
            GotoPracticeSettings();

            Location.Click();

            SearchGrid("celebration", 1);

            Thread.Sleep(1000);

            WaitForElementVisible<Locations>(30);

            Add.Click();

            ShortName.SendKeys(shortName);
            LocationName.SendKeys(locationName);
            AddressLine1.SendKeys(addressLine1);
            AddressLine2.SendKeys(addressLine2);
            City.SendKeys(city);
            State.Select(state);
            Zip.SendKeys(zip);

            Save.Click();

            Assert.AreEqual("Location saved successfully", Toastr.Text);
        }
    }
}
