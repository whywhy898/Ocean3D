using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Infrastructure.Exceptions
{
    /// <summary>
    /// 验证错误跑出的异常
    /// </summary>
    public class ValidateException : Exception
    {
        public ValidateException()
        { }

        public ValidateException(string message)
            : base(message)
        { }

        public ValidateException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
