using System;
using System.Runtime.Serialization;

namespace Tools.Common.Exceptions.ParameterExceptions
{
  public class GetParameterException : Exception
  {
    public GetParameterException()
    {
    }

    public GetParameterException(string message) : base(message)
    {
    }

    public GetParameterException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected GetParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}
