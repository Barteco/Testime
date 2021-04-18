using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Testime.Automation.Exceptions
{
    [SuppressMessage("Design", "RCS1194:Implement exception constructors.")]
    public class TagContraintFailureException : Exception
    {
        public TagContraintFailureException(FieldInfo field, string[] constraints) : base($"Element '{field.Name}' {FormatMessage(constraints)}")
        {
        }

        private static string FormatMessage(string[] constraints)
        {
            if (constraints.Length == 1)
            {
                return $"must match HTML tag: {constraints[0]}";
            }
            else if(constraints.Length > 1)
            {
                return $"must match any of the HTML tags: {string.Join(", ", constraints)}";
            }

            return string.Empty;
        }
    }
}
