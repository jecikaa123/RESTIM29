using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.JSONToXMLAdapter
{
    public static class JSONToXML
    {
        public static  XNode JSONToXMLGenerator(string json) {
            XNode XMLnode = JsonConvert.DeserializeXNode(json, "JSONRequestModel");
            return XMLnode;
        }
    }
}
