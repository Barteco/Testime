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

        public override IWebElement Initialize(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName(_className));
        }
    }
}