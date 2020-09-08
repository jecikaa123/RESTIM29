using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    class Connection
    {
        public int Id { get; set; }
        public int IdFirst { get; set; }
        public int IdSecond { get; set; }
        public ConnectionType ConnectionType { get; set; }
        public Connection(){ }
        public Connection(int id, int idFirst, int idSecond, ConnectionType connectionType)
        {
            Id = id;
            IdFirst = idFirst;
            IdSecond = idSecond;
            ConnectionType = connectionType;
        }
    }
}
