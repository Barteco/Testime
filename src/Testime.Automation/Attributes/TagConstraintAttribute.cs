using OpenQA.Selenium;
using System;

namespace Testime.Automation.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TagConstraintAttribute : Attribute
    {
        public string Contraint { get; }

        public readonly string _tag;
        public readonly string _type;

        public TagConstraintAttribute(string tag, string typeAttribute = null)
        {
            _tag = tag;
            _type = typeAttribute;
            Contraint = tag.ToLower() + (string.IsNullOrWhiteSpace(_type) ? string.Empty : $"[type='{_type.ToLower()}']");
        }

        internal bool Matches(IWebElement element)
        {
            return element.TagName.Equals(_tag, StringComparison.InvariantCultureIgnoreCase)
                && (string.IsNullOrWhiteSpace(_type) || element.GetAttribute("type").Equals(_type, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}