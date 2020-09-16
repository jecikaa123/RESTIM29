using Common.CommunicationModel;
using Common.Interfaces;
using Common.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Common.Repository
{
    public class RepositoryComponent : IRepositoryComponent
    {
        public RepositoryComponent()
        {
            context = new CommunicationBus_DbContext();
        }
        private CommunicationBus_DbContext context;
        public RepositoryComponent(CommunicationBus_DbContext context)
        {
            this.context = context;
        }

        ~RepositoryComponent()
        {
            context.Dispose();
        }
        public XmlDocument SqlQuery(string sql)
        {
            Response responseModel = new Response();
            try
            {
                if (sql.Contains("SELECT"))
                {

                }
                else
                {
                    int response = context.Database.ExecuteSqlCommand(sql);
                    if (response != 0)
                    {
                        responseModel.Status = EStatus.SUCCESS;
                        responseModel.StatusCode = (double)EStatus.SUCCESS;

                    }
                    else
                    {
                        responseModel.Status = EStatus.REJECTED;
                        responseModel.StatusCode = (double)EStatus.REJECTED;
                    }
                }

            }
            catch (Exception e)
            {
                responseModel.Status = EStatus.REJECTED;
                responseModel.StatusCode = (int)EStatus.REJECTED;
                responseModel.Payload = e.Message;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Response));
            TextWriter stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, responseModel);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(stringWriter.ToString());
            return xmlDocument;
        }

        private Response ExecuteGetMethod(string sql)
        {
            Response response = null;
            string payload = "";
            response = new Response(EStatus.SUCCESS, (double)EStatus.SUCCESS, "");
            if (sql.Contains("Resources"))
            {
                var result = context.Resources.SqlQuery(sql).ToList();
                if (result != null)
                    result.ForEach(x => payload += x.ToString() + "\n");
                else
                    response = new Response(EStatus.REJECTED, (double)EStatus.REJECTED, "");
            }
            else if (sql.Contains("Relation"))
            {
                var result = context.Relations.SqlQuery(sql).ToList();
                if (result != null)
                    result.ForEach(x => payload += x.ToString() + "\n");
                else
                    response = new Response(EStatus.REJECTED, (double)EStatus.REJECTED, "");
            }
            else if (sql.Contains("RelationType"))
            {
                var result = context.RelationTypes.SqlQuery(sql).ToList();
                if (result != null)
                    result.ForEach(x => payload += x.ToString() + "\n");
                else
                    response = new Response(EStatus.REJECTED, (double)EStatus.REJECTED, "");
            }
            else if (sql.Contains("ResourceType"))
            {
                var result = context.ResourceTypes.SqlQuery(sql).ToList();
                if (result != null)
                    result.ForEach(x => payload += x.ToString() + "\n");
                else
                    response = new Response(EStatus.REJECTED, (double)EStatus.REJECTED, "");
            }

            response.Payload = payload;

            return response;
        }
    }
}
