﻿using System;

namespace VirtoCommerce.Domain.Search.Model
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public class IndexNotFoundException : SearchException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public IndexNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public IndexNotFoundException(string message)
            : base(message)
        {
        }
    }

}
