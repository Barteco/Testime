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

        public override By Locate()
        {
            return By.XPath(_xpath);
        }
    }
}