using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Utilities
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
