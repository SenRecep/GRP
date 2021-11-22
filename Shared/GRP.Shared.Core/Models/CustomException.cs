﻿using System;
using System.Runtime.Serialization;

namespace GRP.Shared.Core.Models
{
    public class CustomException : Exception
    {
        public CustomException()
        {

        }
        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
