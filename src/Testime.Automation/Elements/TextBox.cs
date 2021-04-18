﻿using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("input", "text")]
    [TagConstraint("input", "number")]
    public class TextBox : HtmlElement
    {
        public string Value => Attribute("value");

        public string Placeholder => Attribute("placeholder");

        public int? MaxLength => TryGetIntegerAttribute("maxlength");

        public bool Disabled => !Self.Enabled;

        public new void SetValue(string value)
        {
            base.SetValue(value);
        }
    }
}
