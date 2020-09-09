using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    class ConnectionModel
    {
        public int Id { get; set; }
        public int IdFirst { get; set; }
        public int IdSecond { get; set; }
        public ConnectionTypeModel ConnectionType { get; set; }
        public ConnectionModel(){ }
        public ConnectionModel(int id, int idFirst, int idSecond, ConnectionTypeModel connectionType)
        {
            Id = id;
            IdFirst = idFirst;
            IdSecond = idSecond;
            ConnectionType = connectionType;
        }
    }
}
