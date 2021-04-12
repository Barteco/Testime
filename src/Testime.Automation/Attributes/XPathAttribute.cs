using OpenQA.Selenium;

namespace Testime.Automation.Attributes
{
    public class XPathAttribute : LocatorAttribute
    {
        private readonly string _xpath;

        public XPathAttribute(string xpath)
        {
            _xpath = xpath;
        }

        public override IWebElement Initialize(IWebDriver driver)
        {
            return driver.FindElement(By.XPath(_xpath));
        }
    }
}