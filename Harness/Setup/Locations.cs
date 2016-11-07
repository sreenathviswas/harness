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

        public void AddLocation()
        {
            GotoPracticeSettings();

            Location.Click();

            SearchGrid(1, "celebration1");

            Thread.Sleep(3000);

            WaitForElementVisible<Locations>(30);

            Add.Click();

            ShortName.SendKeys("CEL2");
            LocationName.SendKeys("Celebration2");
            AddressLine1.SendKeys("Celebration");
            AddressLine2.SendKeys("Celebration Jn");
            City.SendKeys("Celebration");
            State.Select("Alabama");
            Zip.SendKeys("123456789");

            Save.Click();

            Assert.AreEqual("Location saved successfully", Toastr.Text);
        }
    }
}
