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

        public override By Locate()
        {
            return By.Name(_name);
        }
    }
}