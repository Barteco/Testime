using OpenQA.Selenium;

namespace Testime.Automation.Attributes
{
    public class ClassNameAttribute : LocatorAttribute
    {
        private readonly string _className;

        public ClassNameAttribute(string className)
        {
            _className = className;
        }

        public override By Locate()
        {
            return By.ClassName(_className);
        }
    }
}