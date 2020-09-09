using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    class ResourceModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public ResourceTypeModel resourceType { get; set; }
		public ResourceModel() { }
        public ResourceModel(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
