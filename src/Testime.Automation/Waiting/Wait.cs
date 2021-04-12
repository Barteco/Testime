using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using Testime.Automation.Internal;

namespace Testime.Automation.Waiting
{
    public class Wait
    {
        private readonly RemoteWebDriver _driver;

        private readonly TimeSpan _shortTimeout = TimeSpan.FromSeconds(10);
        private readonly TimeSpan _defaultTimeout = TimeSpan.FromMinutes(1);
        private readonly TimeSpan _shortInterval = TimeSpan.FromMilliseconds(100);
        private readonly TimeSpan _defaultInterval = TimeSpan.FromMilliseconds(500);

        private TimeSpan _interval;
        private TimeSpan _timeout;
        private string _message;

        public Wait(RemoteWebDriver driver)
        {
            _driver = driver;
            _interval = _defaultInterval;
            _timeout = _defaultTimeout;
        }

        public Wait WithTimeout(TimeSpan timeout)
        {
            _timeout = timeout;

            return this;
        }

        public Wait WithInterval(TimeSpan interval)
        {
            _interval = interval;

            return this;
        }

        public Wait WithMessage(string message)
        {
            _message = message;

            return this;
        }

        public void Until(Func<bool> condition)
        {
            var wait = new WebDriverWait(_driver, _timeout)
            {
                PollingInterval = _defaultInterval
            };

            if (!string.IsNullOrWhiteSpace(_message))
            {
                wait.Message = _message;
            }

            wait.Until(_ => condition());
        }

        public void UntilDocumentReady()
        {
            WithInterval(_shortInterval);
            Until(() => _driver.IsDocumentReady());
        }
    }
}
