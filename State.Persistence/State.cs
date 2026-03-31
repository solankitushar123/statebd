using System;
using System.Collections.Generic;
using System.Text;

namespace State.Persistence
{
    public class States
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
    }
}
