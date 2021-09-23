using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class APIReturnModel<T>
    {
        public T Result { get; set; }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsError { get; set; }
    }
}
