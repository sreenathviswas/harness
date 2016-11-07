using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harness
{
    public class BasicInfo : BasePage
    {
        [Clearable]
        [FindsBy(How = How.Name, Using = "AccountName")]
        public IWebElement AccountName { get; set; }

        [Clearable]
        [FindsBy(How = How.Name, Using = "NPI")]
        public IWebElement NPI { get; set; }

        [Clearable]
        [FindsBy(How = How.Name, Using = "TaxID")]
        public IWebElement TaxID { get; set; }

        [Clearable]
        [FindsBy(How = How.Name, Using = "WebsiteEdit")]
        public IWebElement Website { get; set; }
                
        [FindsBy(How = How.XPath, Using = "//div[@title='State']")]
        public IWebElement State { get; set; }

        public BasicInfo()
        {
            PageFactory.InitElements(SearchContext.Driver, this);
        }

        public void UpdateBasicInfo(string accountName, string npi, int taxID, string website)
        {
            GotoPracticeSettings();

            Edit.Click();

            WaitForElementVisible<BasicInfo>(30);

            ClearAll<BasicInfo>(this);

            AccountName.SendKeys(accountName);
            NPI.SendKeys(npi);
            TaxID.SendKeys(taxID.ToString());
            Website.SendKeys(website);

            State.Select("Alabama");

            Save.Click();

            Assert.AreEqual("Account details updated successfully", Toastr.Text);
        }
    }
}
