using System;
using System.Collections.Generic;
using System.Text;

namespace State.Core.Requests
{
    public class CreateSateRequest(string Name, string Code)
    {
        public string Name { get; }= Name;  

        public string Code { get; }= Code;
    }
}
