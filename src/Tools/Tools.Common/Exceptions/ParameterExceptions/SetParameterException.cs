using System;
using System.Runtime.Serialization;

namespace Tools.Common.Exceptions.ParameterExceptions
{
  public class SetParameterException : Exception
  {
    public SetParameterException()
    {
    }

    public SetParameterException(string message) : base(message)
    {
    }

    public SetParameterException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected SetParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}
