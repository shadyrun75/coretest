using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.Models.Common
{
    public class CoreTestException : Exception
    {
        public CoreTestException() { }
        public CoreTestException(string message) : base(message) { }
        public CoreTestException(string message,  Exception innerException) : base(message, innerException) { }
        public static void ValueExist(string valueName) 
        {
            throw new CoreTestException($"{valueName} is exits");
        }

        public static void NotFound(string id)
        {
            throw new CoreTestException($"Record with id '{id}' not founded");
        }
    }
}