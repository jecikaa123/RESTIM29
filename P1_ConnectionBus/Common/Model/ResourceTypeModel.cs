using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    class ResourceTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ResourceTypeModel() { }

        public ResourceTypeModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
