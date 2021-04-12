using System;

namespace Testime.Automation.Web
{
    [Flags]
    public enum RunMode
    {
        Default = 0,
        Maximized = 1,
        Minimized = 2,
        Headless = 4
    }
}