using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    class ConnectionType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ConnectionType() { }

        public ConnectionType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
