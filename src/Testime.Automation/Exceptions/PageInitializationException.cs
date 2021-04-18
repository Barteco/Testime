using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Testime.Automation.Exceptions
{
    [SuppressMessage("Design", "RCS1194:Implement exception constructors.")]
    public class PageInitializationException : AggregateException
    {
        public PageInitializationException(string pageName, IEnumerable<Exception> innerExceptions) : base($"Field '{pageName}' initialization failed", innerExceptions)
        {
        }
    }
}