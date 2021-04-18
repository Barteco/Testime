using System;
using OpenQA.Selenium;

namespace Testime.Automation.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public abstract class LocatorAttribute : Attribute
    {
        public abstract By Locate();
    }
}