using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBattle.Shared
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool isSuccess { get; set; } = true;
        public string Message { get; set; }
    }
}
