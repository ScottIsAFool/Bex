using System;

namespace Bex.Exceptions
{
    public class BexException : Exception
    {
        public string Code { get; }
        public string Description { get; }

        public BexException(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
