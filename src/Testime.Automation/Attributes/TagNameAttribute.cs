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

        public override By Locate()
        {
            return By.TagName(_tagName);
        }
    }
}