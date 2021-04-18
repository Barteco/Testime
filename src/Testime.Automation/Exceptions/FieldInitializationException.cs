using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Testime.Automation.Exceptions
{
    [SuppressMessage("Design", "RCS1194:Implement exception constructors.")]
    public class FieldInitializationException : Exception
    {
        public FieldInitializationException(FieldInfo field, Exception innerException) : base($"Field '{field.Name}' initialization failed", innerException)
        {
        }
    }
}