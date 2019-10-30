// <copyright file="DuplicateEntryException.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Exceptions
{
    using System;

    /// <summary>
    /// Thrown when a duplicate entry is made
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class DuplicateEntryException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateEntryException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public DuplicateEntryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateEntryException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public DuplicateEntryException(string message)
            : base(message)
        {
        }
    }
}
