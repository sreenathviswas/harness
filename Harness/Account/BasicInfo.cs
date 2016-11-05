﻿using NUnit.Framework;
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
        [FindsBy(How = How.Name, Using = "AccountName")]
        public IWebElement AccountName { get; set; }

        [FindsBy(How = How.Name, Using = "NPI")]
        public IWebElement NPI { get; set; }

        [FindsBy(How = How.Name, Using = "TaxID")]
        public IWebElement TaxID { get; set; }

        [FindsBy(How = How.Name, Using = "WebsiteEdit")]
        public IWebElement Website { get; set; }
        
        public BasicInfo()
        {
            PageFactory.InitElements(SearchContext.Driver, this);
        }

        public void UpdateBasicInfo(string accountName, string npi, int taxID, string website)
        {
            UserMenu.Click();

            PracticeSettings.Click();

            Edit.Click();

            WaitForElement<BasicInfo>(30);

            ClearAll<BasicInfo>(this);

            //AccountName.Clear();
            AccountName.SendKeys(accountName);

            //NPI.Clear();
            NPI.SendKeys(npi);

            //TaxID.Clear();
            TaxID.SendKeys(taxID.ToString());

            //Website.Clear();
            Website.SendKeys(website);

            Save.Click();

            Assert.AreEqual("Account details updated successfully", Toastr.Text);
        }        
    }
}