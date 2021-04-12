using OpenQA.Selenium;

namespace Testime.Automation.Attributes
{
    public class TagNameAttribute : LocatorAttribute
    {
        private readonly string _tagName;

        public TagNameAttribute(string tagName)
        {
            _tagName = tagName;
        }

        public override IWebElement Initialize(IWebDriver driver)
        {
            return driver.FindElement(By.TagName(_tagName));
        }
    }
}