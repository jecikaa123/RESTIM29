using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Common.Repository
{
    public class RepositoryMock : IRepositoryComponent
    {
        public bool IsMethodCalled { get; set; }
        public RepositoryMock()
        {
            IsMethodCalled = false;
        }
        public XmlDocument SqlQuery(string sql)
        {
            IsMethodCalled = true;
            return new XmlDocument();
        }
    }
}
