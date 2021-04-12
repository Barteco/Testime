using OpenQA.Selenium;

namespace Testime.Automation.Attributes
{
    public class NameAttribute : LocatorAttribute
    {
        private readonly string _name;

        public NameAttribute(string name)
        {
            _name = name;
        }

        public override IWebElement Initialize(IWebDriver driver)
        {
            return driver.FindElement(By.Name(_name));
        }
    }
}