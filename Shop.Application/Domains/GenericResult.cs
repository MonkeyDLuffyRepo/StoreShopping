using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Domains
{
    public class GenericResult<T>
    {
        public T Result { get; }
        public IEnumerable<string> ErrorMessages { get; }
        public bool IsSuccess { get; }

        public GenericResult(T result)
        {
            IsSuccess = true;
            Result = result;
        }
        public GenericResult(IEnumerable<string> msgs)
        {
            IsSuccess = false;
            ErrorMessages = msgs;
        }

        public static GenericResult<T> Success(T t)
        {
            return new GenericResult<T>(t);
        }
        public static GenericResult<T> Fail(IEnumerable<string> msgs)
        {
            return new GenericResult<T>(msgs);
        }
        public static GenericResult<T> Fail(string msg)
        {
            return new GenericResult<T>(new List<string> { msg });
        }

    }
}
