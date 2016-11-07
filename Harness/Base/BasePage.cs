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
    public class BasePage
    {
        [FindsBy(How = How.ClassName, Using = "fz-user-name")]
        public IWebElement UserMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/main/header/ul[3]/li/div/ul/li[5]/a")]
        public IWebElement PracticeSettings { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Edit']")]
        public IWebElement Edit { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        public IWebElement Save { get; set; }

        [FindsBy(How = How.ClassName, Using = "toast-title")]
        public IWebElement Toastr { get; set; }

        public void GotoPracticeSettings()
        {
            UserMenu.Click();

            PracticeSettings.Click();
        }


        public void WaitForElementVisible<T>(int seconds)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                foreach (var findsByProperty in property.GetCustomAttributes(typeof(FindsByAttribute), true))
                {
                    var findsBy = (FindsByAttribute)findsByProperty;

                    By by = By.Id(findsBy.Using);

                    if (findsBy.How == How.Name)
                    {
                        by = By.Name(findsBy.Using);
                    }
                    else if (findsBy.How == How.ClassName)
                    {
                        by = By.ClassName(findsBy.Using);
                    }

                    new WebDriverWait(SearchContext.Driver, TimeSpan.FromSeconds(seconds))
                       .Until(ExpectedConditions.ElementIsVisible(by));

                    return;
                }
            }
        }

        public void ClearAll<T>(T t)
        {
            var properties = typeof(T).GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(ClearableAttribute)));
            foreach (var property in properties)
            {
                var p = property.GetValue(t);

                if (p is IWebElement)
                {
                    ((IWebElement)p).Clear();
                }
            }
        }

    }   
}
