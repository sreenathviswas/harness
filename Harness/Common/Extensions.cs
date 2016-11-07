using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harness
{    public static class Extensions
    {
        public static void Select(this IWebElement element, string value)
        {
            element.Click();

            var select2Input = SearchContext.Driver.FindElement(By.ClassName("select2-input"));
            select2Input.SendKeys(value);

            var select2Highlight = SearchContext.Driver.FindElement(By.ClassName("select2-highlighted"));
            select2Highlight.Click();
        }
    }
}
