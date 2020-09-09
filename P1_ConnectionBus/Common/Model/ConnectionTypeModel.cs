using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    class ConnectionTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ConnectionTypeModel() { }

        public ConnectionTypeModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
