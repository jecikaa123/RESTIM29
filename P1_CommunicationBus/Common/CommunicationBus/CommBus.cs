using Common.CommunicationModel;
using Common.Interfaces;
using Common.Repository;
using Common.XmlToDbAdapter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.CommunicationBus
{
    public class CommBus
    {
        private XNode XmlRequest;
        private IRepositoryComponent repository;
        public CommBus()
        {
            XmlRequest = null;
            repository = new RepositoryComponent();
        }

        public CommBus(IRepositoryComponent repo)
        {
            repository = repo;
        }

        public string SendRequest(string jsonRequest)
        {
            XmlRequest = JsonConvert.DeserializeXNode(jsonRequest, "Request");
            XmlToDbConverter xmlToSql = new XmlToDbConverter();
            string sqlQuery = xmlToSql.Convert(XmlRequest);
            var xmlResponse = repository.SqlQuery(sqlQuery);

            return JsonConvert.SerializeXmlNode(xmlResponse, Formatting.Indented);
        }
    }
}
