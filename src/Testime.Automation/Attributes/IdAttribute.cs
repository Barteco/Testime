using OpenQA.Selenium;

namespace Testime.Automation.Attributes
{
    public class IdAttribute : LocatorAttribute
    {
        private readonly string _id;

        public IdAttribute(string id)
        {
            _id = id;
        }

        public override IWebElement Initialize(IWebDriver driver)
        {
            return driver.FindElement(By.Id(_id));
        }
    }
}
