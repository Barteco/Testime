using System;
using Testime.Automation.Internal;

namespace Testime.Automation.Web
{
    public class WebApplicationSettings
    {
        public string Url { get; set; } = EndpointHelper.GenerateLocalEndpoint();
        public WebBrowser Browser { get; set; } = WebBrowser.Chrome;
        public RunMode RunMode { get; set; } = RunMode.Default;
        public bool AcceptInsecureCertificates { get; set; } = true;

        public static WebApplicationSettings Default => new ();

        public WebApplicationSettings Apply(Action<WebApplicationSettings> settings)
        {
            settings?.Invoke(this);

            return this;
        }
    }
}