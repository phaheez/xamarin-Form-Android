using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Helpers
{
    public class JsonMessage<T>
    {
        public List<T> Results { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
