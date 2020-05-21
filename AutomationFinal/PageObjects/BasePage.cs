using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationFinal.PageObjects
{
    class BasePage
    {
        static protected IWebDriver Driver { get; set; } = new ChromeDriver();
        protected WebDriverWait Wait { get; set; }
        public BasePage()
        {
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
        }
    }
}
